using UnityEngine;
using System.Collections;

public class PersonScript : BaseNPC {

    public GameObject sensor;
    public GameObject speechBubble;
    protected float speechtimer;
    protected float talktimer;
    public AudioClip talk;
    bool isHoldingItem;
    public GameObject item;

	new public void Start () {
        moveSpeed = 85f;
        base.Start();
        speechBubble = transform.Find("Speech").gameObject;
        speechtimer = 0;
    }

    // Update is called once per frame
    new public void Update() {
        base.Update();
        if (speechtimer > 0) { speechtimer = speechtimer - Time.deltaTime; } else { speechBubble.SetActive(false); }
    }

    void OnTriggerStay2D(Collider2D col) {

        

        if (col.gameObject.name == "SpeechHit" && manipulated == isControlled.AI && speechtimer < 0.1) {
            speechtimer = 1f;
            generateSpeechBubble();

        }
    }

    public void generateSpeechBubble() {

        speechBubble.SetActive(true);
        SoundManager.SFX.playSoundEffect(talk);
    }


}
