using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 11/04/2019  (However replaced earlier file).
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

/*Purpose: 
 *      To handle the default behaviours needed for a humans survival
 *To Use: 
 *      TBD
 *To Do:
 *      Handle resetting of entities between behaviours
 */
public static class Behaviour_HumanNeeds
{

    public static void handleStarvation(ref Human human, bool stopSignal)
    {

    }
    public static void handleSleep(ref Human human, bool stopSignal)
    {

        Debug.Log("Human->HumanBehaviour(STATIC)->behaviour_needs(STATIC)-><color=yellow>handleSleep():</color>\n        <color=green>Begin sleep behaviour</color>");
        //Check if its just a standard time to sleep
        /*if (human.entityType.isBedTime(human.getTime()) && stopSignal == false)
        {
            //checks if there is a more important task
            if (human.entityController.currentTask.priority < human.entityNeeds.getNeedPriority(SurvivalNeeds.Sleep))
            {
                Debug.Log(human.entityController.currentTask.priority);
                human.overrideEntityNeeds = true;
                return;
            }
            //else it is time to sleep
            else
            {
                ActionContainer temp = human.currentAction;
                //check if they havent begun moving there, not currently thought of bed and not sleeping
                if ((temp.article != Noun.bed))// && temp.action != PresentVerb.travelling)
                {
                    //set nav agents destination
                    human.navAgent.SetDestination(human.entityNeeds.currentSettlement.GetComponent<SettlementController>().getBedLocation());
                    human.currentAction.setAction(PresentVerb.travelling);
                    human.currentAction.setArticle(Noun.bed);
                }
                //they are moving, check if they are there
                if (temp.action == PresentVerb.travelling && temp.article == Noun.bed)
                {
                    //checks when the entity is at their destination
                    if (human.navAgent.remainingDistance < 1f)//navAgent at destination
                    {
                        human.currentAction.setAction(PresentVerb.sleeping);
                        human.updateRequired = true;
                        //animation to go to bed
                    }
                }
                //they are there, begin sleep
                if (temp.action == PresentVerb.sleeping)
                {
                    if (human.entityType.isTimeToWakeUp(human.getTime()))
                    {
                        human.currentAction.setAction(PresentVerb.idling);
                        human.currentAction.setArticle(Noun.invalid);
                        //Time to wake up
                        human.entityNeeds.sleep = 100.0f;
                        human.updateRequired = true;
                        //animation to wake up
                        human.navAgent.SetDestination(new Vector3(-100f, 10f, 0f));
                    }
                }
            }

            //human.entityType.is
        }
        else if (stopSignal == true)
        {
            ActionContainer temp = human.currentAction;
            //Is travelling to bed
            if (temp.action == PresentVerb.travelling && temp.article == Noun.bed)
            {
                human.navAgent.isStopped = true;
                human.currentAction.action = PresentVerb.idling;
            }
            //if sleeping
            else if (temp.action == PresentVerb.sleeping && temp.article == Noun.bed)
            {
                //wake up
                human.currentAction.action = PresentVerb.idling;
            }
        }
        //Check if critical sleep depravation*/
        Debug.Log("Human->HumanBehaviour(STATIC)->behaviour_needs(STATIC)-><color=yellow>handleSleep():</color>\n        <color=green>End sleep behaviour</color>");
    }
    public static void handleHydration(ref Human human, bool stopSignal)
    {
        Debug.Log("Human->HumanBehaviour(STATIC)->behaviour_needs(STATIC)-><color=yellow>handleHydration()</color>\n        <color=green>Begin hydration behaviour</color>");
        /*Behaviour plan
         * entity is not doing anything at this time 
         *      then they can drink
         * entity has a thirst but is currently busy
         *      ignore thirst
         * entity has a thirst that is more important than current task
         *      override current task and drink
         */
        ActionContainer temp = human.currentAction;
        //not doing anything
        /*if (temp.article != Noun.water && temp.action == PresentVerb.idling)
        {
            if (temp.action == PresentVerb.idling)
            {
                //go to water source and drink if currently no water in inventory
                GameObject watersource = human.entityNeeds.currentSettlement.
                    GetComponent<SettlementController>().getClosestWaterSource(human.gameObject.transform.position);
                human.navAgent.SetDestination(watersource.transform.position);
                human.currentAction = new ActionContainer(PresentVerb.travelling, Noun.water);
            }
        }
        else if (temp.article == Noun.water)
        {
            if (temp.action == PresentVerb.travelling)
            {
                //travelling, check if at destination
                if(human.navAgent.isStopped == true)
                {
                    human.currentAction = new ActionContainer(PresentVerb.drinking, Noun.water);
                }
            }
            else if (temp.action == PresentVerb.drinking)
            {
                //has drunk water, back to normal
                human.entityNeeds.hydration = 100.0f;
                human.currentAction = new ActionContainer(PresentVerb.idling, Noun.invalid);
            }
        }
        /* /is doing something however is not in the middle of an action
        else if (human.currentlyBusy == false)
        {

        }
        //Is drinking more important than current task
        else if (human.entityController.currentTask.priority < human.entityNeeds.getNeedPriority(SurvivalNeeds.Water))
        {
            //Send stop task signal
            //Drink
            //Then resume

        }
        //currently busy, do nothing* /
        else
        {
            human.overrideEntityNeeds = true;
        }*/
        Debug.Log("Human->HumanBehaviour(STATIC)->behaviour_needs(STATIC)-><color=yellow>handleHydration()</color>\n        <color=green>End hydration behaviour</color>");
    }
}
