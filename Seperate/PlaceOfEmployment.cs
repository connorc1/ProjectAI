using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */



//
public class PlaceOfEmployment : MonoBehaviour {
	/*struct EmployeeData
	{
		private GameObject Employee;
		private TimeOfDay WorkStart;
		private TimeOfDay LeavingTime;
		private TimeOfDay WorkEnd;

		private void createLeavingTime(GameObject workplace, WorldTime TIME)
		{
			Vector3 wp = workplace.transform.position;
			Vector3 emp = Employee.transform.position;
			float distance = Vector3.Distance;
			float temp = distance / Employee.GetComponent<NPCBehaviourView> ().agent.speed; //seconds
			temp = temp * 1.5f;//To make up for turning, very rough addition needs work.
			temp = temp * TIME.DayDurationHolder;
			TimeOfDay difference = new TimeOfDay (0, 0, 0);
			difference.Minute = temp / 60;
			difference.Second = temp % 60;
			difference.Hour = difference.Minute / 60;
			difference.Minute = difference.Minute % 60;
			TimeOfDay leavingTime = new TimeOfDay (WorkStart.Hour, WorkStart.Minute, WorkStart.Second);
			leavingTime.Hour -= difference.Hour;
			leavingTime.Minute -= difference.Minute;
			leavingTime.Second -= difference.Second;
			if (leavingTime.Second < 0)
			{
				leavingTime.Minute--;
				leavingTime.Second += 60;
			}
			if (leavingTime.Minute < 0)
			{
				leavingTime.Hour--;
				leavingTime.Minute += 60;
			}
			if (leavingTime.Hour < 0)
			{
				leavingTime.Hour += 24;
				//Edge case, if using between two times will strugle with overnight variable
			}
		}
	}

	//######job specific variables
	public int jobID;
	public int jobVariance;

	//######End variables
	private EmployeeData[] employeeList;
	private int EmployeeCapacity;
	private TimeOfDay defaultStartTime;
	private TimeOfDay defaultEndTime
	private WorldTime TIME;

	float delayUpdate;

	void Awake()
	{
		employeeList = new EmployeeData[10];
		TIME = GameObject.Find ("WorldTime").GetComponent<WorldTime> ();
		delayUpdate = 10.0f;
	}

	// Use this for initialization
	void Start () 
	{
		employeeList [0] = GameObject.Find ("Capsule");
	}
	
	// Update is called once per frame
	void Update () 
	{
		delayUpdate += Time.deltaTime;
		if (delayUpdate >= 10.0f)
		{
			if(TIME.betweenTwoTimes(WorkStart, WorkEnd, false))
			{
				employeeList [0].GetComponent<NPCBehaviourView> ().agent.destination = 
					gameObject.transform.position;
			}
			else
			{
				employeeList [0].GetComponent<NPCBehaviourView> ().agent.destination = 
					new Vector3 (230.0f, 6.0f, 240.0f);
			}
			delayUpdate -= 10.0f;
		}
	}

	public void newEmployee()
	{
		
	}


	*/
}
