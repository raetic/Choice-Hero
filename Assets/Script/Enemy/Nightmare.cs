using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare : MonoBehaviour
{
    int v = 1;
    float t;
    Animator anim;
    float r;
    Enemy myEnemy;
    float stopT;
    public void GoRight()
    {
        v = -1;
        transform.localScale = new Vector3(-1, 1, 0);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        myEnemy = GetComponent<Enemy>();
        myEnemy.isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (myEnemy.isMove)
        {
            if (!myEnemy.isAir)
            {
                transform.Translate(Vector2.left * v * 3 * Time.deltaTime);
            }
            if (transform.position.y < -5) Destroy(gameObject);
        }
        else
        {
            stopT += Time.deltaTime;
            if (stopT > 0.5f)
            {
                myEnemy.isMove = true;
                stopT = 0;
            }
        }
    }

}
