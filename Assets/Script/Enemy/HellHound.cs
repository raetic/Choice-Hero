using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour
{
    int v=1;
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
        r = Random.Range(50, 70)/10;
        anim = GetComponent<Animator>();
        myEnemy = GetComponent<Enemy>();
        myEnemy.isMove = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (myEnemy.isMove)
        {
            transform.Translate(Vector2.left * v * 2 * Time.deltaTime);
            t += Time.deltaTime;
            if (t > r)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
                t = 0;
                anim.SetBool("isJump", true);
                r = Random.Range(50, 70) / 10;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Back") anim.SetBool("isJump", false);
    }
    
}
