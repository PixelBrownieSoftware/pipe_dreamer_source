using UnityEngine;
using System.Collections;

public class OldBumPerson : PersonScript {
    
    public Sprite money;
    public Sprite KeyArea;

    public GameObject Key;
    public GameObject keyPar;
    public SpriteRenderer speech;

    public bool isSatisfied;
    public WorldManager world;

    new void Start() {
        base.Start();

        speech = speechBubble.GetComponent<SpriteRenderer>();
        speech.sprite = money;
        isSatisfied = false;
        keyPar = WorldManager.world.area.gameObject;
    }

    // Update is called once per frame
    new void Update() {
        base.Update();

        speech = speechBubble.GetComponent<SpriteRenderer>();

        if (item != null) {
            if (item.name == "MoneyBag")
            {
                print("Thanks!");
                speech.sprite = KeyArea;
                item.transform.parent = this.transform;
                item.transform.position = this.transform.position;
                item = item.gameObject;
                GameObject key = Instantiate(Key, transform.position, Quaternion.identity) as GameObject;
                key.transform.parent = keyPar.transform;
                speechtimer = 1f;
                generateSpeechBubble();
                isSatisfied = true;
                Destroy(item.gameObject);
            }
        }
        

        if (!isSatisfied) {
            speech.sprite = money;
            if (item != null) {
                if (item.name != "Key") { speech.sprite = money; }
            }
        }
    }


    void OnTriggerStay2D(Collider2D col) {

        if (Input.GetKeyDown(KeyCode.Z) && !isSatisfied) {
            col.transform.parent = this.transform;
            col.transform.position = this.transform.position;
            item = col.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

            if (col.name == "SpeechHit") {

                print(col.name);
                speechtimer = 1f;
                generateSpeechBubble();
            
        }
    }
}
