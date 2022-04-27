using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] int maxHp;
    [SerializeField] GameObject dmg;
    Rigidbody2D rigid;
    [SerializeField] int Atk;
    [SerializeField] int expCount;
    public bool isMove;
    [SerializeField] GameObject exp;
    void Start()
    {
        
        hp = maxHp;
        rigid = GetComponent<Rigidbody2D>();
    }
    public int GetDmg()
    {
        return Atk;
    }
    void OnHit(int dmg)
    {
        hp -= dmg;
        if (hp <= 0) Die();
    }
    public void Die()
    {
        for(int i = 0; i < expCount; i++)
        {
            GameObject e = Instantiate(exp, transform.position, transform.rotation);
            e.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-50,50),50));

        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Attack")
        {   
            rigid.AddForce(new Vector2(transform.position.x - collision.transform.position.x,0).normalized*150);
            isMove = false;
            int d = collision.gameObject.GetComponent<Attack>().GetDmg();
            GameObject dmg2 = Instantiate(dmg, transform.position+new Vector3(0,0.5f), transform.rotation);
            dmg2.GetComponent<Dmg>().SetText(d,false);
            OnHit(d);
        }
    }
    /* private void OncollisionEnter2D(Collider2D collision)
     {
         if (collision.gameObject.tag == "Attack")
         {
             Debug.Log("피격");
             OnHit(collision.gameObject.GetComponent<Attack>().GetDmg());
         }
     }*/
}
