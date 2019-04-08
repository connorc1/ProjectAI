using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Created by Connor Chamberlain on 08/03/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* ### Inherited Items ###
 */
/* Public Functions & Variables: 
 *
 */

/*Purpose: 
 *      Human data specific to their type, alliegances, political beliefs, etc
 *To Use: 
 *      TBD
 *To Do: 
 *      Look into political horse shoe? MUCH more research required on this front
 *      Struct containing name and other such details
 *      
 * More notes
 * 1. It holds the variables necessary for each type. E.G. A human
 *      may be part of one or more factions.
 */
public class HumanType : EntityType {
    public string Name;         //Humans name, might have to change to struct containing first and last names later, titles, ranks, etc
    public Gender gender;       //Entities gender, also used in the initialisation of the UMA asset
    //public HumanBehaviourList mainBehaviour

    public HumanSave saveHumanData(HumanSave save)
    {
        save.Name = Name;
        save.gender = gender;
        return save;
    }
    public HumanType(HumanSave load)
    {
        Name = load.Name;
        gender = load.gender;
    }
    public HumanType()
    {
        Name = "Veronica";
        gender = Gender.Female;
    }
}
