using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 04/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      public List<taskNode> taskBacklog;
 *      public List<taskNode> reactiveContainer;    
 *      public taskNode currentTask;
 *        
 *      public void pushTask(taskNode task)
 *      public void completeTask()
 *      public EntityTaskController()
 *      public EntityTaskController(HumanSave load)
 *        
 * EXTERNAL DATA
 *      public struct taskNode
 */

/*Purpose: 
 *      Storage for all of the tasks that the entity will perform
 *To Use: 
 *      Main class should contain an instance of this class
 *To Do:
 *      Further planning, especially when looking in to environmental perception (quite valuable for this AI)
 *      Check spelling of persuing (chasing if spelling is absolutely butchered)
 *      Reactive environmental perceptions, e.g. see bag of gold on floor, or mug flying at ones face
 *      Seperate part of update function for reactive items to allow constant processing
 *      The humanSave version init should be in inherited class
 *      Look into taskNodes Vector3 serialization issue and fix clash (conversion function to save)
 *      Comment taskNode
 *      
 *More Details on file: 
 * 1. This is where all of the tasks related to the entity
 *      are stored. As a task comes in it is added to the 
 *      list and removed once handled.
 * 2. 
 * Note. Stack implementation of task backlog should suffice, may need more advances implementation for edge cases
 *      Must coordinate with entity behaviour
*/
public class EntityTaskController : MonoBehaviour {
    public List<taskNode> taskBacklog;          //Holds all of the tasks the entity has in memory however isnt currently persuing, not sorted by priority (STACK IMPLEMENTATION)
    public List<taskNode> reactiveContainer;    //Current implementation of reactive environmental perceptions, this list requires constant processing
    public taskNode currentTask;                //The current task the entity is actively persuing, -1 task identifier for empty

    //Pushes a task onto either currentTask or taskBacklog depending on priority
    public void pushTask(taskNode task)
    {
        //current task is not empty (-1 means empty)
        if (currentTask.taskIdentifier != Noun.invalid)
        {
            //not as important as current task
            if (task.priority < currentTask.priority)
            {
                taskBacklog.Add(task);
            }
            //more important
            else
            {
                taskBacklog.Add(currentTask);
                currentTask = task;
            }
        }
        //No tasks currently
        else
        {
            currentTask = task;
        }
        
    }

    //Current task has been completed, get next task if there are any (LIFO)
    public void completeTask()
    {
        //There are tasks in backlog
        if(taskBacklog.Count > 0)
        {
            //Returns the most recently added task
            int lastTask = (taskBacklog.Count - 1);
            currentTask = taskBacklog[lastTask];
            taskBacklog.RemoveAt(lastTask);
        }
        //Completed all tasks, none in backlog
        else
        {
            taskNode copy = new taskNode(Noun.invalid, 999);
            currentTask = copy;
        }
    }

    //Init function for brand new task controller
    public EntityTaskController()
    {
        taskBacklog = new List<taskNode>();
        reactiveContainer = new List<taskNode>();
        currentTask = new taskNode(Noun.invalid, 999);
    }

    //Init function for task controller using data, (loading old task controller)
    public EntityTaskController(HumanSave load)
    {
        taskBacklog = load.taskBacklog;
        reactiveContainer = load.reactiveContainer;
        currentTask = load.currentTask;
    }
}

[Serializable]
public class taskNode
{
    public Noun taskIdentifier; //Negative one is empty
    private float xval;
    private float yval;
    private float zval;
    //public float distanceToTarget;
    public int priority;

    public taskNode(Noun ID, int PRIORITY)
    {
        taskIdentifier = new int();
        taskIdentifier = ID;
        priority = new int();
        priority = PRIORITY;
        xval = new int();
        yval = new int();
        zval = new int();
    }
    public void assignTarget(Vector3 Target)
    {
        xval = Target.x;
        yval = Target.y;
        zval = Target.z;
    }
    public Vector3 getTarget()
    {
        return new Vector3(xval, yval, zval);
    }
}