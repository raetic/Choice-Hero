using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    int v = 1;
    Animator anim;
    Enemy myEnemy;
    float stopT;
    GameObject Player;
    bool isAttack;
    float t;
    int pattern;
    float turn;
    Rigidbody2D rigid;
    bool isJump;
    [SerializeField] GameObject AttackPrefebs;
    [SerializeField] GameObject AttackObj;
    [SerializeField] GameObject AttackPoint;
    float speed=2;

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
        rigid = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        myEnemy.isMove = true;
        Invoke("Think", 2);
    }
    void Think()
    {
        int rand = Random.Range(1, 5);
        if (rand <= 3)
        {
            anim.SetTrigger("Attack1");
            Invoke("Attack", 0.3f);
            Invoke("Think", 1.5f);
        }
        else
        {
            anim.SetBool("isAttack", true);
            myEnemy.isMove = false;
            Invoke("at2", 1f);
        }


    }
    void at2()
    {
        myEnemy.isMove = true;
        AttackObj.SetActive(true);
        speed = 4;
        Invoke("noAttack", 1);
    }
   
    void Attack()
    {
        for (int i = -1; i < 2; i++)
        {
            GameObject fire = Instantiate(AttackPrefebs, AttackPoint.transform.position, transform.rotation);
            fire.GetComponent<Rigidbody2D>().AddForce(new Vector2(14,i*Random.Range(1,4))*8*v);
            fire.transform.localScale = new Vector3(-v, 1, 0);
        }
    }


    void noAttack()
    {
        anim.SetBool("isAttack", false);
        AttackObj.SetActive(false);
        speed = 2;
        Invoke("Think", 2);

    }

    void Update()
    {

        if (!myEnemy.isAir)
        {
            if (myEnemy.isMove && !isAttack)
            {
                turn += Time.deltaTime;
                if (turn > 0.5f)
                {
                    if (transform.position.x < Player.transform.position.x)
                    {
                        GoRight();
                        turn = 0;
                    }
                    else
                    {
                        GoLeft();
                        turn = 0;
                    }
                }
                transform.Translate(Vector2.right * v  *speed * Time.deltaTime);
            }

        }

    }

}
