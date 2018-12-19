using UnityEngine;
using System.Collections;

public class PuzzleTiles : MonoBehaviour {

    public enum tileType { colour, match, clothes }
    public tileType tileT;

    public Sprite redTile;
    public Sprite blueTile;

    public SpriteRenderer thisSprite;

    public string clothes;

    public Sprite blueClothesChar;
    public Sprite redClothesChar;

    public Sprite blueClothes;
    public Sprite redClothes;

    public AudioClip talk;
    public GameObject speechBubble;

    // Use this for initialization
    void Start () {
        thisSprite = GetComponent<SpriteRenderer>();
	}

    void OnTriggerEnter2D(Collider2D col) {
        switch (tileT) {

            case tileType.colour:
                //to have the player switch the colour of the tile

                if (col.gameObject.GetComponent<CharacterBase>().manipulated == CharacterBase.isControlled.player) {
                    if (thisSprite.sprite == blueTile) {
                        thisSprite.sprite = redTile;
                    } else  if (thisSprite.sprite == redTile) {
                        thisSprite.sprite = blueTile;
                    }
                }
                break;

            case tileType.match:


                break;

            case tileType.clothes:
               
               
                break;
        }
    }

    void generateSpeechBubble()
    {

        speechBubble.SetActive(true);
        SoundManager.SFX.playSoundEffect(talk);
    }

    void OnTriggerExit2D(Collider2D col) {
        switch (tileT) {

            case tileType.colour:


                break;

            case tileType.match:


                break;
        }
    }


    // Update is called once per frame
    void Update () {
        switch (tileT) {

            case tileType.colour:


                break;

            case tileType.match:


                break;
        }
	}
}
