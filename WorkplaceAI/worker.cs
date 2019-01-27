using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//
public class worker : MonoBehaviour {
	public bool hasdepartedForWork = false; bool hasDeparted;
	NavMeshAgent agent;
	WorldTime worldTime;

	bool hasAJob; 
	public GameObject workplace; workplaceController workplaceScript;
	bool workMonday = true;
	bool workTuesday = true;
	bool workWednesday = true;
	bool workThursday = true;
	bool workFriday = true;
	bool workSaturday = true;
	bool workSunday = true;

	TimeOfDay recommendedDepartForWorkTime;

	void Awake()
	{
		initialiseItems ();
		workplaceScript = workplace.GetComponent<workplaceController> ();
		workplaceScript.addWorker (this.gameObject);
	}

	void Update()
	{
		//prepareForWork ();
		departForWorkConditions ();
	}



	private void departForWorkConditions()
	{
		int currentDay = (int)worldTime.CurrentDay;

		if (!hasdepartedForWork) {
			if (canWorkThisDay (currentDay) && workplaceScript.openThisDay (currentDay)) {
				if (worldTime.isAfter (workplaceScript.getStartTime(currentDay))) {
					departForWork ();
				}
			}
		}
	}
	private void departForWork ()
	{
		agent.stoppingDistance = 2.0f;
		agent.destination = workplace.transform.position;
		hasdepartedForWork = true;
	}








	private bool canWorkThisDay(int day)
	{
		if (day == 0)
		{
			return workMonday;
		}
		if (day == 1)
		{
			return workTuesday;
		}
		if (day == 2)
		{
			return workWednesday;
		}
		if (day == 3)
		{
			return workThursday;
		}
		if (day == 4)
		{
			return workFriday;
		}
		if (day == 5)
		{
			return workSaturday;
		}
		if (day == 6)
		{
			return workSunday;
		}
		return false;
	}


	private void initialiseItems()
	{
		hasdepartedForWork = false; hasDeparted = false;
		agent = GetComponent<NavMeshAgent> ();
		worldTime = GameObject.Find ("WorldTime").GetComponent<WorldTime> ();
	}
}
