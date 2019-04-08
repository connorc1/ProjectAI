using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
// Created by Connor Chamberlain on _.
// Copyright © (YEAR) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *
 */

//WARNING: THIS FILE IS CURRENTLY REDUNDANT, PLACING IN SCENE MAY CAUSE ISSUES
public class SaveWorld : MonoBehaviour
{

    public GameObject[] npcList;

    public void Awake()
    {
        Load();
    }

    void OnApplicationQuit()
    {
        npcList = GameObject.FindGameObjectsWithTag("NPC");
        Save(npcList);
    }

    public void Save(GameObject[] npcList)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/entity.dat", FileMode.Open);

        List<Entity> toSave = new List<Entity>();
        foreach (GameObject npc in npcList)
        {

            /*Entity npcEntity = npc.GetComponent<Entity>();
            data.type = npcEntity.type;
            data.entityType = npcEntity.entityType;
            data.entityNeeds = npcEntity.entityNeeds;
            toSave.Add(data);*/
        }

        bf.Serialize(file, toSave);
        file.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/entity.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/entity.dat", FileMode.Open);
            Entity data = (Entity)bf.Deserialize(file);
            file.Close();

            //NEED TO PLACE IN SCENE
            //type = data.type;
            //entityType = data.entityType;
            //entityNeeds = data.entityNeeds;
        }
    }
}