using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA;
using UMA.CharacterSystem;

// Created by Connor Chamberlain on 27/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      Everything
 */

/*Purpose: 
 *      This file is used to save everything about the human npc. All npc data within the human file is exported to this HumanSave file for storage
 *      externally (serialized). This file can then be deserialized and used to load the saved human.
 *To Use: 
 *      Simply create an instance of this file and call the save function in the Human class by providing the instance as a parameter
 *      (Funny note to self, forgot the damn word parameter for a minute hahahahaha, how embarassing)
 *To Do: 
 *      Double check all necessary data from class and inherited classes is saved (minus unnecessary items, eg navAgent link, WorldTime Link)
 *      default init function needs to be fully fleshed out also.
 *      Might want to look into a random npc generator in seperate script
 */
//[CreateAssetMenu(menuName = "HumanNPC")]
[Serializable]
public class HumanSave {
    //GameObject data
    //Name is saved under entity type
    public int layer;       //The layer the human is on, 0 by default
    public string tag;      //Tag of gameobject
        //The Transforms location and Rotation data as floats (Vector3 was not serializable)
    public float xloc;
    public float yloc;
    public float zloc;

    public float xrot;
    public float yrot;
    public float zrot;

    //Asset: Unity Multi-purpose Avatar 2
    public string recipe;       //Used for uma data such as DNA, wardrobe slots, skin colour, etc

    //Entity
    public EntityOfType type;
    public float nextUpdate;
    public DateTime lastUpdate;
    public bool updateRequired;

    //Entity Task Controller
    public List<taskNode> taskBacklog;
    public List<taskNode> reactiveContainer;
    public taskNode currentTask;    

    //EntityType
    public string Name;
    public Gender gender;
    public DateTime bedTime;
    public DateTime wakeUpTime;

    //Psyche
    //Emotions
    public float Sadness_Joy;
    public float SadnessMod;
    public float JoyMod;

    public float Anticipation_Surprise;
    public float AnticipationMod;
    public float SurpriseMod;

    public float Disgust_Trust;
    public float DisgustMod;
    public float TrustMod;

    public float Fear_Anger;
    public float FearMod;
    public float AngerMod;
    //HumanSpecific
    public float SJLower; public float SJLowerLimit;
    public float SJUpper; public float SJUpperLimit;

    public float ASLower; public float ASLowerLimit;
    public float ASUpper; public float ASUpperLimit;

    public float DTLower; public float DTLowerLimit;
    public float DTUpper; public float DTUpperLimit;

    public float FALower; public float FALowerLimit;
    public float FAUpper; public float FAUpperLimit;

    public int setStage;

    //Knowledge

    //Needs
    public List<SurvivalTask> survivalTasks;
    public float hydration;
    public float food;
    public float sleep;

    //Default NPC
    public HumanSave()
    {
        layer = 0;
        Name = "Veronica";
        tag = "NPC";
        xloc = 0.0f;
        yloc = 0.0f;
        zloc = 0.0f;
        xrot = 0.0f;
        yrot = 0.0f;
        zrot = 0.0f;

        type = EntityOfType.Human;
    
        taskBacklog = new List<taskNode>();
        reactiveContainer = new List<taskNode>();
        currentTask = new taskNode(Noun.invalid, 999);
        nextUpdate = 0.0f;
        lastUpdate = new DateTime();
        updateRequired = false;
        gender = Gender.Female;

        

        Sadness_Joy = 50.0f;
        SadnessMod = 0.0f;
        JoyMod = 0.0f;

        Anticipation_Surprise = 50.0f;
        AnticipationMod = 0.0f;
        SurpriseMod = 0.0f;

        Disgust_Trust = 50.0f;
        DisgustMod = 0.0f;
        TrustMod = 0.0f;

        Fear_Anger = 50.0f;
        FearMod = 0.0f;
        AngerMod = 0.0f;

        SJLower = 0.0f;     SJLowerLimit = 0.0f;
        SJUpper = 0.0f;     SJUpperLimit = 100.0f;

        ASLower = 0.0f;     ASLowerLimit = 0.0f;
        ASUpper = 0.0f;     ASUpperLimit = 100.0f;

        DTLower = 0.0f;     DTLowerLimit = 0.0f;
        DTUpper = 0.0f;     DTUpperLimit = 100.0f;

        FALower = 0.0f;     FALowerLimit = 0.0f;
        FAUpper = 0.0f;     FAUpperLimit = 100.0f;

        setStage = 0;
    }
}
