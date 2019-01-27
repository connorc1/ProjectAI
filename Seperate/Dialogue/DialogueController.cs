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
	public bool isSpeaking; float speakingTime;
	public TextMesh npcSpeakBox;

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

	IEnumerator beginSpeaking(string toSay)
	{
		isSpeaking = true;
		npcSpeakBox.text = toSay;
		yield return new WaitForSeconds(speakingTime);
		npcSpeakBox.text = "";
		isSpeaking = false;
	}

	public static string waterDialogue()
	{
		return "damn I could use a drink";
	}
}
