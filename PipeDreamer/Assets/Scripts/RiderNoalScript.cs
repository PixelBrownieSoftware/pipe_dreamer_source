using UnityEngine;
using System.Collections;

public class RiderNoalScript : NoalScript {

    public BoxCollider2D sensor;

    void Awake() {
        sensor = transform.Find("DropOffSensor").gameObject.GetComponent<BoxCollider2D>();
    }

	new void Start () {
        base.Start();
        isPlayable = true;
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();


	}

    void OnTriggerExit2D(Collider2D sensor) {

        if (sensor.gameObject.name == "Collision2")
        {
            canStopManipulating = false;
        }
        if (sensor.gameObject.name != "Collision2")
        {
            canStopManipulating = true;
        }
    }


    void OnTriggerStay2D(Collider2D sensor) {

        if (sensor.gameObject.name == "Collision2") {
            canStopManipulating = false;
        }
        if (sensor.gameObject.name != "Collision2") {
            canStopManipulating = true;
        }
    }


}
