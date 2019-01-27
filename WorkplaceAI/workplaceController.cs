using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Created by Connor Chamberlain on 30/11/18.
// Copyright © 2018 Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//Many of these script variants can be applied to the one workplace, however only one can be for a job
[SerializePrivateVariables]
public class workplaceController : MonoBehaviour {
	//Workplace Specific
	string workPlaceName;
	[System.NonSerialized]List<GameObject> workers = new List<GameObject>();

	//Job specific
	private string jobTitle;
	//DecimalCurrency wage;
	[System.NonSerialized]List<GameObject> workersAtWorkplace = new List<GameObject> ();


	//Days of Inopperation
	bool openMonday = true; TimeOfDay monStart; TimeOfDay monEnd;
	bool openTuesday = false; TimeOfDay tueStart; TimeOfDay tueEnd;
	bool openWednesday = false; TimeOfDay wedStart; TimeOfDay wedEnd;
	bool openThursday = false; TimeOfDay thuStart; TimeOfDay thuEnd;
	bool openFriday = false; TimeOfDay friStart; TimeOfDay friEnd;
	bool openSaturday = false; TimeOfDay satStart; TimeOfDay satEnd;
	bool openSunday = false; TimeOfDay sunStart; TimeOfDay sunEnd;

	public void addWorker(GameObject toAdd)
	{
		workers.Add (toAdd);
	}
	public void removeWorker(GameObject toRemove)
	{
		workers.Remove (toRemove);
		//Handles firing or unexpected death to some extent.
		if (workersAtWorkplace.Contains(toRemove))
		{
			workersAtWorkplace.Remove (toRemove);
		}

	}
	public void workerArrivesAtWorkplace(GameObject hasArrived)
	{
		workersAtWorkplace.Add (hasArrived);
	}
	public void workerLeavesWorkplace(GameObject hasLeft)
	{
		workersAtWorkplace.Remove (hasLeft);
	}


	/*public DecimalCurrency calculateWage(TimeOfDay hoursWorked)
	{
		DecimalCurrency amount = new DecimalCurrency(0, 0);
		int HOURS = hoursWorked.Hour;
		int MINUTES = hoursWorked.Minute;
		//Calculate whole hour wage, remainder in minutes handled after
		amount.dollars = wage.dollars * HOURS;
		amount.cents = wage.cents * HOURS;
		//For half an hour calculating not full hourly wage, using a percentage of an hour
		float percentage = MINUTES / 60.0f;
		amount.dollars += (int)(wage.dollars * percentage);
		amount.cents += (int)(wage.cents * percentage);
		return amount;
	}*/
		
	private void beginWorkplaceTask()
	{
		if (jobTitle == "smith")
		{
			//Do smithy work
			//e.g. beginSmithing();
		}
		if (jobTitle == "bartender")
		{
			//Do Bartender work
			//eg this.gameObject.GetComponent<BarScript>().BeginBartending();
		}
	}

	public bool openThisDay(int day)
	{
		if (day == 0)
		{
			return openMonday;
		}
		if (day == 1)
		{
			return openTuesday;
		}
		if (day == 2)
		{
			return openWednesday;
		}
		if (day == 3)
		{
			return openThursday;
		}
		if (day == 4)
		{
			return openFriday;
		}
		if (day == 5)
		{
			return openSaturday;
		}
		if (day == 6)
		{
			return openSunday;
		}
		return false;
	}

	public TimeOfDay getStartTime(int day)
	{
		if (day == 0)
		{
			return monStart;
		}
		if (day == 1)
		{
			return tueStart;
		}
		if (day == 2)
		{
			return wedStart;
		}
		if (day == 3)
		{
			return thuStart;
		}
		if (day == 4)
		{
			return friStart;
		}
		if (day == 5)
		{
			return satStart;
		}
		if (day == 6)
		{
			return sunStart;
		}
		return new TimeOfDay(0, 0, 0);
	}
}
