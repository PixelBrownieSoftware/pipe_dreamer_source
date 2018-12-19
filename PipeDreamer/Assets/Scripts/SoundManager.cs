using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

    public static SoundManager SFX;
    public AudioSource Asrc;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (SFX == null) {
            SFX = this;

        }
	}

    public void playSoundEffect(AudioClip sound) {

        Asrc.clip = sound;
        Asrc.Play();
    }

}
