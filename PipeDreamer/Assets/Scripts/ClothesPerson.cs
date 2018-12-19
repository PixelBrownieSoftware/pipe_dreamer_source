using UnityEngine;
using System.Collections;

public class ClothesPerson : PersonScript {

    public string clothes;

    public Sprite blueClothes;
    public Sprite redClothes;
    public Sprite heart;

    public AreaScript area;
    public SpriteRenderer speech;

    public bool isSatisfied;

	// Use this for initialization
	new void Start () {
        area = GameObject.Find("Mall").GetComponent<AreaScript>();
        base.Start();
        isSatisfied = false;
        speechBubble.SetActive(false);
    }
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        speech = speechBubble.GetComponent<SpriteRenderer>();

        if (item != null) {
            if (item.name == clothes) {
                print("Thanks!");
                speech.sprite = heart;
                item.transform.parent = this.transform;
                item.transform.position = this.transform.position;
                item = item.gameObject;
                area.gems++;
                speechtimer = 1f;
                generateSpeechBubble();
                isSatisfied = true;
                Destroy(item.gameObject);
            }
        }

        if (!isSatisfied) {

            if (clothes == "BlueClothes") { speech.sprite = blueClothes; }
            if (clothes == "RedClothes") { speech.sprite = redClothes; }

        }
    }

    void OnTriggerStay2D(Collider2D col) {

        if (Input.GetKeyDown(KeyCode.Z) && !isSatisfied && (col.gameObject.name == clothes)) {
            col.transform.parent = this.transform;
            col.transform.position = this.transform.position;
            item = col.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {

            if (col.name == "SpeechHit" && !isSatisfied) {

                print(col.name);
                speechtimer = 1f;
                generateSpeechBubble();
            
        }
    }


}
