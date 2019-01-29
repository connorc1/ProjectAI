using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 29/01/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//
public static class MaslowsHierarchyOfNeeds {


	public static void updateBasicFirstLevelNeeds(ref NPCModel npcModel,int minutesSince) {
		//reduce sleep
		//taskNode newProactive = new taskNode(4, null);
		if (npcModel.sleep <= 90.0f) {
			if (npcModel.sleep <= 85.0f) {
				if (npcModel.sleep <= 79.0f) {
					if (npcModel.sleep <= 70.0f) {
						if (npcModel.sleep <= 55.0f) {
							if (npcModel.sleep <= 50.0f) {
								if (npcModel.sleep <= 35.0f) {
									if (npcModel.sleep <= 0.0f) {
										// DEATH!!!! KILL PLAYER
									} else {
										taskNode newProactive = new taskNode (14, 1);
										npcModel.taskList.addToPTask (newProactive);
									}
								} else {
									taskNode newProactive = new taskNode (14, 2);
									npcModel.taskList.addToPTask (newProactive);
								}
							} else {
								taskNode newProactive = new taskNode (14, 3);
								npcModel.taskList.addToPTask (newProactive);
							}
						} else {
							taskNode newProactive = new taskNode (14, 4);
							npcModel.taskList.addToPTask (newProactive);
						}
					} else {
						taskNode newProactive = new taskNode (14, 5);
						npcModel.taskList.addToPTask (newProactive);
					}
				} else {
					taskNode newProactive = new taskNode (14, 6);
					npcModel.taskList.addToPTask (newProactive);
				}
			} else {
				taskNode newProactive = new taskNode (14, 7);
				npcModel.taskList.addToPTask (newProactive);
			}
		}

		//Update Hydration
		if (npcModel.hydration <= 95.0f) {
			if (npcModel.hydration <= 74.0f) {
				if (npcModel.hydration <= 66.0f) {
					if (npcModel.hydration <= 33.0f) {
						if (npcModel.hydration <= 0.0f) {
							//death
						} else {
							taskNode newProactive = new taskNode (12, 1);
							npcModel.taskList.addToPTask(newProactive);
						}
					} else {
						taskNode newProactive = new taskNode (12, 2);
						npcModel.taskList.addToPTask (newProactive);
					}
				} else {
					taskNode newProactive = new taskNode (12, 3);
					npcModel.taskList.addToPTask (newProactive);
				}
			} else {
				taskNode newProactive = new taskNode (12, 4);
				npcModel.taskList.addToPTask (newProactive);
			}
		}
		else
		{
			npcModel.taskList.removeFromPTask (12);
		}

		//update food
	}

	public static void MHNCycle(ref NPCModel npcModel)
	{
		//First Level
		//Water, food, and sleep are handled by the Controller
		if (!npcModel.wearingClothing && npcModel.taskList.isNotInList(15))
		{
			taskNode newTask = new taskNode (15, 4);
			npcModel.taskList.addToPTask (newTask);
		}
		else if (!npcModel.warmEnough && npcModel.taskList.isNotInList(16))
		{
			taskNode newTask = new taskNode (16, 4);
			npcModel.taskList.addToPTask (newTask);
		}
		else if (!npcModel.hasShelter && npcModel.taskList.isNotInList (17))
		{
			taskNode newTask = new taskNode (17, 4);
			npcModel.taskList.addToPTask (newTask);
		}
		//Second Level
		else if (!npcModel.isEmployed) {
			//Get Job
		}

		//Third Level
		//Fourth Level
		//Fifth Level
		if (npcModel.hasLifeMission == false)
		{
			taskNode newTask = new taskNode (51, 4);
			npcModel.taskList.addToPTask (newTask);
			npcModel.hasLifeMission = true;
		}
	}
}

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
