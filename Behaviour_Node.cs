using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Behaviour_Node
{
    //item/resource list
    //tool list
    //list dependent behaviours
    public Vector3 destination { get; set; }    //Need to check serialisation of vector3 again
    public int currentStage { get; set; }
}

[Serializable]
public struct dependentBehaviourNodes
{
    public Behaviour_Node dependentBehaviour;
    public bool MetDependencies;
}