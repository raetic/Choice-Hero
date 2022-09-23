using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [SerializeField] Player myPlayer;
    bool power;
    float t;
    private void Update()
    {
        t += Time.deltaTime;
        if (power && t > 0.1f)
        {
            power = false;
            t = 0;
        }
        if (!power && t > 0.01f) {
            power = true;
            t = 0;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!power)
        {
            if (collision.gameObject.tag == "Enemy") myPlayer.onHit(collision.gameObject.GetComponent<Enemy>().GetDmg());
           
        }
        if (collision.gameObject.tag == "EnemyAttack")
        {
            myPlayer.onHit(collision.gameObject.GetComponent<EnemyAttack>().GetDmg());
            if(!collision.gameObject.GetComponent<EnemyAttack>().notD)
            Destroy(collision.gameObject);
            if (collision.gameObject.GetComponent<EnemyAttack>().oneTime)
                collision.gameObject.tag = "Untagged";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Exp")
        {
            
            SfxControl.Instance.UseSfxre();
            myPlayer.ExpUp(collision.gameObject.GetComponent<Exp>().mount);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Ax")
        {

            SfxControl.Instance.UseSfxHp();
            Destroy(collision.gameObject);
            myPlayer.SM.GetAx();

        }
    }
}
