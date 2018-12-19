using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class CharacterBase : MonoBehaviour {

    public enum isControlled { player, AI};
    public isControlled manipulated;
    protected Rigidbody2D rbody;
    protected Animator anim;

    protected float angle;
    protected float h;
    protected float v;

    protected float anim_h;
    protected float anim_v;
    protected float moveSpeed;
    

    public bool canStopManipulating;
    public bool isPlayable;

    protected string instructionName;
    protected OnScreenInstructions instructions;

    protected bool fading;
    protected float fade_timer;

    public void Start () {
        canStopManipulating = true;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        instructions = GameObject.Find("GUITexture").GetComponent<OnScreenInstructions>();
    }
	

	public void Update () {

        fade_timer = fading ? fade_timer -= Time.deltaTime : fade_timer += Time.deltaTime;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(0,0.7f,1f,1), Color.white, fade_timer);

        if (fade_timer < 0 || fade_timer > 1)
        {
            fading = false;
        }

        switch (manipulated)
        {
            case isControlled.player:

                h = Input.GetAxisRaw("Horizontal");
                v = Input.GetAxisRaw("Vertical");
                rbody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);

                break;
        }
    }

    public void shootGlow()
    {
        fading = true;
        fade_timer = 0.05f;
    }

    public void triggerInstrctions() {
        if (isPlayable && this.gameObject.name != "Bed") {
                instructions.showInstructions(instructionName);
        }
    }

}
