using UnityEngine;
using System.Collections;

public class GenericPerson : PersonScript {
    
    GameObject itemPar;
    float itemCoolDown;
    
	// Use this for initialization
	new void Start () {
        base.Start();
        isPlayable = true;

        instructionName = "Person Instructions";
        sensor = transform.Find("SpeechHit").gameObject;
        sensor.SetActive(false);
        speechBubble.SetActive(false);
    }
	
	// Update is called once per frame
	new void Update () {

        if (talktimer > 0) { talktimer = talktimer - Time.deltaTime; } else { sensor.SetActive(false); }
        if (itemCoolDown > 0) { itemCoolDown -= Time.deltaTime; }

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

                if (Input.GetKeyDown(KeyCode.Z))
                {
                    sensor.SetActive(true);
                    talktimer = 0.1f;
                    speechtimer = 0.5f;
                    generateSpeechBubble();

                    if (item != null && itemCoolDown < 0.08f) {
                        if (!sensor.CompareTag("NPC")) {
                            item.transform.parent = WorldManager.world.area.gameObject.transform.Find("Characters").transform;
                            item = null;
                        }
                    }

                }

                break;

            case isControlled.AI:

                if (walkTimer > 0)
                {
                    walkTimer = walkTimer - Time.deltaTime;
                }
                else
                {
                    h = Random.Range(-1, 2);
                    v = Random.Range(-1, 2);
                    walkTimer = Random.Range(0.3f, 2);
                }

                rbody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);
                break;

        }

    }
    void OnTriggerStay2D(Collider2D col) {

        switch (manipulated) {

            case isControlled.player:

                if (col.CompareTag("Item") && Input.GetKeyDown(KeyCode.Z) && item == null)
                {
                    itemPar = col.transform.parent.gameObject;
                    col.transform.parent = this.transform;
                    col.transform.position = this.transform.position;
                    item = col.gameObject;
                    itemCoolDown = 0.1f;
                }

                break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        switch (manipulated)
        {

            case isControlled.player:

                if (col.CompareTag("Item") && Input.GetKeyDown(KeyCode.Z) && item == null)
                {
                    itemPar = col.transform.parent.gameObject;
                    col.transform.parent = this.transform;
                    col.transform.position = this.transform.position;
                    item = col.gameObject;
                    itemCoolDown = 0.1f;
                }

                break;
        }

    }


}
