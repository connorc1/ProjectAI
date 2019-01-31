using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 31/01/2019.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//This script contains all of the knowledge variables needed for decision making;
public class NPCKnowledge : MonoBehaviour {
	public KnownWaterSources knownWaterSources;

	public void Awake()
	{
		knownWaterSources = new KnownWaterSources();
	}
}

public class KnownWaterSources
{
	public List<WaterSource> knownWaterSources;

	public KnownWaterSources()
	{
		knownWaterSources = new List<WaterSource> ();
	}

	public int getClosestSource(Vector3 currentPosition)
	{
		int indexOfClosest = -1;
		float closestDistance = 99999.99f;
		int tempIndex = 0;
		foreach(WaterSource w in knownWaterSources)
		{
			float current = w.getDistanceFrom (currentPosition);
			if (closestDistance > current)
			{
				indexOfClosest = tempIndex;
				closestDistance = current;
			}
			tempIndex++;
		}
		return indexOfClosest;
	}
}

public struct WaterSource
{
	GameObject waterObject;
	public float distanceFrom;

	public float getDistanceFrom(Vector3 currentLocation)
	{
		float distance = Vector3.Distance (currentLocation, waterObject.transform.position);
		return distance;
	}
}