using UnityEngine;
using System.Collections;

public class GemScript : MonoBehaviour {

    public PlayerScript player;
    public AreaScript area;
    public WorldManager totalGems;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        area = WorldManager.world.area;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col != null)
        {
            if (col.gameObject.GetComponent<CharacterBase>())
            {
                if (col.gameObject.GetComponent<CharacterBase>().manipulated == CharacterBase.isControlled.player)
                {
                    area.gems++;
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

}