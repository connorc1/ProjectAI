using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 29/01/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//
public static class TaskController {
	

	public static void performNextTask(ref NPCModel npcModel)
	{
		performProactiveList (ref npcModel);
	}

	private static void performProactiveList(ref NPCModel npcModel)
	{
		//look at proactive needs
		if (npcModel.taskList.pro_activeCount <= 3) {
			//populate with items.	
			MaslowsHierarchyOfNeeds.MHNCycle(ref npcModel);
		}
		NPCBehaviourView.interpretId (npcModel.taskList.pro_activeTasks[0]);
	}

	private static void performReactiveList(ref NPCModel npcModel)
	{
		//look as reactive needs
		//if its populated with at least 1 item
		if (npcModel.taskList.pro_activeCount > 0) {
			NPCBehaviourView.interpretId (npcModel.taskList.pro_activeTasks [0]);
		} 

	}
}

public struct taskNode
{
	public int taskIdentifier;
	public Vector3 target;
	//public float distanceToTarget;
	public int priority;

	public taskNode(int ID, int PRIORITY) 
	{
		taskIdentifier = new int();
		taskIdentifier = ID;
		target = new Vector3 ();
		priority = new int();
		priority = PRIORITY;
	}
	public void assignTarget(Vector3 Target)
	{
		target = Target;
	}
}

public struct taskContainer
{
	public taskNode[] pro_activeTasks;
	public int pro_activeCount;
	public taskNode[] re_activeTasks;
	public int re_activeCount;

	public taskContainer(int size)
	{
		pro_activeTasks = new taskNode[size];
		pro_activeCount = new int();
		pro_activeCount = 0;
		re_activeTasks = new taskNode[size];
		re_activeCount = new int ();
		re_activeCount = 0;
	}
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