using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 28/01/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *	 itemList
 *	 waterContainerList
 *	 ediblesList
 *		NPCInventory()
 *		void addToList(Item item)
 *		void addToList(WaterContainer waterContainer)
 *		void addToList(Edible foodItem)
 */

//
public class NPCInventory : MonoBehaviour
{
	//List for each type here
	List<Item> itemList;
	List<WaterContainer> waterContainerList;
	List<Edible> ediblesList;

	//Function to both add and remove items. Also to check if its in the inventory + quantity

	public NPCInventory()
	{
		itemList = new List<Item>();
		waterContainerList = new List<WaterContainer>();
		ediblesList = new List<Edible>();
	}

	public void addToList(Item item)
	{
		itemList.Add (item);
	}
	public void addToList(WaterContainer waterContainer)
	{
		waterContainerList.Add (waterContainer);
	}
	public void addToList(Edible foodItem)
	{
		ediblesList.Add (foodItem);
	}
}