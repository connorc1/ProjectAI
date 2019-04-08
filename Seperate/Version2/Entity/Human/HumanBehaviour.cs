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

//
public static class HumanBehaviour {
    public static void humanNeedsBehaviour(ref GameObject entity)
    {
        Human holder = entity.GetComponent<Human>();
        switch (holder.entityNeeds.needOnList().need)
        {
            case SurvivalNeeds.Food:
                break;
            case SurvivalNeeds.Water:
                holder.entityNeeds.rehydrated(5.0f);
                Debug.Log(holder.entityNeeds.hydration);
                holder.navAgent.destination = new Vector3(0, 10, 0);
                break;
            case SurvivalNeeds.Sleep:
                holder.entityNeeds.sleep = 100.0f;
                break;
        }
    }
}
