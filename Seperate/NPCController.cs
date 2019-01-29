using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 16/12/2018.
// Copyright © (2018) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *accepts inputs and converts it to commands for the model or view
 */

//
public class NPCController : MonoBehaviour {
			//Links to other parts of the MVC
	private NPCModel npcModel;
	//private NPCBehaviourView npcBehaviour;
			//Variables for controlling Updates
	private float nextUpdate;
	public bool updateRequired;
	private TimeOfDay lastNPCUpdate;		
			//Link to world time
	private WorldTime TIME;

	void Awake()
	{
		npcModel = GetComponent<NPCModel> ();
		//npcBehaviour = GetComponent<NPCBehaviourView> ();
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

		if (nextUpdate >= 10.0f || updateRequired)
		{
			int minutesSince = TIME.minutesDifference (lastNPCUpdate);	//Gets the number of minutes since last update, used in determining water and sleep deprivation.
			lastNPCUpdate = TIME.CurrentTime.time;						//Time since last update

			MaslowsHierarchyOfNeeds.updateBasicFirstLevelNeeds (ref npcModel, minutesSince);					//Accounts for food, water, and sleep deprivation
			TaskController.performNextTask (ref npcModel);											//Determines the next action to take

			//Updates variables to set up next update after x time.
			updateRequired = false;
			nextUpdate -= 10.0f;
		}
	}
}

/* To Do
 * 1. Make drinking hydration percentage accurate, take factors into account also.
 * 2. redo case 12
 * 3. World Time fix to turn time into seconds total, eg 60 * 60 * 24
 * 4. Improve create leaving time so that is more accurate and the agent leaves at the correct time
 * 		4.1 handle overnight edge case
 */