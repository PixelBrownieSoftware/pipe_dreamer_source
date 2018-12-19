using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class possesBeamScript : MonoBehaviour {

    public LatchScript latch;
    public PlayerScript parent;
    float delay = 0.12f;
    float speed = 25;

    public bool shotFromLatch;

    public AudioClip posses;

    void Start () {
        if (shotFromLatch == true) {
            delay = 0.2f;
            transform.Translate(Vector2.up * 18);
        } else {
            transform.Translate(Vector2.up * 15);
        }
            
    }

    void OnTriggerEnter2D(Collider2D col) {

        if (col.CompareTag("NPC")) {
            if (col.gameObject.GetComponent<CharacterBase>().manipulated == CharacterBase.isControlled.AI)
            {

                CharacterBase host = col.GetComponent<CharacterBase>();

                if (parent != null && host.isPlayable)
                {

                    //changes the parent's host and then assigns the host's manipulator
                    parent.hostChar = host;
                    parent.hostChar.GetComponent<BaseNPC>().manipulator = parent;

                    //teleport player --> host
                    parent.transform.position = transform.position;
                    SoundManager.SFX.playSoundEffect(posses);

                    parent.hostChar.triggerInstrctions();
                    parent.hostChar.shootGlow();

                    //set the player's state to possesing
                    parent.isControled = PlayerScript.canBeControlled.possesing;
                    Destroy(this.gameObject);
                }

                if (latch != null)
                {

                    //sets the Latch's host and this object's parent
                    latch.nextHost = host;
                    parent = latch.manipulator;

                    //set upcoming host's manipulator
                    latch.nextHost.GetComponent<BaseNPC>().manipulator = parent;

                    //dismounts the player for a breif amount of time and set the latch to AI
                    latch.dismountPlayer();
                    latch.manipulated = CharacterBase.isControlled.AI;

                    latch.manipulator = null;

                    //sets the player's host to the latch's host and manipulator to the latch's next host
                    parent.hostChar = latch.nextHost;
                    parent.hostChar.GetComponent<BaseNPC>().manipulator = parent;

                    //teleport the player to the host
                    parent.transform.position = parent.hostChar.transform.position;
                    parent.isControled = PlayerScript.canBeControlled.possesing;


                    SoundManager.SFX.playSoundEffect(posses);
                    Destroy(this.gameObject);
                }
            }
        }
        
    }


	void Update () {
        transform.Translate(Vector2.up * 37 * speed * Time.deltaTime);
        if (delay > 0.1f) {
            delay = delay - Time.deltaTime;
        } else {
            Destroy(this.gameObject);
        }
	}
}
