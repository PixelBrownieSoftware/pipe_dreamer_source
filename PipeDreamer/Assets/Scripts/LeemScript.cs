using UnityEngine;
using System.Collections;

public class LeemScript : BaseNPC {

    // Use this for initialization
    new void Start () {
        moveSpeed = 145f;
        base.Start();
        walkTimer = 1;
        instructionName = "Leem Instructions";
        isPlayable = true;
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();

        if (h != 0 || v != 0)
        {
            anim_h = h;
            anim_v = v;
            anim.SetBool("IsWalking", true);
        }
        else { anim.SetBool("IsWalking", false); }

        anim.SetFloat("x", anim_h);
        anim.SetFloat("y", anim_v);

        switch (manipulated) {
            case isControlled.AI:

                if (walkTimer > 0) {
                    walkTimer = walkTimer - Time.deltaTime;
                }
                else {
                    h = Random.Range(-1,1);
                    v = Random.Range(-1, 1);
                    walkTimer = Random.Range(0.3f,2);
                }

                rbody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);


                break;

        }
    }
}
