using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 08/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      
 * EXTERNAL DATA
 *      public enum EntityOfType { Entity, Human }      MUST CONTAIN ALL TYPES OF ENTITY, eg cow, cat, dog, fly, human, alien, dragon, argonian
 */

/*Purpose: 
 *      A base class for all entity types. Will store information specific to that entity, such as group alliegances
 *To Use: 
 *      Inherit this class, TBD
 *To Do: 
 *      
 * What does this file do
 * 1. It holds the variables necessary for each type. E.G. A human
 *      may be part of one or more factions.
 */
public class EntityType : ScriptableObject {

}
[Serializable]public enum EntityOfType { Entity, Human };