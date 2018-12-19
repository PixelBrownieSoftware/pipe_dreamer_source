using UnityEngine;
using System.Collections;

public class BedScript : BaseNPC {
    

	// Use this for initialization
	new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        switch (manipulated) {

            case isControlled.player:

                dismountPlayer();
                cameraScript.cameraOptions.fadeTimer(0f);
                WorldManager.world.areaNum = 0;
                WorldManager.world.teleportPlayer(new Vector2(0,0));

                break;

        }
	}
}
