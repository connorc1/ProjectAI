using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettlementController : MonoBehaviour
{
    //public bool isBuildable;  //Only added to save me forgetting later, player customisable settlement

    public GameObject[] houses;
    public GameObject[] waterSources;
    public GameObject[] BOUNDARY;

    public GameObject getClosestWaterSource(Vector3 currentPosition)
    {
        int count = waterSources.Length;
        int closestSource = 0;
        float distance = 9999f;
        for(int i = 0; i < count; i++)
        {
            float currentDistance = Vector3.Distance(currentPosition, waterSources[i].transform.position);
            if (currentDistance < distance)
            {
                distance = currentDistance;
                closestSource = i;
            }
        }
        return waterSources[closestSource];
    }

    //Temporary function
    public Vector3 getBedLocation()
    {
        return houses[0].GetComponent<HouseController>().bed.gameObject.transform.position;
    }

    public GameObject getPreviousBoundary(int position)
    {
        int count = BOUNDARY.Length;
        //at 0, get last
        if(position == 0)
        {
            return BOUNDARY[count];
        }
        //normal case
        else
        {
            return BOUNDARY[position - 1];
        }
    }

    public GameObject getNextBoundary(int position)
    {
        int count = BOUNDARY.Length;
        //at last, get first
        if (position == count)
        {
            return BOUNDARY[0];
        }
        //normal case
        else
        {
            return BOUNDARY[position + 1];
        }
    }

    public bool isWithinBoundary(Vector3 position)
    {
        return true;
    }


}
