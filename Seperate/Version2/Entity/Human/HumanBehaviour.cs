using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 08/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 */
/* Public Functions & Variables: 
 *
 */

/*Purpose: 
 *      A base human behaviour script. All (or most) behaviours will be routed through here to coresponding behaviour scripts
 *To Use: 
 *      TBD
 *To Do: 
 *      Fill with behaviours, plan behaviour structs, idling, etc
 */
public static class HumanBehaviour {
    public static void humanNeedsBehaviour(ref GameObject entity)
    {
        Human holder = entity.GetComponent<Human>();
        Debug.Log("Human-><color=yellow>Behaviour(STATIC):</color>\n    <color=green>Begin humanBehaviour for needs</color>");
        switch (holder.entityNeeds.needOnList().need)
        {
            case SurvivalNeeds.Food:
                Debug.Log("Human->HumanBehaviour(STATIC)->behaviour_needs->handleStarvation\n        <color=green>Begin</color>");
                Behaviour_HumanNeeds.handleStarvation(ref holder, false);
                Debug.Log("Human->HumanBehaviour(STATIC)->behaviour_needs->handleStarvation\n        <color=green>End</color>");
                break;
            case SurvivalNeeds.Water:
                Behaviour_HumanNeeds.handleHydration(ref holder, false);
                break;
            case SurvivalNeeds.Sleep:
                Behaviour_HumanNeeds.handleSleep(ref holder, false);
                break;
        }
        Debug.Log("Human-><color=yellow>Behaviour(STATIC):</color>\n    <color=green>Completed humanBehaviour for needs</color>");
    }
}

/*Behaviour format
 * Does the character have everything they can think of to perform the behaviour
 * Special needs to wait
 * Are they in an appropriate spot to perform behaviour, if not travel
 * Once at destination perform action
 */