using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *		Currency(int Dollars, int Cents)
 *		string toString()
 */

//
public class Currency : ScriptableObject {
	int dollars;
	int cents;

	public Currency(int Dollars, int Cents)
	{
		dollars = Dollars;
		cents = Cents;
	}

	public string toString()
	{
		string value = "$" + dollars + "." + cents;
		return value;
	}
}