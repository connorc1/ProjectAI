using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Created by Connor Chamberlain on 07/04/2019.
// Copyright © (2019) Connor Chamberlain. All rights reserved.

/* Public Functions & Variables: 
 *  
 */

/*Purpose: 
 *      To save and load the scenes time for data persistence across scene runs
 *To Use: Simply attach to a gameobject in the scene
 *      Best practice would be to add this script to the same object used to save
 *      all game data.
 *To Do: 
 *      Add other necessary world data
 */
public class WorldManager : MonoBehaviour {

    //At the earliest time set the current datetime
    void Start()
    {
        loadClockData();
    }

    //Saves the worldtime when the scene is stopped
    void OnApplicationQuit()
    {
        saveClockData();
    }

    /*Purpose: To deserialize a copy of the datetime from a file if that file exists
     */
    private void loadClockData()
    {
        if (File.Exists(Application.persistentDataPath + "/WorldData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/WorldData.dat", FileMode.Open);
            
            string fromFile = "";   //Holds the value of the saved time, once obtained from try catch statement
            try
            {
                fromFile = bf.Deserialize(file) as string;
            }
            catch (EndOfStreamException e)
            {
                Debug.Log("Failed Load");
                return;

            }
            file.Close();

            //Convert the string form of time to a datetime
            DateTime toLoad = DateTime.Parse(fromFile, null, DateTimeStyles.RoundtripKind);
            
            //set the world time in the scene
            WorldTime time = FindObjectOfType(typeof(WorldTime)) as WorldTime;
            time.WORLDTIME = toLoad;
        }
    }
    
    /*Purpose: To serialize a copy of the scenes time to an external file, Data persistence
     */
    private void saveClockData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/WorldData.dat");

        //Setup variables for saving the time
        WorldTime time = FindObjectOfType(typeof(WorldTime)) as WorldTime;
        string toSave = "";

        //Get the time and save it to string format (CANNOT EASILY SERIALIZE DATETIME)
        DateTime newTime = time.WORLDTIME;
        toSave = newTime.ToString("o");

        //Save the data
        bf.Serialize(file, toSave);
        file.Close();
    }
}
