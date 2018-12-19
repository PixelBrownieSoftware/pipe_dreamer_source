using UnityEngine;
using System.Collections;

public class PlayerScript : CharacterBase {

    public enum canBeControlled { control, possesing, stop }
    public canBeControlled isControled;

    public CharacterBase hostChar;
    public GameObject beam;

    bool canShoot;
    WorldManager world;

	// Use this for initialization
	new void Start () {
        base.Start();
        moveSpeed = 95f;
        world = GameObject.Find("World").GetComponent<WorldManager>();
	}
	
	// Update is called once per frame
	new void Update () {

        if (world.areaNum == 8) { canShoot = false; } else { canShoot = true; }

        base.Update();

        if (h != 0 || v != 0)
        {
            anim_h = h;
            anim_v = v;
            anim.SetBool("IsWalking", true);
        }
        else { anim.SetBool("IsWalking", false); }

        anim.SetFloat("x", anim_h);
        anim.SetFloat("y", anim_v);

        switch (manipulated) {
            case isControlled.player:

                //player needs to have two states to serve it's function
                switch (isControled) {

                    case canBeControlled.control:

                        if (Input.GetKeyDown(KeyCode.Z) && GameObject.Find("Hitbox") == false) {
                            
                            Vector3 dir = new Vector3(h, v, 0).normalized;
                            angle = 360 - Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                            GameObject shot = Instantiate(beam, transform.position, Quaternion.Euler(new Vector3(0,0, angle))) as GameObject;
                            shot.GetComponent<possesBeamScript>().shotFromLatch = false;
                            shot.GetComponent<possesBeamScript>().parent = this.gameObject.GetComponent<PlayerScript>();
                            shootGlow();
                        }
                    break;

                    case canBeControlled.possesing:
                        
                        if (hostChar == null) {
                            isControled = canBeControlled.control;
                        } else {
                            cameraScript.cameraOptions.target = hostChar.gameObject;
                            hostChar.manipulated = isControlled.player;
                            this.gameObject.SetActive(false);
                        }

                        break;

                }
                //manipulate stuff
                

                break;
        }

	}
}
