using UnityEngine;
using System.Collections;

public class SubAreaScript : AreaScript {


    public AreaScript masterArea;
    // Use this for initialization
    void Start () {
        subArea = true;
	}
	
	// Update is called once per frame
	void Update () {
        gemTot = gems + masterArea.gems;
	}
}
