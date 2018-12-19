using UnityEngine;
using System.Collections;

public class NoalScript : BaseNPC {

    public enum noalActions { swimming, diving };
    public noalActions noalActionStates;

	// Use this for initialization
	new public void Start () {
        moveSpeed = 115f;
        base.Start();
        walkTimer = 1;
    }
	
	// Update is called once per frame
	new public void Update () {

        base.Update();

       /* 
        if (h != 0 || v != 0)
        {
            anim_h = h;
            anim_v = v;
            anim.SetBool("IsWalking", true);
        }
        else { anim.SetBool("IsWalking", false); }

        anim.SetFloat("x", anim_h);
        anim.SetFloat("y", anim_v);
        */

    }

   



}
