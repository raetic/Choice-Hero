using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] Player myPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy") myPlayer.onHit(collision.gameObject.GetComponent<Enemy>().GetDmg());
    }
}
