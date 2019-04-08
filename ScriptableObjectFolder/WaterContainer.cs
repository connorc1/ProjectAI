using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 * 		void placeInScene(Vector3 position, Quaternion rotation, int Millilitres)
 * 		int takeSip()
 * 		int takeSip(int amount)
 * 		void fillContainer()
 * 		int specialFill(int maxCapacity)
 */

//
public class WaterContainer : Item
{
	int millilitres;
	int millilitreMax;

	public override void placeInScene(Vector3 position, Quaternion rotation, int Millilitres)
	{
		var go = Instantiate (WORLDOBJECT, position, rotation);
		go.gameObject.GetComponent<WaterContainer> ().millilitres = Millilitres;
	}

	public int takeSip()
	{
		if (millilitres >= 250)
		{
			millilitres -= 250;
			return 250;
		}
		else
		{
			int copy = millilitres;
			millilitres -= millilitres;
			return copy;
		}
	}
	public int takeSip(int amount)
	{
		if (millilitres >= amount)
		{
			millilitres -= amount;
			return amount;
		}
		else
		{
			int copy = millilitres;
			millilitres -= millilitres;
			return copy;
		}
	}

	public void fillContainer()
	{
		millilitres = millilitreMax;
	}

	public int specialFill(int maxCapacity)
	{
		int copy = millilitreMax - millilitres;
		if (copy > maxCapacity)
		{
			millilitres += maxCapacity;
			return maxCapacity;
		}
		else
		{
			millilitres += copy;
			return copy;
		}
	}
}