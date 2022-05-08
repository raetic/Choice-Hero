using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    int size=4;
    float dmg = 4;
    float upPower = 300;
    public void setting(int s,float d,float u)
    {
        upPower = u;
        dmg = d;
        size = s;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Back") {
            Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position-new Vector3(0,-0.5f), new Vector2(size, 1), 0, LayerMask.GetMask("Enemy"));
         for(int i = 0; i < cols.Length; i++)
            {
                cols[i].GetComponent<Enemy>().OnHit(Mathf.FloorToInt(dmg));
                cols[i].GetComponent<Enemy>().Air(upPower);
            }

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().EQ();
            Destroy(transform.parent.gameObject);
                }
    }
}
