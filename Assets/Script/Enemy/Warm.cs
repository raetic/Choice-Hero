using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warm : MonoBehaviour
{
    int v = 1;    
    Animator anim;
    Enemy myEnemy;
    float stopT;
    GameObject Player;
    bool isAttack;
    float t;
    [SerializeField] GameObject AttackObj;
    [SerializeField] GameObject Spot;
    bool isBress;
    bool isB;
    public void GoRight()
    {
        v = 1;
        transform.localScale = new Vector3(-1, 1, 0);
    }
    public void GoLeft()
    {
        v = -1;
        transform.localScale = new Vector3(1, 1, 0);
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        myEnemy = GetComponent<Enemy>();
        Player = GameObject.FindGameObjectWithTag("Player");
        myEnemy.isMove = true;
    }

    // Update is called once per frame
    void Attack()
    {
        t += Time.deltaTime;
        if (t >= 1.15f)
        {
           
            if (!isB)
            { isB = true;
                GameObject attack = Instantiate(AttackObj, Spot.transform.position, transform.rotation);
                attack.GetComponent<Rigidbody2D>().AddForce(Vector2.left * v * 250);
                attack.transform.localScale = new Vector3(v*-1, 1, 0);
            }
            if (t >= 1.3f)
            {
                isB = false;
                t = 0;
                isBress = false;
            }
           
        }
    }
    void Update()
    {
        if (transform.position.y < -5) Destroy(gameObject);
        if (transform.position.x > Player.transform.position.x)
        {
            GoRight();
        }
        else
        {
            GoLeft();
        }
        if (Mathf.Abs(transform.position.x - Player.transform.position.x) < 3||isBress)
        {
            isBress = true;
            isAttack = true;
            anim.SetBool("isAttack", true);
            Attack();
        }
        else
        {
            isAttack = false;
            anim.SetBool("isAttack", false);
        }
        if (!isAttack)
        {
            t = 0;
            if (myEnemy.isMove)
            {if(!myEnemy.isAir)
                transform.Translate(Vector2.left * v * 1f * Time.deltaTime);
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
}
