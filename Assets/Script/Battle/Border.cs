﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.gameObject.tag == "Attack")
            if(!collision.gameObject.GetComponent<Attack>().notDestoryInBorder)Destroy(collision.gameObject);
        if (collision.gameObject.tag == "EnemyAttack") Destroy(collision.gameObject);
    }
}
