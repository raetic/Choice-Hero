using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    int v = 1;
    float t;
    Animator anim;
    float r;
    Enemy myEnemy;
    float stopT;
    bool isJump;
    [SerializeField] GameObject miniSlime;
    [SerializeField] float size;
    public void GoRight()
    {
        v = 1;
        transform.localScale = new Vector3(size, size, 0);
    }
    public void GoLeft()
    {
        v = -1;
        transform.localScale = new Vector3(-size, size, 0);
    }
    void Start()
    {
        r = Random.Range(50, 70) / 12;
        anim = GetComponent<Animator>();
        myEnemy = GetComponent<Enemy>();
        myEnemy.isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (myEnemy.isMove)
        {
            if (!myEnemy.isAir&&!isJump)
            {
                transform.Translate(Vector2.right * v *size * Time.deltaTime);
                t += Time.deltaTime;
            }
            if (t > r)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
                t = 0;
                anim.SetBool("isJump", true);
                isJump = true;
                r = Random.Range(50, 70) / 12;
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
    public void Die()
    {
        myEnemy.isMove = false;
        anim.SetTrigger("isDie");
        Invoke("summon",0.8f);
      
    }
    void summon()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject obj = Instantiate(miniSlime, transform.position + new Vector3((0.5f - i) * 2, 1), transform.rotation);
            if (v == -1) obj.GetComponent<Slime>().GoLeft();
            else obj.GetComponent<Slime>().GoRight();
        }
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Back") { anim.SetBool("isJump", false);
            isJump = false;
        }
    }

}
