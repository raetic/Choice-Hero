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
    [SerializeField] int expMount;
    public bool isMove;
    [SerializeField] GameObject exp;
    [SerializeField] GameObject[] potion;
    [SerializeField] bool isBoss;
    bool isAir;
    public void Air(float p)
    {
        rigid.AddForce(Vector2.up * p);
        isAir = true;
        isMove = false;
    }
    void Start()
    {
        
        hp = maxHp;
        rigid = GetComponent<Rigidbody2D>();
    }
    public int GetDmg()
    {
        return Atk;
    }
    public void OnHit(int dmgf)
    {
        GameObject dmg2 = Instantiate(dmg, transform.position + new Vector3(0, 0.5f), transform.rotation);
        dmg2.GetComponent<Dmg>().SetText(dmgf, false);
        hp -= dmgf;
        if (hp <= 0) Die();
    }
    public void Die()
    {
      
        GameObject e = Instantiate(exp, transform.position, transform.rotation);
        e.GetComponent<Exp>().setMount(expMount);
        if (!isBoss)
        {
            int rand = Random.Range(0, 100);
            if (rand <= 2)
            {
                if (rand == 0)
                {
                    GameObject potion1 = Instantiate(potion[0], transform.position, transform.rotation);
                }
                else
                {
                    GameObject potion1 = Instantiate(potion[1], transform.position, transform.rotation);
                }
            }
        }
        else
        {
            GameObject potion1 = Instantiate(potion[0], transform.position, transform.rotation);
            GameObject.Find("BattleManager").GetComponent<BattleManager>().bossPhase = false;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Attack")
        {
            if (!collision.gameObject.GetComponent<Attack>().notPush)
            {
                rigid.AddForce(new Vector2(transform.position.x - collision.transform.position.x, 0).normalized * 150);
                isMove = false;
            }
            collision.gameObject.GetComponent<Attack>().Conflict();
            int d = collision.gameObject.GetComponent<Attack>().GetDmg();
            OnHit(d);
            Invoke("SetRigid", 0.1f);
        }
    }
 void SetRigid()
    {
        rigid.velocity = Vector2.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Back"&&isAir) {
            isAir = false;
            isMove = true;
        };
    }
}
