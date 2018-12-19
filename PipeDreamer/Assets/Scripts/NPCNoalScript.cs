using UnityEngine;
using System.Collections;

public class NPCNoalScript : NoalScript {

	// Use this for initialization
	new void Start () {
        base.Start();
        isPlayable = false;
    }
	
	// Update is called once per frame
	new void Update () {

        print(this.gameObject.layer);
        base.Update();
        switch (manipulated) {

            case isControlled.AI:

                switch (noalActionStates) {

                    case noalActions.swimming:

                        if (walkTimer > 0) {
                            walkTimer = walkTimer - Time.deltaTime;
                        } else {
                            h = Random.Range(-1, 2);
                            v = Random.Range(-1, 2);
                            walkTimer = Random.Range(0.3f, 2);

                            if (h == 0 && v == 0) {
                                int dive = Random.Range(1, 4);
                                if (dive == 2) {

                                    walkTimer = Random.Range(0.3f, 1.2f);
                                    noalActionStates = noalActions.diving;
                                }
                            }
                        }

                        rbody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);

                        break;

                    case noalActions.diving:

                        if (walkTimer > 0) {
                            walkTimer = walkTimer - Time.deltaTime;
                        } else { noalActionStates = noalActions.swimming; }

                        break;

                }
                break;
        }
    }
}
