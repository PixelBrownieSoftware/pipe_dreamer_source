using UnityEngine;
using System.Collections;

public class ChefPerson : PersonScript {

    public GameObject[] itemsPresent;

    public GameObject onigiri;
    public GameObject greenfood;
    public GameObject steakAndPotatoes;
    public GameObject grilledChicken;

    int foodNum;
    float itemCoolDown;

	new void Start () {
        base.Start();
	}
	

	new void Update () {
        base.Update();

        if (itemCoolDown > 0) { itemCoolDown -= Time.deltaTime; }
        itemsPresent = GameObject.FindGameObjectsWithTag("Item");

        if (transform.Find("Onigiri") || transform.Find("SteakandPotatoes") || transform.Find("GreenMeal") || transform.Find("Chicken"))
        {
            item.transform.parent = this.transform;
            item.transform.position = this.transform.position;
            item = item.gameObject;
            Destroy(item.gameObject);
        }

        if (itemsPresent.Length == 0 && WorldManager.world.areaNum == 6) {

            foodNum = Random.Range(1, 5);
            if (foodNum == 1)
            {
               GameObject food = Instantiate(onigiri, transform.position, Quaternion.identity) as GameObject;
               food.name = "Onigiri";
               food.transform.parent = WorldManager.world.area.gameObject.transform.Find("Characters").transform;
               food = null;
               itemCoolDown = 0.02f;
            }

            if (foodNum == 2)
            {
                GameObject food = Instantiate(greenfood, transform.position, Quaternion.identity) as GameObject;
                food.name = "GreenMeal";
                food.transform.parent = WorldManager.world.area.gameObject.transform.Find("Characters").transform;
                food = null;
                itemCoolDown = 0.02f;
            }

            if (foodNum == 3)
            {
                GameObject food = Instantiate(steakAndPotatoes, transform.position, Quaternion.identity) as GameObject;
                food.name = "SteakandPotatoes";
                food.transform.parent = WorldManager.world.area.gameObject.transform.Find("Characters").transform;
                food = null;
                itemCoolDown = 0.02f;
            }

            if (foodNum == 4)
            {
                GameObject food = Instantiate(grilledChicken, transform.position, Quaternion.identity) as GameObject;
                food.name = "Chicken";
                food.transform.parent = WorldManager.world.area.gameObject.transform.Find("Characters").transform;
                food = null;
                itemCoolDown = 0.02f;
            }

        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (Input.GetKeyDown(KeyCode.Z) && (col.name == "Onigiri" || col.name == "SteakandPotatoes" || col.name == "Chicken" || col.name == "GreenMeal") && itemCoolDown < 0f)
        {
            col.transform.parent = this.transform;
            col.transform.position = this.transform.position;
            item = col.gameObject;
        }
    }


}
