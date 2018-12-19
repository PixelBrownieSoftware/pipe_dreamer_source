using UnityEngine;
using System.Collections;

public class LatchScript : BaseNPC {

    public CharacterBase nextHost;
    public GameObject beam;
    

    new void Start () {
        base.Start();
        instructionName = "Latch Instructions";
        moveSpeed = 0f;
        isPlayable = true;
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        switch(manipulated) {
            case isControlled.player:
                if (Input.GetKeyDown(KeyCode.Z) && GameObject.Find("Hitbox") == false)
                {
                    Vector3 dir = new Vector3(h, v, 0).normalized;
                    angle = 360 - Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                    GameObject shot = Instantiate(beam, transform.position, Quaternion.Euler(new Vector3(0, 0, angle))) as GameObject;
                    shot.GetComponent<possesBeamScript>().shotFromLatch = true;
                    shot.GetComponent<possesBeamScript>().latch = this.gameObject.GetComponent<LatchScript>();
                }


                break;

        }

        
    }
}
