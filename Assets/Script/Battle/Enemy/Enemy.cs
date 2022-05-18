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
    [SerializeField] GameObject reselct;
    [SerializeField] bool isBoss;
    public bool isAir;
    [SerializeField] bool isSl;
    [SerializeField] bool notPush;
    [SerializeField] bool isPortal;
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
        if (isPortal)
        {//보스소환함수
            Destroy(gameObject);
            return;
        }
        if (isSl)
        {
            GetComponent<Slime>().Die();
            
            return;
        }
        GameObject e = Instantiate(exp, transform.position, transform.rotation);
        e.GetComponent<Exp>().setMount(expMount);
        if (!isBoss&&!isSl)
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
          
            if (rand <= 5&&rand>=3)
            {
                GameObject resel = Instantiate(reselct, transform.position, transform.rotation);
            }
        }
        else
        {
            GameObject potion1 = Instantiate(potion[0], transform.position, transform.rotation);
            GameObject.Find("BattleManager").GetComponent<BattleManager>().bossPhase = false;
            GameObject resel = Instantiate(reselct, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Attack")
        {
            if (!collision.gameObject.GetComponent<Attack>().notPush)
            {
                if (!notPush)
                {
                    rigid.AddForce(new Vector2(transform.position.x - collision.transform.position.x, 0).normalized * 150);
                    isMove = false;
                }
            }
            collision.gameObject.GetComponent<Attack>().Conflict();
            int d = collision.gameObject.GetComponent<Attack>().GetDmg();
            OnHit(d);
            Invoke("SetRigid", 0.2f);
        }
    }
 void SetRigid()
    {
        rigid.velocity = Vector2.zero;
        isMove = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Back"&&isAir) {
            isAir = false;
            isMove = true;
        };
    }
}
