using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *Central Component of the MVC. Is the dynamic data structure, independent of the viewable behaviour
 *directly manages data, logic, and the rules of the application
 */

//A node used within a list. This is used to setup npc behaviour giving them a task to work towards.
public struct taskNode
{
	public int taskIdentifier;		//A unique ID for the task such as water, clothing, shelter, a quest item, etc
	public Vector3 target;			//If the target's location is known it is stored here
	//public float distanceToTarget;
	public int priority;			//Priority level of the task, e.g. such as a luxury table vs shelter from a nuclear blast and the fallout.

	//Init function
	public taskNode(int ID, int PRIORITY) 
	{
		taskIdentifier = new int();
		taskIdentifier = ID;
		target = new Vector3 ();
		priority = new int();
		priority = PRIORITY;
	}
	//Assigning a location once it is known which is not always the case upon receiving the task.
	public void assignTarget(Vector3 Target)
	{
		target = Target;
	}
}

//Contains an array (might need changing to a list) for tasks which the npc is given.
public struct taskContainer
{
	public taskNode[] pro_activeTasks;		//Task list which stores tasks the NPC is actively trying to complete.
	public int pro_activeCount;
	public taskNode[] re_activeTasks;		//Task list for items which the npc notices going about their business, e.g. accepting a free sample of fudge while on their way back from work.
	public int re_activeCount;

	//Init function for the lists
	public taskContainer(int size)
	{
		pro_activeTasks = new taskNode[size];
		pro_activeCount = new int();
		pro_activeCount = 0;
		re_activeTasks = new taskNode[size];
		re_activeCount = new int ();
		re_activeCount = 0;
	}

	//Gets and returns the position of a task within a list and returns -1 on fail.
	public int taskIndexP(int taskId)
	{
		for (int i = 0; i > pro_activeCount; i++)
		{
			if (pro_activeTasks[i].taskIdentifier == taskId)
			{
				return i;
			}
		}
		return -1;
	}

	//Adds a task to the pro-active list
	public void addToPTask(taskNode toAdd)
	{
		taskNode[] copy = new taskNode[10];
		copy = pro_activeTasks;
		int count = 0;
		bool added = false;
		for (int i = 0; i < pro_activeCount; i++)
		{
			if (toAdd.taskIdentifier == pro_activeTasks[i].taskIdentifier)
			{
				removeFromPTask (toAdd.taskIdentifier);
			}
		}
		if (pro_activeCount == 0)
		{
			pro_activeTasks [0] = toAdd;
			pro_activeCount++;
		}
		for (int i = 0; i < pro_activeCount; i++)
		{
			if (!added) {
				if (toAdd.priority == copy [i].priority) {
					if (toAdd.taskIdentifier < copy [i].taskIdentifier) {
						pro_activeTasks [count] = toAdd;
						count++;
						pro_activeCount++;;
						added = true;
					}
				} else if (toAdd.priority < copy [i].priority) {
					pro_activeTasks [count] = toAdd;
					count++;
					pro_activeCount++;
					added = true;
				}
			}
			pro_activeTasks[count] = copy[i];
			count++;
		}
	}

	//Removes from the pro-active list
	public void removeFromPTask (int taskID)
	{
		taskNode[] copy = new taskNode[10];
		//copy = pro_activeTasks;
		int count = 0;
		bool found = false;
		for(int i = 0; i < pro_activeCount; i++)
		{
			if (pro_activeTasks[i].taskIdentifier == taskID || found)
			{
				if (found)
				{
					copy [count] = pro_activeTasks [i];
				}
				else
				{
					found = true;
					pro_activeCount--;
				}
			}
			else
			{
				copy [count] = pro_activeTasks [i];
				count++;
			}
		}
		pro_activeTasks = copy;
	}

	//Confirms if an item is not in the list as a boolean value for if statements
	public bool isNotInList(int taskID)
	{
		foreach(taskNode i in pro_activeTasks)
		{
			if (i.taskIdentifier == taskID)
			{
				return false;
			}
		}
		return true;
	}
		
}


//################################################################################################
public class NPCModel : MonoBehaviour {
	public taskContainer taskList; 		//A local copy of the tasklist
	public bool currentlyBusy;			//Boolean value to prevent action overlaying. e.g. Not drinking water while in the middle of an axe swing.

//First level needs
	public float sleep; public float sleepLossRate;//public float sleepSubstitute; 							
	public float hydration; public float dehydrationRate;
	//float StomachFullness, //Fat fullness, muscle //excretion		float foodPriority;
	public bool wearingClothing;
	public bool warmEnough;
	public bool hasShelter;
	public void energyExpenditure(int MINUTES)
	{
		//Minutes in a day
		float multiplier = MINUTES / 1440.0f;
		sleep -= sleepLossRate * multiplier;
		hydration -= dehydrationRate * multiplier;
	}

//Second level needs
	bool isEmployed;
	public bool timeToGoToWork;
	public Vector3 workPlaceLocation;
//Third level needs

//Fourth level needs


//Fifth level
	public bool hasLifeMission;


//Rest of class
	void Awake()
	{
		sleepLossRate = 25.0f;
		dehydrationRate = 33.0f;
		taskList = new taskContainer (10);
		taskList.pro_activeTasks = new taskNode[10];
		hasLifeMission = false;
		currentlyBusy = false;
		isEmployed = false;
		wearingClothing = false;
		warmEnough = false;
		hasShelter = false;
	}

