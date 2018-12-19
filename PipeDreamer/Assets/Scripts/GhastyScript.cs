using UnityEngine;
using System.Collections;

public class GhastyScript : BaseNPC {

    public enum enemyAI { idle,attack }
    public enemyAI enemyActionStates;
    public GameObject target;
    float offDelay;


    // Use this for initialization
    new void Start() {
        moveSpeed = 45f;
        base.Start();
        walkTimer = 1;
        isPlayable = true;
    }

    // Update is called once per frame
    new void Update() {

        LayerMask layer1;
        layer1 = LayerMask.GetMask("Collision");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position - transform.position, 90, layer1);
        Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.green);

        if (hit) {
            enemyActionStates = enemyAI.idle;
        }

        if (offDelay > 0) { enemyActionStates = enemyAI.idle; offDelay = offDelay - Time.deltaTime; }


        base.Update();
        switch (manipulated) {

            case isControlled.AI:
                switch (enemyActionStates) {
                    
                    case enemyAI.idle:
                        moveSpeed = 45f;

                        if (walkTimer > 0) {
                            walkTimer = walkTimer - Time.deltaTime;
                        }
                        else {
                            h = Random.Range(-1, 1);
                            v = Random.Range(-1, 1);
                            walkTimer = Random.Range(0.3f, 2);
                        }

                        rbody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);

                        if (100 > Mathf.Abs(target.transform.position.x - transform.position.x)){
                            enemyActionStates = enemyAI.attack;
                        }

                        break;

                    case enemyAI.attack:
                        moveSpeed = 55f;

                        v = target.transform.position.y > transform.position.y ? 1 : -1;
                        h = target.transform.position.x > transform.position.x ? 1 : -1;
                        rbody.velocity = new Vector2(h * moveSpeed, v * moveSpeed);

                        if (100 < Mathf.Abs(target.transform.position.x - transform.position.x)) {
                            enemyActionStates = enemyAI.idle;
                        }

                        break;
                }
                break;

            case isControlled.player:
                offDelay = 3f;
                break;
        }
    }
}
