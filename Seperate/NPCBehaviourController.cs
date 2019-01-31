using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//
public static class NPCBehaviourController {
	/*public NavMeshAgent agent;
	//public npcInventory npcInventory;
	NPCModel npcModel;
	NPCController npcController;
	DialogueController npcSpeachBox;

	//GameObject npcDialogue;




	void Awake()
	{
		//npcInventory = gameObject.GetComponent<npcInventory> ();
		npcModel = GetComponent<NPCModel> ();
		npcController = GetComponent<NPCController> ();
		agent = GetComponent<NavMeshAgent> ();	
		npcSpeachBox = GetComponent<DialogueController> ();
		//npcDialogue = gameObject.transform.GetChild (0).gameObject;
	}*/

	public static void interpretId (ref NPCBehaviourView npcBehaviourView, taskNode item)
	{
		switch(item.taskIdentifier)
		{
		case -1:
			//DEATH
			break;
		case 0:
			//Magical overrides
			break;
		case 1:
			//some function
			break;
		case 10: //FIRST LEVEL OVERRIDE
			Debug.Log ("override");
			break;
		case 11: //EXCRETION
			break;
		case (int)MaslowsHierarchy.Water: //WATER
			npcBehaviourView.FNWater(item);
			//Debug.Log("water");
			break;
		case 13: //FOOD
			break;
		case 14: //SLEEP
			Debug.Log("sleep");
			break;
		case (int)MaslowsHierarchy.Clothing: //CLOTHING
			npcBehaviourView.FNClothing();
			break;
		case 16: //WARMTH 
			break;
		case 17: //SHELTER
			break;
		case 20: //SECOND LEVEL OVERRIDE
			break;
		case 21: //SECURITY
			break;
		case 22: //SAFETY
			break;
		case 23: //EMPLOYMENT
			//Unless there are any overrides
			break;
		case 24: //RESOURCES
			break;
		case 25: //HEALTH
			break;
		case 26: //PROPERTY
			break;
		case 30: //THIRD LEVEL OVERRIDE
			break;
		case 31: //FRIENDS
			break;
		case 32: //RELATIONSHIP/INTIMACY
			break;
		case 33: //FAMILY
			break;
		case 51: 
			break;
		default:
			Debug.Log ("BEHAVIOUR ERROR OUT OF SCOPE");
			break;
		}
	}
}