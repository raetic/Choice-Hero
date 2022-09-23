using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    [SerializeField] GameObject exp;
    float scale=1;
    float dmg=1;
    public void set(float s,float d)
    {
        scale = s;
        dmg = d;
    }
    public void MakeExplosion()
    {
        GameObject Obj = Instantiate(exp, transform.position-new Vector3(0,-0.5f), Quaternion.Euler(Vector3.zero));       
        Obj.transform.localScale *= scale;
        Obj.transform.GetChild(0).GetComponent<Attack>().DmgX(dmg);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Back")
        {
            SfxControl.Instance.UseSfxSkill(16);
            MakeExplosion();
        }
    }
}
