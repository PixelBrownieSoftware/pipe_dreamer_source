using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour {

    public List<AreaScript> areas = new List<AreaScript>();
    public int totalGems;
    public AreaScript area;
    public int areaNum;

    public Text highestGems;
    public Text text;

    public static WorldManager world;

    public PlayerScript player;
    CharacterBase playerHost;

    // Use this for initialization
    void Start () {
        if (world == null) {
            world = this.gameObject.GetComponent<WorldManager>();
        }
    }

    //Edited on 19/12/2018
    public void teleportPlayer(Vector2 locaiton) {
        
        if (player.hostChar == null) { player.gameObject.transform.position = new Vector2(locaiton.x, locaiton.y);
        }
        else { playerHost.transform.position = new Vector2(locaiton.x, locaiton.y);
        }

        
        }

    public void loadData(List<AreaScript> area) {

        for (int i = 0; i < areas.Count; i++) {
            areas[i].gems = area[i].gems;
            if (i == 0) {
                continue;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        playerHost = player.hostChar;
        for (int i = 0; i < areas.Count; i++) {
            if (areaNum == i) {
                
                if (i == 0 || i == 7) {

                    if (i == 7) {
                        text.text = "Sleep...";
                    }

                    if (i == 0) {
                        int gems = 0;
                        for (int a = 1; a < areas.Count; a++) {
                            if (!areas[a].subArea)
                            {
                                gems += areas[a].gemTot;
                            }

                            text.text = "Total Gems: " + totalGems;
                        }
                        totalGems = gems;
                    }
                       
                } else {

                    totalGems = areas[i].gemTot;
                    text.text = area.name + " Gems: " + totalGems;
                }
                areas[i].gameObject.SetActive(true);
                area = areas[i].gameObject.GetComponent<AreaScript>();
                if (player.hostChar != null) { playerHost.transform.parent = area.gameObject.transform.Find("Characters"); }
                cameraScript.cameraOptions.maxCameraBoundaries = area.maxCamera;
                cameraScript.cameraOptions.minCameraBoundaries = area.minCamera;
            }
            else {
                areas[i].gameObject.SetActive(false);
            }
        }

    }
}
