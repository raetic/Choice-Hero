using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ax : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "Back")
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Destroy(GetComponent<Turn>());
            GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.tag = "Ax";
        }
    }
}
