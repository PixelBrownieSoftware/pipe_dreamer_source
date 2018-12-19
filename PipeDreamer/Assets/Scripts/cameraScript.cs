using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class cameraScript : MonoBehaviour {

    public static cameraScript cameraOptions;
    public GameObject target;

    public Vector2 maxCameraBoundaries;
    public Vector2 minCameraBoundaries;

    public Image blackScrn;

    float speed;
    float timeMove;

    float fade_timer;
    bool fading;

    void Start () {
        timeMove = 0f;
        speed = 1f;
        fadeTimer(0f);
	}

    public void fadeTimer(float fadetime) {
        fading = true;
        fade_timer = fadetime;
    }

    //Added on 19/12/2018
    public IEnumerator Fade()
    {
        fade_timer = 0;
        while (blackScrn.color != Color.clear)
        {
            blackScrn.color = Color.Lerp(Color.clear, Color.black, fade_timer);
            fade_timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        fade_timer = 0;
        while (blackScrn.color != Color.black)
        {
            blackScrn.color = Color.Lerp(Color.black, Color.clear, fade_timer);
            fade_timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    //Added on 19/12/2018
    void GoToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

	void Update () {
        if (cameraOptions == null) {
            cameraOptions = this;
        }

        if (blackScrn != null)
        {
            fade_timer = fading ? fade_timer -= Time.deltaTime : fade_timer += Time.deltaTime;
            blackScrn.color = Color.Lerp(Color.black, Color.clear, fade_timer);

            if (fade_timer < 0 || fade_timer > 1)
            {
                fading = false;
            }
        }

        if (target != null) {
            if (timeMove < speed)
            {

                timeMove = +Time.deltaTime;
                float s = timeMove / speed;

                transform.position = Vector2.Lerp(transform.position, new Vector2(Mathf.Clamp(target.transform.position.x, minCameraBoundaries.x, maxCameraBoundaries.x), Mathf.Clamp(target.transform.position.y, minCameraBoundaries.y, maxCameraBoundaries.y)), s * 5.5f);
            }
        }

        //= new Vector2(Mathf.Clamp(target.transform.position.x, minCameraBoundaries.x, maxCameraBoundaries.x), Mathf.Clamp(target.transform.position.y, minCameraBoundaries.y, maxCameraBoundaries.y));
    }
}
