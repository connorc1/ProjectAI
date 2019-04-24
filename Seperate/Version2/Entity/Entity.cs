using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Created by Connor Chamberlain on 09/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      public EntityTaskController entityController;
 *      public bool updateRequired;
 *      public EntityOfType getEntityType()
 *      public DateTime getTime()
 */

/*Purpose: 
 *      To ba a base class for all entities regardless of their type. E.G. Human entity classes inherit this class
 *To Use: 
 *      When creating entities inherit this class.
 *To Do: 
 *      Further planning is still required for this file and derived classes
 *      Remove scribbled notes from this file
 *      Try to implement more efficient version of overrideEntityNeeds
 *      Neaten up template update function
 */
public class Entity : MonoBehaviour {
    protected EntityOfType type;                            //Easy access to entity type    Get
    public EntityTaskController entityController;           //Entity tasks, will likely need to be accessed from outside scripts (this might change though)
    public ActionContainer currentAction;                   //Container used to store the entities current action
    //public EntityBehaviour entityBehaviour;           //Probably needs to be moved to within psyche (emotions inc), then list of reference STATIC entityBehaviours
    //then use setstage int within psyche to hold behaviour position within function, eg making tea, stage 150 add hot water to cup(prev stage added teabag)
    //Also have behaviourstruct which contains the specific behaviour type and int for strength (eg raider, 100), to allow for strong or weak association to behaviour

    protected float nextUpdate;                             //Used to delay the update in void Update() to save processing power
    protected WorldTime WORLDTIME;                          //Local link to the world time for easy access
    protected DateTime lastUpdate;                          //The last time the entity was updated
    public bool updateRequired;                             //Boolean value to trigger entity updates when they are needed. Public for external scripts to trigger
    public bool overrideEntityNeeds;// { get; set; }        //Used in entity main class for switching from survival needs update to task needs update

    /*Purpose:
     *      To make the type of entity accessible to external classes. E.G. is this entity a fish or a dog...
     */
    public EntityOfType getEntityType()
    {
        return type;
    }
    //Method for derived classes and contained instances to get the world time
    public DateTime getTime()
    {
        return WORLDTIME.WORLDTIME;
    }

    //A copy of the update function. This cannot be inherited so a copy of this must be implemented in the derived class
    /*void Update()
    {
        if (nextUpdate >= 10.0f || updateRequired)
        {
            updateRequired = false;

            //do stuff here
            /*if (checkBasicNeeds()) 
             * {handleBasicNeeds()}     //This sets the NPC's action to
             *                          take care of this need, e.g. drink
             *                          //Call to EntityNeeds
             * else {perform normal task}  //This is the default case
             *                          //Call to EntityTaskController
             * /

            lastUpdate = WORLDTIME.WORLDTIME;
            nextUpdate -= 10.0f;
        }
    }*/
}
