using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 08/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      public void addSurvivalNeed(SurvivalTask task, bool remove)
 *      public SurvivalTask needOnList()
 *      public SurvivalTask needOnList(SurvivalTask task)
 *      public bool isInNeed()
 * Overridable: 
 *      public virtual void updateSurvivalNeeds(int Minutes)
 *      public virtual void checkSurvivalNeeds()
 *      
 * EXTERNAL DATA
 *      public struct SurvivalTask { SurvivalNeeds need, int priority }
 *      public enum SurvivalNeeds       (MUST CONTAIN ALL POSSIBLE SURVIVAL NEEDS, FOOD, BATTERY POWER, FORCE POINTS, ETC)
 */

/*Purpose: 
 *      To store all of the survival needs of the entity
 *To Use: 
 *      Entity needs should inherit this class
 *To Do: 
 *      Further planning
 * 
 *More details on this class: 
 * 1. It checks the creatures needs such as energy for a robot or
 *      water and food for a human. It decreses them incrementally
 *      as these reserves are used over time.
 * 2. If the entity is low on these survival needs then it adds the
 *      need as a task to entityTaskController to handle.
 */
public class EntityNeeds : ScriptableObject {
    protected List<SurvivalTask> survivalTasks;             //Holds a list of all the tasks of basic survival needs, filtered by importance

    //Adds an item to the survivalTasks, to remove an item set remove to TRUE
    public void addSurvivalNeed(SurvivalTask task, bool remove)
    {
        int count = survivalTasks.Count;        //Local storage for number of survival tasks

        //Remove if already contained
        for (int i = 0; i < count; i++)
        {
            if (survivalTasks[i].need == task.need)
            {
                survivalTasks.RemoveAt(i);
            }
        }
        //If the user is intending to add the task
        if (!remove)
        {
            //Check if it is empty, then just add it
            if (count == 0)
            {
                survivalTasks.Add(task);
            }
            //Add task in correct place
            for (int i = 0; i < count; i++)
            {
                //If the priorities are equal, prioritise by survivalNeed order (lowest number more important)
                if (survivalTasks[i].priority == task.priority)
                {
                    if ((int)survivalTasks[i].need < (int)task.need)
                    {
                        survivalTasks.Insert(i, task);
                        i = count + 1;
                    }
                }
                //Add task if it is more important, (lower priority number)
                else if (survivalTasks[i].priority > task.priority)
                {
                    survivalTasks.Insert(i, task);
                    i = count + 1;
                }
                //Should the end of the tasks list be reached add it at the end due to it being of the least importance
                else if (i == count -1)
                {
                    survivalTasks.Add(task);
                }
            }
        }
    }
    //More important tasks (lower number on priority) come first, i.e. at [0]
    public SurvivalTask needOnList()
    {
        if (survivalTasks.Count > 0)
        {
            return survivalTasks[0];
        }
        return new SurvivalTask(SurvivalNeeds.Empty, 10);
    }
    //Overload function to check if a specific need is on the list
    public SurvivalTask needOnList(SurvivalTask task)
    {
        int count = survivalTasks.Count;
        for (int i = 0; i < count; i++)
        {
            if (survivalTasks[i].need == task.need)
            {
                return survivalTasks[i];
            }
        }
        return new SurvivalTask(SurvivalNeeds.Empty, 10);
    }
    //Checks if the list is empty
    public bool isInNeed()
    {
        if (survivalTasks.Count > 0)
        {
            return true;
        }
        return false;
    }

    //### Overridable functions for derived classes ###//

    //Updates variables to show degredation/reduction/use
    public virtual void updateSurvivalNeeds(int Minutes)
    {

    }
    //Checks the values against thresholds
    public virtual void checkSurvivalNeeds()
    {
    }
}

//A data structure which is used to save tasks that need addressing (ALSO FULLY SERIALIZABLE FOR SAVING ENTITY STATES)
[Serializable]
public struct SurvivalTask
{
    public SurvivalNeeds need;              //The particular need of the entity, E.G. water, food, sleep
    public int priority;

    //Initialiser for survival task
    //Accepts the particular need (eg water) and the priority of the need (eg 4: not serious, 1: IM DYING OF THIRST)
    public SurvivalTask(SurvivalNeeds Need, int Priority)
    {
        need = Need;
        priority = Priority;
    }
}

//List of ALL the types of needs across all entity types
//List is in DESCENDING ORDER OF IMPORTANCE
//From above currently no conflict handling for varying types, Maybe e.g. water and water1 might help
[Serializable] public enum SurvivalNeeds {Water, Sleep, Food, Empty}

/*public enum MaslowsHierarchy
{
    UltimateOverride = 0,
    DirectThreat = 1,
    FirstLevelOverride = 10,
    Excretion = 11,
    Water = 12,
    Food = 13,
    Sleep = 14,
    Clothing = 15,
    Warmth = 16,
    Shelter = 17,

    SecondLevelOverride = 20,
    Security = 21,
    Safety = 22,
    Employment = 23,
    Resources = 24,
    Health = 25,
    Property = 26,

    ThirdLevelOverride = 30,
    Friends = 31,
    Relationship_Intimacy = 32,
    Family = 33,

    FourthLevelOverride = 40,
    Respect = 41,
    Self_Esteem = 42,
    Status = 43,
    Strength = 44,
    Freedom = 45,
    Confidence = 46,
    Achievement = 47,

    FifthLevelOverride = 50,
    Life_Mission = 51
}*/

