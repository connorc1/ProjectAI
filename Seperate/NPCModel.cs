using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 16/12/2018.
// Copyright © (2018) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *Central Component of the MVC. Is the dynamic data structure, independent of the viewable behaviour
 *directly manages data, logic, and the rules of the application
 */

//
public class NPCModel
{
	public taskContainer taskList;
	public NPCInventory inventory; 
	public bool currentlyBusy;

	//First level needs
	public float sleep; public float sleepLossRate; public float sleepSubstitute; 							
	public float hydration; public float dehydrationRate;
	//float StomachFullness, //Fat fullness, muscle, stomach
	public bool wearingClothing;
	public bool warmEnough;
	public bool hasShelter;

	//Second level needs
	public bool isEmployed; public bool timeToGoToWork;
	public Vector3 workPlaceLocation;

	//Third level needs

	//Fourth level needs


	//Fifth level
	public bool hasLifeMission;

	public NPCModel()
	{
		taskList = new taskContainer (10);
		inventory = new NPCInventory ();
		bool currentlyBusy = false;

		sleep = 100.0f; sleepLossRate = 33.0f; sleepSubstitute = 0.0f;
		hydration = 100.0f; dehydrationRate = 33.0f;
		//food
		wearingClothing = false;
		warmEnough = false;
		hasShelter = false;

		isEmployed = false; timeToGoToWork = false;
		workPlaceLocation = new Vector3 (0.0f, -999.0f, 0.0f);//workplace not yet set;
	}


}

