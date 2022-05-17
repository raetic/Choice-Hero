using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
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
    [SerializeField] GameObject enemyAttack;

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
        anim.SetBool("isJump", true);
        Invoke("Think",2);
    }
    void Think()
    {
        int rand = Random.Range(0 , 2);
        isAttack = true;
        myEnemy.isMove = false;
        if (rand == 0) { anim.SetTrigger("Attack1");
            Invoke("SkullThrow", 0.3f);
            Invoke("Think", 1.5f);
        }
        else { anim.SetTrigger("Attack2");
            Invoke("SkullMeteo", 0.5f);
            Invoke("Think", 2);
        }
        Invoke("noAttack", 0.7f);
     
    }
    void SkullThrow()
    {
        GameObject skull = Instantiate(enemyAttack, transform.position, transform.rotation);
        skull.GetComponent<Rigidbody2D>().AddForce(Vector2.left * v * 400);
    }
    void SkullMeteo()
    {
        for(int i = 0; i < 5; i++)
        {
            GameObject skull = Instantiate(enemyAttack, Player.transform.position+new Vector3(-5+i*2.5f,7), transform.rotation);
            skull.GetComponent<Rigidbody2D>().AddForce(Vector2.left * v * 150);
            skull.GetComponent<Rigidbody2D>().AddForce(Vector2.down *450);
        }
    }
    void noAttack()
    {
        isAttack = false;
        myEnemy.isMove = true;
    }

    void Update()
    {
        if (transform.position.y < -5) Destroy(gameObject);      
        if (myEnemy.isMove)
        {
            turn += Time.deltaTime;
            if (turn > 0.3f)
            {
                if (transform.position.x > Player.transform.position.x)
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
            transform.Translate(Vector2.left * v * 2f * Time.deltaTime);
            if (Player.transform.position.y > -3f&&!isJump)
            {             
                anim.SetBool("isJump", true);
                isJump = true;
                rigid.AddForce(Vector2.up * 400);              
            }
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Back") {
           
            anim.SetBool("isJump", false); 
            isJump = false; 
        }
    }
}
