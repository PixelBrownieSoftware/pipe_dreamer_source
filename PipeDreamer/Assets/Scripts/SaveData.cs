using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public class SaveData : MonoBehaviour {

    public WorldManager world;

	// Use this for initialization
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
        }
	}
	
	// Update is called once per frame
	void Save () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream savFile = File.Create("memoriesOf.dream");

        gemCount save = new gemCount();
        save.areaGems = world.areas;
        bf.Serialize(savFile, save);
        savFile.Close();

    }

    [System.Serializable]
    class gemCount {
        public List<AreaScript> areaGems = new List<AreaScript>();
    }

}