	//Cycles through maslows hierarchy and adds the next need to the list. NEEDS LOTS MORE WORK.
	public void MHNCycle()
	{
		//First Level
				//Water, food, and sleep are handled by the Controller
		if (!wearingClothing && taskList.isNotInList(15))
		{
			taskNode newTask = new taskNode (15, 4);
			taskList.addToPTask (newTask);
		}
		else if (!warmEnough && taskList.isNotInList(16))
		{
			taskNode newTask = new taskNode (16, 4);
			taskList.addToPTask (newTask);
		}
		else if (!hasShelter && taskList.isNotInList (17))
		{
			taskNode newTask = new taskNode (17, 4);
			taskList.addToPTask (newTask);
		}
		//Second Level
		else if (!isEmployed) {
			//Get Job
		}

		//Third Level
		//Fourth Level
		//Fifth Level
		if (hasLifeMission == false)
		{
			taskNode newTask = new taskNode (51, 4);
			taskList.addToPTask (newTask);
			hasLifeMission = true;
		}
	}
}
/*
 * PRIORITY LEVELS
 * 0. Magical Override, MUST DO no matter the cost to self or others	E.G. sacrificing self for children, let them drink or eat first
 * 1. Reserved for immediate threats of death							E.G. Dying of Dehydration
 * 2. Face death without it, must get very soon. Typ					E.G. Will take food and water location over just foood (if also hungry), even if further away
 * 3. Takes priority over most other needs								E.G. Will make efforts to get water asap however will consider circumstances
 * 4. Very much needed items to survive, not quality, just posession	E.G. Evaluating priorities, will take a moment to drink from flask during work, however is able to go without if necessary
 * 5. To improve quality of life										E.G. When survival isnt a worry and can get by as is, will then go for improving items or property
 * 6. Item likely to become of focus in the future						E.G. PREDICTION MECHANISM, if conveniently available will get, Warmer clothing in summer when on sale to prep for winter
 * 7. Nice to haves														E.G. Not a focus however if the time and energy is available.
 * 8-10. Nice to haves
 * 
 * PRIORITY TASK LIST
 * 1. Direct threat
 * 10. First Level Overrides
 * 11. Excretion
 * 12. Water
 * 13. Food
 * 14. Sleep					//14. Exhausted Sleep
 * 15. Clothing
 * 16. Warmth
 * 17. Shelter
 * 								//18. Normal Sleep
 * 20. Second Level Overrides
 * 21. Security
 * 22. Safety
 * 23. Employment
 * 24. Resources
 * 25. Health
 * 26. Property //Their Own?

 * 30. Third Level Overrides
 * 31. Friends
 * 32. Relationship/Intimacy
 * 33. Family

 * 40. Fourth Level Overrides
 * 41. Respect
 * 42. Self-Esteem
 * 43. Status
 * 44. Strength
 * 45. Freedom
 * 46. Confidence
 * 47. Achievement

 * 50. Fith Level Overrides	
 * 51. Life Mission				
 */
public enum MaslowsHierarchy
{
	UltimateOverride=0,
	DirectThreat=1, 
	FirstLevelOverride=10, 
	Excretion=11,
	Water=12, 
	Food=13, 
	Sleep=14, 
	Clothing=15, 
	Warmth=16, 
	Shelter=17, 

	SecondLevelOverride=20,
	Security=21,
	Safety=22, 
	Employment=23, 
	Resources=24, 
	Health=25, 
	Property=26,

	ThirdLevelOverride=30,
	Friends=31,
	Relationship_Intimacy=32,
	Family=33,

	FourthLevelOverride=40,
	Respect=41, 
	Self_Esteem=42,
	Status=43,
	Strength=44,
	Freedom=45,
	Confidence=46,
	Achievement=47,

	FifthLevelOverride=50,
	Life_Mission=51
}

/*TO ADD SPECIFIC NEEDS AS AN ENUM
 * MAKE A SEPARATE ENUM AND DO AN OVERRIDE FUNCTION
 * e.g. normal 	public void query(MaslowsHierarchy query) {Standard code}
 * 				public void query(CustomEnum query) {custom  code}
 */