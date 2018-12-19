using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AreaScript : MonoBehaviour {

    public int gems;
    public int gemTot;

    public Vector2 maxCamera;
    public Vector2 minCamera;
    public bool subArea;

    public int highestGems;
    public SubAreaScript[] subAreas;

    // Use this for initialization
    void Start () {
        subArea = false;
    }
	
	// Update is called once per frame
	void Update () {
        

        if (subAreas.Length > 0) {
            int tot = 0; 
            for (int i = 0; i < subAreas.Length; i++) {
                tot += subAreas[i].gems;
            }
            gemTot = gems + tot;
        }

        if (gemTot > highestGems) {
            highestGems = gemTot;
        }

    }

}
