using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *accepts inputs and converts it to commands for the model or view
 *This file is the main file which controls the NPC.
 */

//
public class NPCController : MonoBehaviour {
			//Links to other parts of the MVC
	private NPCModel npcModel;
	private NPCBehaviourView npcBehaviour;
			//Variables for controlling Updates
	private float nextUpdate;
	public bool updateRequired;
	private TimeOfDay lastNPCUpdate;		
			//Link to world time
	private WorldTime TIME;


	void Awake()
	{
		npcModel = GetComponent<NPCModel> ();
		npcBehaviour = GetComponent<NPCBehaviourView> ();
		nextUpdate = 10.0F;
		updateRequired = false;
		TIME = GameObject.Find ("WorldTime").GetComponent<WorldTime> ();
	}
	void Start()
	{
		lastNPCUpdate = TIME.CurrentTime.time; 
	}



	void Update()
	{
		nextUpdate += Time.deltaTime;

		//This delays updates to every 10 seconds or when needed rather than every frame to save CPU processing.
		if (nextUpdate >= 10.0f || updateRequired)
		{
			int minutesSince = TIME.minutesDifference (lastNPCUpdate);	//Gets the number of minutes since last update, used in determining water and sleep deprivation.
			lastNPCUpdate = TIME.CurrentTime.time;						//Time since last update

			updateBasicFirstLevelNeeds (minutesSince);					//Accounts for food, water, and sleep deprivation
			performNextTask ();											//Determines the next action to take

			//Updates variables to set up next update after x time.
			updateRequired = false;
			nextUpdate -= 10.0f;
		}
	}
//############################################################################################################

	//Updates the basic physiological needs of the human body
	void updateBasicFirstLevelNeeds(int minutesSince) {
		npcModel.energyExpenditure (minutesSince);
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


	//Functions which set up whether or not to look at proactive or reactive lists in the model. BASIC, NEEDS EXPANDING ON
	private void performNextTask()
	{
		performProactiveList ();
	}

	private void performProactiveList()
	{
		//PROACTIVE NEEDS
			//look at proactive needs
		if (npcModel.taskList.pro_activeCount <= 3) {
			//populate with items.	
			npcModel.MHNCycle();
		}
		npcBehaviour.interpretId (npcModel.taskList.pro_activeTasks[0]);
	}

	private void performReactiveList()
	{
		//look as reactive needs
		//if its populated with at least 1 item
		if (npcModel.taskList.pro_activeCount > 0) {
			npcBehaviour.interpretId (npcModel.taskList.pro_activeTasks [0]);
		} 

	}
}

/* Rough To Do
 * 1. Make drinking hydration percentage accurate, take factors into account also.
 * 2. redo case 12
 * 3. World Time fix to turn time into seconds total, eg 60 * 60 * 24
 * 4. Improve create leaving time so that is more accurate and the agent leaves at the correct time
 * 		4.1 handle overnight edge case
 */