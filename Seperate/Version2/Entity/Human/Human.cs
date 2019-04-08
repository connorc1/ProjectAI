using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UMA;
using UMA.CharacterSystem;
// Created by Connor Chamberlain on 26/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 *  protected EntityOfType type; 
 *  public EntityTaskController entityController;
 *  public EntityBehaviour entityBehaviour;
 *  
 *  protected float nextUpdate;
 *  protected WorldTime2 WORLDTIME;
 *  protected DateTime lastUpdate;
 *  public bool updateRequired;
 *  
 *  public EntityOfType getEntityType()
 */
/* Public Functions & Variables: 
 *  1. Human needs
 *  2. 
 */

/*Purpose: 
 *      To ba a base class for all entities regardless of their type. E.G. Human entity classes inherit this class
 *To Use: 
 *      Place this script onto the ROOT Human gameobject
 *To Do:
 *      Currently there is no way to customise the Human easily. This might be done through a HumanSave however
 */
public class Human : Entity {
    public HumanType entityType;                        //Stores required variables for entity
    public HumanNeeds entityNeeds;                      //Immediate survival needs e.g. food, water, sleep reproduction
    public HumanPsyche psyche;                          //Contains all elements of psyche such as emotions, knowledge, behaviour

    public bool currentlyBusy;                          //If currently in the middle of an action, e.g. swinging an axe, dying hair
    public NavMeshAgent navAgent;                       //Local reference to navAgent, currently public though might be changed to private
    private DynamicCharacterAvatar avatar;              //Local reference to UMA avatar
    private Dictionary<string, DnaSetter> dnaHolder;    //Local reference to an UMA avatars DNA, rarely used but might be needed for stat building, e.g. strength
    private string recipe;                              //String recipe for an UMA avatar, only needed on saving and loading

    private GameObject HUMANROOT;                       //Reference to the Human root gameobject. Might be redundant at this stage however

    //Used to add a listener for UMA
    void OnEnable()
    {
        avatar.CharacterUpdated.AddListener(Updated);
    }
    //Used to remove listener on disable
    void OnDisable()
    {
        avatar.CharacterUpdated.RemoveListener(Updated);
    }
    //Sets the dna holder and gameobject name
    void Updated(UMAData data)
    {
        dnaHolder = avatar.GetDNA();
        gameObject.name = entityType.Name;
    }

    //Loads a human
    public void loadHuman(HumanSave load)
    {
        gameObject.name = load.Name;
        Debug.Log(load.Name);
        gameObject.layer = load.layer;
        gameObject.tag = load.tag;
        Debug.Log("Fully loaded");
        //Load Human and inherited Entity class
        type = load.type;
        entityController = new EntityTaskController(load);
        lastUpdate = load.lastUpdate;

        entityType = new HumanType(load);
        entityNeeds = new HumanNeeds(load);
        psyche = new HumanPsyche(load);
        
        recipe = load.recipe;
        avatar.LoadFromRecipeString(recipe);

        //recipe = load.recipe;
        navAgent.Warp(new Vector3(load.xloc, load.yloc, load.zloc));
        //gameObject.transform.position = new Vector3(load.xloc, load.yloc, load.zloc);
        gameObject.transform.localEulerAngles = new Vector3(load.xrot, load.yrot, load.zrot);

    }
    //Save the human into a file and return the file.
    //This is typically cally from a save manager script
    public HumanSave saveHumanData()
    {
        runUpdate();
        entityType.Name = gameObject.name;
        HumanSave copy = new HumanSave();
        copy.xloc = gameObject.transform.position.x;
        copy.yloc = gameObject.transform.position.y;
        copy.zloc = gameObject.transform.position.z;
        copy.xrot = gameObject.transform.localEulerAngles.x;
        copy.yrot = gameObject.transform.localEulerAngles.y;
        copy.zrot = gameObject.transform.localEulerAngles.z;
        //copy.locationData = gameObject.transform.position;
        //copy.rotationData = gameObject.transform.eulerAngles;
        copy.lastUpdate = lastUpdate;
        copy.recipe = avatar.GetCurrentRecipe();

        copy = entityType.saveHumanData(copy);
        entityNeeds.saveHumanData(ref copy);
        psyche.saveHumanData(ref copy);
        return copy;
    }

    //Sets up a default human
    void Awake()
    {
        Debug.Log("Fully Awake");
        entityType = new HumanType();
        entityNeeds = new HumanNeeds();
        psyche = new HumanPsyche();
        currentlyBusy = false;
        
        avatar = GetComponent<DynamicCharacterAvatar>();
        dnaHolder = new Dictionary<string, DnaSetter>();
        HUMANROOT = null;

        nextUpdate = 0.0f;
        WORLDTIME = GameObject.Find("WorldTime").GetComponent<WorldTime>();
        lastUpdate = WORLDTIME.WORLDTIME;
        updateRequired = true;
        HUMANROOT = gameObject;
        navAgent = gameObject.AddComponent<NavMeshAgent>();
    }

    //This is where all of the NPC processing is done
    void Update()
    {
        nextUpdate += Time.deltaTime;
        if (nextUpdate >= 10.0f || updateRequired)
        {
            runUpdate();
        }
    }
    //Function used to run the update (originally in void update but moved here to enable a last update before saving
    private void runUpdate()
    {
        TimeSpan t = (WORLDTIME.WORLDTIME - lastUpdate);
        int minutesSince = (int)t.TotalMinutes;
        Debug.Log("Hydration: " + entityNeeds.hydration);
        updateRequired = false;

        entityNeeds.updateSurvivalNeeds(minutesSince);
        //do stuff here

        //Guaranteed to do perform entity needs
        if (!currentlyBusy && (entityNeeds.isInNeed()))
        {
            HumanBehaviour.humanNeedsBehaviour(ref HUMANROOT);
        }
        //If not setup to perform standard need/task below
        else { overrideEntityNeeds = true; }

        //Perform standard need/task
        if (overrideEntityNeeds)
        {
            //perform standard task
        }
        overrideEntityNeeds = false;
        lastUpdate = WORLDTIME.WORLDTIME;
        nextUpdate -= 10.0f;
    }
}

/*DISCLAIMER: 
 *        The fact that there are only two genders listed currently is not related to the authors views.
 *        The scope is only limited two two genders at this early stage to focus on other functionality within
 *        the other classes. Gender and Sexuality aspects will be further implemented in time. */
[Serializable]public enum Gender { Male, Female }