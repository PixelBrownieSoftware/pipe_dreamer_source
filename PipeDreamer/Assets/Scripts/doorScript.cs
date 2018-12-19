using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{

    public WorldManager area;
    public int worldID;
    public Vector2 teleportLocation;
    public Text worldShow;
    public bool isWorldDoor;

    //Changed on 19/12/2018
    //Added a function called teleport

    void OnTriggerStay2D(Collider2D col)
    {
        if (isWorldDoor)
        {
            //World doors can only teleport players
            if (col.CompareTag("Player"))
            {
                if (worldID != 11)
                {
                    Teleport();
                }
                else { SceneManager.LoadScene("End"); }
            }

            if (col.gameObject.name == "Person")
            {
                GenericPerson person = col.GetComponent<GenericPerson>();
                //checks item person is holding
                if (person.item != null)
                {
                    //if the player isn't holding the key, they can leave the world
                    if (person.item.name != "Key")
                    {
                        Teleport();
                    }
                    //if the person holds nothing it proceeds
                }
            }


        }
        else
        {
            //given it is a subworld door
            if (col.CompareTag("NPC") && col.GetComponent<CharacterBase>().manipulated == CharacterBase.isControlled.player)
            {

                //checks if it is the person NPC
                if (col.gameObject.name == "Person")
                {

                    GenericPerson person = col.GetComponent<GenericPerson>();
                    //checks item person is holding
                    if (person.item != null)
                    {

                        //if the player isn't holding clothes, they can go
                        if (person.item.name != "RedClothes" || person.item.name != "BlueClothes")
                        {
                            Teleport();
                        }

                        //if the person holds nothing it proceeds
                    }
                    else
                    {
                        Teleport();
                    }
                }
                else
                {
                    Teleport();
                }

            }
            else
            {
                //if it's a player, proceed
                if (col.CompareTag("Player"))
                {
                    Teleport();
                }
            }

        }

    }

    void Teleport()
    {
        WorldManager.world.areaNum = worldID;
        WorldManager.world.teleportPlayer(teleportLocation);
        cameraScript.cameraOptions.transform.position = teleportLocation;
        cameraScript.cameraOptions.StartCoroutine(cameraScript.cameraOptions.Fade());
    }
}
