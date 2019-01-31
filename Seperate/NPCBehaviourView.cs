using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine;

// Created by Connor Chamberlain on 16/12/2018.
// Copyright © (2018) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *manages the viewble behaviour within the game. This is where most of the programming for specifics is done.
 */

//
public class NPCBehaviourView : MonoBehaviour{
	public void FNDirectThreat() {}
	public void FNFLOverride()	{}
	public void FNExretion() {}
	public void FNWater(taskNode item) 
	{
		//npcSpeachBox.npcSpeaks (DialogueController.waterDialogue());
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
	public void FNFood() {}
	public void FNSleep() {}
	public void FNClothing() {}
	public void FNWarmth() {}
	public void FNShelter() {}
	public void FNSLOverride() {}
	public void FNSecurity() {}
	public void FNSafety() {}
	public void FNEmployment() {}
	public void FNResources() {}
	public void FNHealth() {}
	public void FN() {}
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