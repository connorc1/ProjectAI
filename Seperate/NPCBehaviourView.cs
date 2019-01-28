using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *manages the viewble behaviour within the game. This is where most of the programming for specifics is done.
 */

//
public class NPCBehaviourView : MonoBehaviour {
	public NavMeshAgent agent;
	public npcInventory npcInventory;
	NPCModel npcModel;
	NPCController npcController;
	DialogueController npcSpeachBox;

	//GameObject npcDialogue;




	void Awake()
	{
		npcInventory = gameObject.GetComponent<npcInventory> ();
		npcModel = GetComponent<NPCModel> ();
		npcController = GetComponent<NPCController> ();
		agent = GetComponent<NavMeshAgent> ();	
		npcSpeachBox = GetComponent<DialogueController> ();
		//npcDialogue = gameObject.transform.GetChild (0).gameObject;
	}

	//Interprets the taskNode to set the NPC to do the correct behaviour
	public void interpretId (taskNode item)
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
			FNWater(item);
			//Debug.Log("water");
			break;
		case 13: //FOOD
			break;
		case 14: //SLEEP
			Debug.Log("sleep");
			break;
		case (int)MaslowsHierarchy.Clothing: //CLOTHING
			FNClothing();
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
			agent.destination = npcModel.workPlaceLocation;
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
	private void FNDirectThreat() {}
	private void FNFLOverride()	{}
	private void FNExretion() {}
	private void FNWater(taskNode item) 
	{
		npcSpeachBox.npcSpeaks (DialogueController.waterDialogue());
		/*
		bool success = true;
		npcSpeaks (DialogueController.waterDialogue (), true);
		if (item.priority == 4) {
			success = npcInventory.drinkSip (1);
			npcInventory.noWater = !success;
		} 
		else if (item.priority == 3) {
			if (npcInventory.noWater && !npcModel.currentlyBusy)
			{
				//Query known water sources
			}
			if (!npcInventory.noWater)
			{
				float rem = (100.0f - npcModel.hydration) - 5f;
				int sipsRequired = (int)(rem / 2.6f);
				for (int i = 0; i < sipsRequired; i++) {
					success = npcInventory.drinkSip (1);
					if (!success) {
						i = sipsRequired;
					}
				}
				npcModel.taskList.removeFromPTask (12);
				npcController.updateRequired = true;
			}
		} else if (item.priority == 2) {

		} else if (item.priority == 1) {

		}*/}
	private void FNFood() {}
	private void FNSleep() {}
	private void FNClothing() {}
	private void FNWarmth() {}
	private void FNShelter() {}
	private void FNSLOverride() {}
	private void FNSecurity() {}
	private void FNSafety() {}
	private void FNEmployment() {}
	private void FNResources() {}
	private void FNHealth() {}
	private void FN() {}
}
/* 1. Direct threat
* 10. First Level Overrides
* 11. Excretion
* 12. Water
* 13. Food
* 14. Sleep					//14. Exhausted Sleep
* 15. Clothing
* 16. Warmth
* 17. Shelter
* 20. Second Level Overrides
* 21. Security
* 22. Safety
* 23. Employment
* 24. Resources
* 25. Health
* 26. Property //Their Own?
* 30. Third Level Overrides
* 31. Friends
* 32. Relationship/Intimacy
* 33. Family
*/