using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class myol : MonoBehaviour
{
    public float cool=5;
    public int speed;
    float t;
    bool isFly;
    Vector3 target;
    private void Start()
    {
        FindEnemy();
    }
    void FindEnemy()
    {      
        isFly = true;
        t = 0;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        var nearObj = enemys.OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.transform.position);
        }).ToList();
        if (enemys.Length > 0)
        {
            target = nearObj[enemys.Length - 1].transform.position;
           
        }
        else
        {
            Invoke("FindEnemy", 1);
        }
    }
    private void Update()
    {
        if (isFly)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (transform.position == target)
            {
                isFly = false;
            }
        }
        else
        {
            t += Time.deltaTime;
            if (t >= cool)
            {
                FindEnemy();              
            }
        }
    }
}
