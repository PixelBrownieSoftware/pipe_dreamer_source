using UnityEngine;
using System.Collections;

public class BaseNPC : CharacterBase {

    public PlayerScript manipulator;
    protected float walkTimer;

	new public void Start () {
        base.Start();
	}

	new public void Update () {
        base.Update();
        switch (manipulated) {
            case isControlled.player:

                if (Input.GetKeyDown(KeyCode.X) && canStopManipulating) {
                    dismountPlayer();
                }
            break;
        }
	}

    public void dismountPlayer() {
        manipulator.hostChar = null;
        manipulator.gameObject.SetActive(true);
        manipulator.transform.position = transform.position;
        cameraScript.cameraOptions.target = manipulator.gameObject;
        manipulator = null;
        rbody.velocity = Vector2.zero;
        manipulated = isControlled.AI;
    }

}
