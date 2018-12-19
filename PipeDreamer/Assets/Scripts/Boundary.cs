using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boundary : MonoBehaviour {

    public int gemsRequired;
    GameObject parent;
    Text text;

    public GameObject item;

    public int type;

    public int[] colourCode;


	// Use this for initialization
	void Start () {
        text = GameObject.Find("GemsNeeded").GetComponent<Text>();
        parent = transform.parent.gameObject;
	}
	

	void Update () {

        //if the gems meets the required amount
        if (WorldManager.world.totalGems >= gemsRequired && type == 0) {
            parent.gameObject.SetActive(false);
        }


        // colour puzzle
        if (type == 2) {
            GameObject puzzleObj = GameObject.Find("ColourPuzzle");
            PuzzleTiles[] tiles = puzzleObj.GetComponentsInChildren<PuzzleTiles>();

            int correctTiles = 0;
            int neededCorrectTiles = 0;
            for (int i = 0; i < tiles.Length; i++) {
                    
                        if (tiles[i].thisSprite.sprite == tiles[i].redTile) {
                            correctTiles++;
                        } 
                        neededCorrectTiles++;
            }

            if (neededCorrectTiles == correctTiles) {
                parent.gameObject.SetActive(false);
            }
        }

        if (type == 3) {
            GameObject Customers = GameObject.Find("Customers");
            ClothesPerson[] people = Customers.GetComponentsInChildren<ClothesPerson>();

            int satisfiedCustomers = 0;
            int neededSatisfiedCustomers = 0;
            for (int i = 0; i < people.Length; i++) {

                if (people[i].isSatisfied)
                {
                    satisfiedCustomers++;
                }
                neededSatisfiedCustomers++;
            }

            if (neededSatisfiedCustomers == satisfiedCustomers) {
                parent.gameObject.SetActive(false);
            }

        }

        if (type == 4) {
            if (transform.Find("Key"))
            {
                print("Thanks!");
                item.transform.parent = this.transform;
                item.transform.position = this.transform.position;
                item = item.gameObject;
                Destroy(item.gameObject);
            }
        }

        if (type == 5) {
            GameObject Customers = GameObject.Find("Customers (cafe)");
            FoodPerson[] people = Customers.GetComponentsInChildren<FoodPerson>();

            int satisfiedCustomers = 0;
            int neededSatisfiedCustomers = 0;
            for (int i = 0; i < people.Length; i++)
            {

                if (people[i].isSatisfied)
                {
                    satisfiedCustomers++;
                }
                neededSatisfiedCustomers++;
            }

            if (neededSatisfiedCustomers == satisfiedCustomers)
            {
                parent.gameObject.SetActive(false);
            }
        }

    }


    void OnTriggerStay2D(Collider2D col) {

        if (type == 0)  {
            if (col.gameObject.GetComponent<CharacterBase>().manipulated == CharacterBase.isControlled.player) {
                text.text = "Gems needed: " + gemsRequired;
            }
        }

        if (type == 1) {
            if (col.gameObject.name == "Leem") {
                col.gameObject.GetComponent<CharacterBase>().canStopManipulating = false;
            } 
        }

        if (type == 4) {

            if (Input.GetKeyDown(KeyCode.Z) && col.CompareTag("Item"))
            {
                if (col.gameObject.name == "Key(Clone)") {

                    col.transform.parent = this.transform;
                    col.transform.position = this.transform.position;
                    item = col.gameObject;
                    parent.gameObject.SetActive(false);
                }
            }
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (type == 0) {
            text.text = "";
        }

        if (type == 1) {
            if (col.gameObject.name == "Leem") {
                col.gameObject.GetComponent<CharacterBase>().canStopManipulating = true;
            }
        }
    }

        void OnTriggerExit2D() {
       
    }

}
