using UnityEngine;
using System.Collections;

public class FoodPerson : PersonScript
{

    public string food;

    public Sprite chicken;
    public Sprite greenmeal;
    public Sprite steakandpotatoes;
    public Sprite onigiri;
    public Sprite heart;

    public AreaScript area;
    public SpriteRenderer speech;

    public bool isSatisfied;

    // Use this for initialization
    new void Start()
    {
        area = GameObject.Find("Mall").GetComponent<AreaScript>();
        base.Start();
        isSatisfied = false;
        speechBubble.SetActive(false);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        speech = speechBubble.GetComponent<SpriteRenderer>();

        if (item != null)
        {
            if (item.name == food)
            {
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

        if (!isSatisfied)
        {
            if (food == "SteakandPotatoes") { speech.sprite = steakandpotatoes; }
            if (food == "Onigiri") { speech.sprite = onigiri; }
            if (food == "GreenMeal") { speech.sprite = greenmeal; }
            if (food == "Chicken") { speech.sprite = chicken; }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isSatisfied && (col.gameObject.name == food))
        {
            col.transform.parent = this.transform;
            col.transform.position = this.transform.position;
            item = col.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "SpeechHit" && !isSatisfied)
        {
            print(col.name);
            speechtimer = 1f;
            generateSpeechBubble();
        }
    }

}
