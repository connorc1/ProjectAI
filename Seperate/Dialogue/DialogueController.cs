using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//
public class DialogueController : MonoBehaviour {
	public bool isSpeaking; 		//Prevents overlaying sentences when given more than one thing to say
	float speakingTime;				//How long the text dialogue will be shown.
	public TextMesh npcSpeakBox;	//Variable to access the text box for dialogue

	public void Awake()
	{
		npcSpeakBox = gameObject.transform.GetChild (0).gameObject.GetComponent <TextMesh>();
		speakingTime = 5.0f;
		npcSpeakBox.text = "";
	}

	public void npcSpeaks(string toSay)
	{
		StartCoroutine (beginSpeaking (toSay));
	}

	//Function which can be delayed within the unity engine.
	IEnumerator beginSpeaking(string toSay)
	{
		isSpeaking = true;
		npcSpeakBox.text = toSay;
		yield return new WaitForSeconds(speakingTime);
		npcSpeakBox.text = "";
		isSpeaking = false;
	}

	//Example for dialogue
	public static string waterDialogue()
	{
		return "damn I could use a drink";
	}
}
