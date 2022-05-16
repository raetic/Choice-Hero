using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] GameObject[] waters;
    float scale=1;
    float dmg=1;
    public void set(float d,float s)
    {
        dmg = d;
        scale = s;
    }
    private void Start()
    {
        Invoke("Go",1);
    }
    void Go()
    {
        int rand = Random.Range(0, 2);
        GameObject w = null;
        if (rand==0)
        w= Instantiate(waters[rand], transform.position + new Vector3(0,1.2f*scale), transform.rotation);
        else w = Instantiate(waters[rand], transform.position + new Vector3(0, 1 * scale), transform.rotation);
        w.GetComponent<Attack>().DmgX(dmg);
        w.transform.localScale *= scale;
        Destroy(gameObject);
    }
}
