using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnScreenInstructions : MonoBehaviour {

    public bool hasRiddenBefore;

    public GUITexture moving;
    public GUITexture shooting;
    public GUITexture getOff;

    public List<GameObject> instructionList = new List<GameObject>();
    float instructDelay;
    int moving_stage;

    GUITexture instructionToShow;

    void Start () {

        hasRiddenBefore = false;

        getOff.gameObject.SetActive(false);

        for (int i = 0; i < instructionList.Count; i++)
        {
            {

                instructionList[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instructDelay > 0) { instructDelay -= Time.deltaTime; }

        if (WorldManager.world.areaNum == 7)
        {
            if (moving_stage == 0) {
                if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) {
                    moving.enabled = true;
                } else {
                    moving_stage = 1;
                    moving.enabled = false;
                }
            }
            
            if (moving_stage == 1) {
                if (!Input.GetKeyDown(KeyCode.Z)) {
                    shooting.enabled = true;
                } else {
                    moving_stage = 2;
                    shooting.enabled = false;
                }
            }
        }

        if ((instructDelay < 0) && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X)) && instructionToShow.enabled == true)
        {
            setFalse();
        }

    }

    public void showInstructions(string character) {

        for (int i = 0; i < instructionList.Count; i++)
        {
            if (instructionList[i].gameObject.name == character)
            {
                if (!hasRiddenBefore)
                {
                    getOff.gameObject.SetActive(true);
                }
                instructionToShow = instructionList[i].GetComponent<GUITexture>();
                instructDelay = 0.5f;
                instructionToShow.gameObject.SetActive(true);
                
            } else {
                instructionList[i].SetActive (false);
            }
        }
        }

    void setFalse()
    {
        if (!hasRiddenBefore) { hasRiddenBefore = true; getOff.gameObject.SetActive(false); }

        instructionToShow.enabled = false;
    }

}
