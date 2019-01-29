using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *		bool hasEnough(int Quantity)
 *		void placeInScene(Vector3 position, Quaternion rotation)
 *		void placeInScene(Vector3 position, Quaternion rotation, int Quantity)
 */


public class Item : ScriptableObject {
	public int itemID;
	public int quantity;
	public MetricWeight weight;
	public Currency value;
	public Transform WORLDOBJECT;

	public bool hasEnough(int Quantity)
	{
		if (quantity >= quantity)
		{
			return true;
		}
		return false;
	}

	public virtual void placeInScene(Vector3 position, Quaternion rotation)
	{
		var go = Instantiate (WORLDOBJECT, position, rotation);

	}
	//Overloaded function allowing for Quantity
	public virtual void placeInScene(Vector3 position, Quaternion rotation, int Quantity)
	{
		var go = Instantiate (WORLDOBJECT, position, rotation);
		go.gameObject.GetComponent<Item> ().quantity = Quantity;
	}
}