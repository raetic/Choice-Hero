using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageGround : MonoBehaviour
{
    public float upPower;

    private void Start()
    {
        Invoke("des", 0.2f);
    }
    void des()
    {
        upPower = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {   if(upPower!=0)
            collision.gameObject.GetComponent<Enemy>().Air(upPower);
        }
    }
}
