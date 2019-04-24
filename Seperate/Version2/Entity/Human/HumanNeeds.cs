using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 08/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 *      protected List<SurvivalTask> survivalTasks;
 *      
 *      public virtual void updateSurvivalNeeds(int seconds)
 *      public virtual void checkSurvivalNeeds()
 *      public virtual void addSurvivalNeed(SurvivalTask task, bool remove)
 */
/* Public Functions & Variables: 
 *      public void addSurvivalNeed(SurvivalTask task, bool remove)
 *      public SurvivalTask needOnList()
 *      public SurvivalTask needOnList(SurvivalTask task)
 *      public bool isInNeed()
 *      
 *      public override void updateSurvivalNeeds(int Minutes)
 *      public override void checkSurvivalNeeds()
 */

/*Purpose: 
 *      To handle all of a humans survival needs. 
 *To Use: 
 *      TBD
 *To Do:
 *      Food, including stomach, fat, and muscle eating in starvation.
 *      Finalise Water
 *      Sleep
 *      Behaviours for all survival needs
 *      Unique decrement for usage, e.g. intense exercise decreases food and water at a faster rate
 *          //Perhaps get the delta time of extreme exercise and multiply it within here
 */
public class HumanNeeds : EntityNeeds {
    //Water Variables
    public float hydration; private float dehydrationRate;

    //Food Variables
    public float food;
    //float StomachFullness, //Fat fullness, muscle //excretion		float foodPriority;

    //Sleep Variables
    public float sleep; private float sleepLossRate;

    //Settlement Variable   public GameObject Shelter
    public GameObject currentSettlement;
    public GameObject currentHouse;

    //Decrements the survival needs with use over time, not considering faster or slower decrements
    public override void updateSurvivalNeeds(int Minutes)
    {
        base.updateSurvivalNeeds(Minutes);
        Debug.Log("Human->Needs-><color=yellow>updateSurvivalNeeds():</color> \n<color=green>    updating survival needs</color>", this);
        if(Minutes < 0)
        {
            Minutes = 0;
        }
        //update
        float multiplier = (((float)Minutes) / 1440.0f) * 8;         //1440 is the number of minutes in a day, get multiplier for minutes
        sleep = sleep - (sleepLossRate * multiplier);
        hydration = hydration - (dehydrationRate * multiplier);

        Debug.Log("Human->Needs-><color=yellow>updateSurvivalNeeds():</color><color=blue> STATUS  \n    Minutes Modifier: " + Minutes + "\tHydration: " + hydration + "\tSleep: " + sleep + " </color> ", this);
        checkSurvivalNeeds();
        Debug.Log("Human->Needs-><color=yellow>updateSurvivalNeeds():</color> \n<color=green>    Completed survival needs</color>", this);
    }

