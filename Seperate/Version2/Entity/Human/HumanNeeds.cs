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

//
public class HumanNeeds : EntityNeeds {
    public float hydration; private float dehydrationRate;
    public float food;
    //float StomachFullness, //Fat fullness, muscle //excretion		float foodPriority;
    public float sleep; private float sleepLossRate;

    public override void updateSurvivalNeeds(int Minutes)
    {
        base.updateSurvivalNeeds(Minutes);

        //update
        float multiplier = (dehydrationRate / 1440.0f);//1440.0f) 1440 is the number of minutes in a day
        //sleep -= sleepLossRate * multiplier;
        hydration = hydration - (((float)Minutes) * multiplier);
        //Debug.Log(Minutes);
        //hydration -= 10.0f;
        //Debug.Log(hydration);
        checkSurvivalNeeds();
    }
    public override void checkSurvivalNeeds()
    {
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
                                    }
                                }
                                else
                                {
                                    SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 2);
                                    addSurvivalNeed(newTask, false);
                                }
                            }
                            else
                            {
                                SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 3);
                                addSurvivalNeed(newTask, false);
                            }
                        }
                        else
                        {
                            SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 4);
                            addSurvivalNeed(newTask, false);
                        }
                    }
                    else
                    {
                        SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 5);
                        addSurvivalNeed(newTask, false);
                    }
                }
                else
                {
                    SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 6);
                    addSurvivalNeed(newTask, false);
                }
            }
            else
            {
                SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Sleep, 7);
                addSurvivalNeed(newTask, true);
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
                        }
                    }
                    else
                    {
                        SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 2);
                        addSurvivalNeed(newTask, false);
                    }
                }
                else
                {
                    SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 3);
                    addSurvivalNeed(newTask, false);
                }
            }
            else
            {
                SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 4);
                addSurvivalNeed(newTask, false);
            }
        }
        else
        {
            SurvivalTask newTask = new SurvivalTask(SurvivalNeeds.Water, 4);
            addSurvivalNeed(newTask, true);
        }
    }

    public void rehydrated(float amount)
    {
        hydration = hydration + amount;
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
    }
    public HumanNeeds()
    {
        survivalTasks = new List<SurvivalTask>();
        hydration = 100.0f; dehydrationRate = 33.0f;
        food = 100.0f;
        sleep = 100.0f;
    }
}
