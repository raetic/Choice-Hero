using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    float scale;
    int pen;
    int n;
    float dmg;
    [SerializeField] GameObject miniObj;
    public void set(float s,int p,int nu,float d)
    {
        scale = s;
        pen = p;
        n = nu;
        dmg = d;
    }
    public void conflict()
    {
       
        for (int i = 0; i < n; i++)
        {
            GameObject Obj = Instantiate(miniObj, transform.position,
            Quaternion.Euler(0, 0, (360 * i / (n)) + 180)); //투사체의 각도가 자연스럽게 회전값을 넣었다.
            Vector2 dirVec = new Vector2(Mathf.Cos((Mathf.PI) *2* i / (n)), Mathf.Sin((Mathf.PI) * 2*i / (n)));
            //원을 기준으로 각각의 투사체마다 벡터를 정리
            Obj.transform.localScale *= scale;
            Obj.GetComponent<Rigidbody2D>().AddForce(dirVec * 400);
            Obj.GetComponent<Attack>().DmgX(dmg);
            Obj.GetComponent<Attack>().SetDestroyCount(pen);
        }

    }
}