    //Checks if any of the needs has passed any thresholds
    public override void checkSurvivalNeeds()
    {
        Debug.Log("Human->Needs->updateSurvivalNeeds()-><color=yellow>CheckSurvivalNeeds():</color>\n    <color=green>Checking survival thresholds</color>", this);
        if (sleep <= 90.0f)
        {
            if (sleep <= 85.0f)
            {
                if (sleep <= 79.0f)
                {
                    if (sleep <= 70.0f)
                    {
                        if (sleep <= 55.0f)
                        { 
                            if (sleep <= 50.0f)
                            {
                                if (sleep <= 35.0f)
                                {
                                    if (sleep <= 0.0f)
                                    {
                                        // DEATH!!!! KILL PLAYER
                                    }
                                    else
                                    {
                                        SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 1);
                                        addSurvivalNeed(newTask, false);
                                        Debug.Log("            <color=orange>ADD NEED: Priority 1 (sleep)</color>", this);
                                    }
                                }
                                else
                                {
                                    SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 2);
                                    addSurvivalNeed(newTask, false);
                                    Debug.Log("            <color=orange>ADD NEED: Priority 2 (sleep)</color>", this);
                                }
                            }
                            else
                            {
                                SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 3);
                                addSurvivalNeed(newTask, false);
                                Debug.Log("            <color=orange>ADD NEED: Priority 3 (sleep)</color>", this);
                            }
                        }
                        else
                        {
                            SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 4);
                            addSurvivalNeed(newTask, false);
                            Debug.Log("            <color=orange>ADD NEED: Priority 4 (sleep)</color>", this);
                        }
                    }
                    else
                    {
                        SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 5);
                        addSurvivalNeed(newTask, false);
                        Debug.Log("            <color=orange>ADD NEED: Priority 5 (sleep)</color>", this);
                    }
                }
                else
                {
                    SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 6);
                    addSurvivalNeed(newTask, false);
                    Debug.Log("            <color=orange>ADD NEED: Priority 6 (sleep)</color>", this);
                }
            }
            else
            {
                SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 7);
                addSurvivalNeed(newTask, false);
                Debug.Log("            <color=orange>ADD NEED: Priority 7 (sleep)</color>", this);
            }
        }

        //Update Hydration
        if (hydration <= 95.0f)
        {
            if (hydration <= 74.0f)
            {
                if (hydration <= 66.0f)
                {
                    if (hydration <= 33.0f)
                    {
                        if (hydration <= 0.0f)
                        {
                            //death
                        }
                        else
                        {
                            SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 1);
                            addSurvivalNeed(newTask, false);

                            Debug.Log("            <color=orange>ADD NEED: Priority 1 (water)</color>", this);
                        }
                    }
                    else
                    {
                        SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 2);
                        addSurvivalNeed(newTask, false);

                        Debug.Log("            <color=orange>ADD NEED: Priority 2 (water)</color>", this);
                    }
                }
                else
                {
                    SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 3);
                    addSurvivalNeed(newTask, false);

                    Debug.Log("            <color=orange>ADD NEED: Priority 3 (water)</color>", this);
                }
            }
            else
            {
                SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 4);
                addSurvivalNeed(newTask, false);
                Debug.Log("            <color=orange>ADD NEED: Priority 4 (water)</color>", this);
            }
        }
        Debug.Log("Human->Needs->updateSurvivalNeeds()-><color=yellow>CheckSurvivalNeeds():</color>\n    <color=green>Completed survival thresholds</color>", this);

    }

    //Removes an item from the survivalTasks if it is contained
    public void metSurvivalNeed(SurvivalNeeds need)
    {
        int count = survivalTasks.Count;

        if (count > 0)
        {
            for (int i = 0; i < count; i++)
            {
                if (survivalTasks[i].need == need)
                {
                    survivalTasks.RemoveAt(i);
                    i = count;
                }
            }
        }
        checkSurvivalNeeds();
    }

    //Used externally
    //Amount metric is to be determined
    public void rehydrated(float amount)
    {
        hydration = hydration + amount;
        metSurvivalNeed(SurvivalNeeds.Water);
    }

    public void saveHumanData(ref HumanSave save)
    {
        save.survivalTasks = survivalTasks;
        save.hydration = hydration;
        save.food = food;
        save.sleep = sleep;
    }
    public HumanNeeds(HumanSave load)
    {
        survivalTasks = load.survivalTasks;
        hydration = load.hydration;
        dehydrationRate = 33.33f;
        food = load.food;
        sleep = load.sleep;
        sleepLossRate = 14.3f;
        SettlementController temp = FindObjectOfType(typeof(SettlementController)) as SettlementController;
        currentSettlement = temp.gameObject;
    }
    public HumanNeeds()
    {
        survivalTasks = new List<SurvivalTask>();
        hydration = 100.0f; dehydrationRate = 33.0f;
        food = 100.0f;
        sleep = 100.0f; sleepLossRate = 14.3f;
        SettlementController temp = FindObjectOfType(typeof(SettlementController)) as SettlementController;
        currentSettlement = temp.gameObject;
    }
}
