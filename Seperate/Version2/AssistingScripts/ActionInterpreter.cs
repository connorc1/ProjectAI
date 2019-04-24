using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//
public class ActionInterpreter : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}

public struct ActionContainer
{
    public PresentVerb action;
    public Noun article;

    public ActionContainer(PresentVerb setAction, Noun setArticle)
    {
        action = setAction;
        article = setArticle;
    }
    public void setAction(PresentVerb setTo)
    {
        action = setTo;
    }
    public void setArticle(Noun setTo)
    {
        article = setTo;
    }
}

public enum PresentVerb
{
    idling,
    travelling, 
    sleeping, 
    eating,
    drinking
}

[Serializable]
public enum Noun
{
    invalid,
    bed, 
    home,
    food,
    water, 
    shelter
}
