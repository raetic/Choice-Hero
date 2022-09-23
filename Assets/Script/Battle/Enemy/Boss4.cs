using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{
    Vector3[] wantGo=new Vector3[22];
    int desti;
    Enemy myEnemy;
    [SerializeField] float speed;
    [SerializeField] GameObject[] bress;
    [SerializeField] GameObject bressPoint;
    Animator anim;
    bool isDash;
    int dashCount;
    Vector3[] dash=new Vector3[2];
    float c=5;
    void Awake()
    {
        anim = GetComponent<Animator>();
        myEnemy = GetComponent<Enemy>();
        SelectMove();
        Invoke("Think", 3);
    }
    public void setTransX(float p)
    {
      
        for (int i = 0; i < 20; i++)
        {
            wantGo[i] = new Vector3(2.5f * ((i / 4) - 2)+p, i % 4 - 2);
        }
        wantGo[20] = new Vector3(-5.5f + p, -3);
        wantGo[21] = new Vector3(5.5f + p, -3);
        c = p;       
    }
    void Think()
    {
        Debug.Log("aa");
        int rand = Random.Range(6,7);
        if (rand <=5)
        {
            myEnemy.isMove = false;
            anim.SetTrigger("isAttack");
            Invoke("attack1",1);
            Invoke("Think", 3);
        }
        else
        {
            dashCount = 0;
            isDash = true;
            myEnemy.isMove = false;
            rand = Random.Range(20, 22);
            if (rand == 20)
            {
                dash[0] = wantGo[20];
                dash[1] = wantGo[21];
            }
            else
            {
                dash[1] = wantGo[20];
                dash[0] = wantGo[21];
            }
        }
       
    }
    void attack1()
    {
        myEnemy.isMove = true;
        GameObject breath = Instantiate(bress[Random.Range(0, 2)], bressPoint.transform.position, transform.rotation);
       if(transform.localScale.x==-1)breath.transform.localScale=new Vector3(-2,2);
    }
    void SelectMove()
    {
        desti = Random.Range(0, 20);
    }
    // Update is called once per frame
    void Update()
    {
        if (myEnemy.isMove)
        {
            if (transform.position.x < c)
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
            else transform.localScale = new Vector3(1, 1, 0);
            transform.position = Vector3.MoveTowards(transform.position, wantGo[desti], speed*Time.deltaTime);
            if (transform.position == wantGo[desti]) SelectMove();
        }
        if (isDash)
        {
            if (transform.position.x < c)
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
            else transform.localScale = new Vector3(1, 1, 0);
            if (dashCount == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, dash[0], speed*0.8f * Time.deltaTime);
                if (transform.position == dash[0])
                {
                    dashCount++;
                }
            }
            if (dashCount == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, dash[1], speed *5 * Time.deltaTime);
                if (transform.position == dash[1])
                {
                    dashCount = 0;
                    isDash = false;
                    myEnemy.isMove = true;
                    Invoke("Think", 3);
                }
            }
        }
       
    }
}
