using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Created by Connor Chamberlain on 08/04/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *      
 */

/*Purpose: 
 *      A file manager to save all types of Human NPC'S, may extend to include non human however with some modification
 *To Use:
 *      Attach to a save managing gameobject in the scene
 *To Do: 
 *      Neaten up all of the code
 *      Include a way to save and load ALL TYPES of npc's
 *      Learn more about saving between scenes (should be able to handle it now)
 */
public class NPCManager : MonoBehaviour {
    public static NPCManager manager;           //Used to save when swapping between scenes. Need to learn more on. (Check Unity's live training on data persistence, youtube)
    private Human[] npcList;                    //Private list of ALL HUMAN npc's in scene
	
    // Use this for initialization
	void Start () 
	{
        //ONLY ONE OF THIS ITEM BETWEEN SCENES
        if (manager == null)
        {
            npcList = new Human[0];
            DontDestroyOnLoad(gameObject);
            manager = this;
            loadNPCData();
        }
        else if(manager != this)
        {
            Destroy(gameObject);
        }
    }
	
    //When the application is being closed, save humans
    void OnApplicationQuit()
    {
        saveNPCData();
    }

    //Loads all human NPC's
    private void loadNPCData()
    {
        if (File.Exists(Application.persistentDataPath + "/npcData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/npcData.dat", FileMode.Open);
            
            //Container for all data to load, gets contents from file
            npcSaveStruct toLoad = new npcSaveStruct();
            try
            {
                toLoad = bf.Deserialize(file) as npcSaveStruct;
            }
            catch (EndOfStreamException e)
            {
                Debug.Log("Failed Load");
                return;
                
            }
            file.Close();

            //npcList = new Human[toLoad.numberOfNPCS];
            //Loads each Human
            foreach(HumanSave npc in toLoad.allNPCInGame)
            {
                //Gets prefab from resources folder and instantiates it with this gameObject as its parent
                GameObject defaultNPC = Resources.Load("prefabs/defaultNPC") as GameObject;
                GameObject newHuman = Instantiate(defaultNPC, gameObject.transform);

                //NEXT LINE MIGHT BE REDUNDANT, double checks parent is this gameobject
                newHuman.transform.parent = gameObject.transform;
                //Adds a human script to the gameobject and creates a reference which can be used to load the HUMAN
                Human human = newHuman.AddComponent<Human>();
                human.loadHuman(npc);
            }
        }
    }
    //Saves all Human NPC's
    private void saveNPCData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/npcData.dat");

        //Gets all Humans with Human class component in scene
        npcList = FindObjectsOfType(typeof(Human)) as Human[];
        //Data container for all humans
        npcSaveStruct toSave = new npcSaveStruct();
        //Saves each human and adds to toSave container
        foreach(Human npc in npcList)
        {
            HumanSave save = npc.saveHumanData();
            toSave.allNPCInGame.Add(save);
            toSave.numberOfNPCS++;
        }

        bf.Serialize(file, toSave);
        file.Close();
    }

    //Struct used to save all NPC'S
    [Serializable]
    private class npcSaveStruct
    {
        public int numberOfNPCS;
        public List<HumanSave> allNPCInGame;

        public npcSaveStruct()
        {
            numberOfNPCS = 0;
            allNPCInGame = new List<HumanSave>();
        }
    }
}


