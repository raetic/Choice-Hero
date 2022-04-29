using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    GameObject player;
    int random;
    void Start()
    {
        random= Random.Range(-2, 1);
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Think", 0.5f);
    }

    void Think()
    {
        Invoke("Think", 0.5f);
        random = Random.Range(0, 4);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(0, random), 2*Time.deltaTime);
        if (transform.position.x > player.transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
