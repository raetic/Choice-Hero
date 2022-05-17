using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
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
    [SerializeField] GameObject boss2prefebs;

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
        anim =transform.GetChild(0).GetComponent<Animator>();
        myEnemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        myEnemy.isMove = true;
        anim.SetBool("isJump", true);
        Invoke("Think", 3);
    }
    void Think()
    {
        int rand = Random.Range(1, 6);
        isAttack = true;
        myEnemy.isMove = false;
        if (rand <=4)
        {
            anim.SetTrigger("Attack1");
            Invoke("Attack", 0.3f);
            Invoke("Think", 1.5f);
            Invoke("noAttack", 0.5f);
        }
        else
        {
            anim.SetBool("Attack2",true);
            StartCoroutine("Attack2Cor");
            Invoke("Think", 10);
            Invoke("noAttack", 8f);
        }
      

    }
    IEnumerator Attack2Cor()
    {
        int t = 0;
        while (t < 16)
        {
            t++;
            int rand = Random.Range(-600, 600);
            float x = GameObject.FindGameObjectWithTag("MainCamera").transform.position.x;
            Instantiate(boss2prefebs, new Vector3(x + rand / 100, 3.2f), transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }
    }
    void Attack()
    {
        Collider2D col = Physics2D.OverlapBox(transform.position+new Vector3(1.5f,0)*v, new Vector2(2f, 2), 0,LayerMask.GetMask("Player"));
        if (col != null)
        {
            col.gameObject.GetComponent<Player>().onHit(10);
        }
    }
 
   
    void noAttack()
    {
        anim.SetBool("Attack2",false);
        isAttack = false;
        myEnemy.isMove = true;
    }

    void Update()
    {
       
        if (!myEnemy.isAir) {
            if (myEnemy.isMove&&!isAttack)
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
                transform.Translate(Vector2.right * v * 3.5f * Time.deltaTime);
            }
       
        }

    }
    
}
