using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4 : MonoBehaviour
{
    [SerializeField] Vector3[] wantGo;
    int desti;
    Enemy myEnemy;
    [SerializeField] float speed;
    [SerializeField] GameObject[] bress;
    void Start()
    {
        myEnemy = GetComponent<Enemy>();
        SelectMove();
        Think();
    }
    void Think()
    {


        Invoke("Think", 3);
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
            if (transform.position.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 0);
            }
            transform.position = Vector3.MoveTowards(transform.position, wantGo[desti], speed*Time.deltaTime);
            if (transform.position == wantGo[desti]) SelectMove();
        }
        
    }
}
