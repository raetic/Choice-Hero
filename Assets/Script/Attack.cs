using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Attack : MonoBehaviour
{
    [SerializeField] int dmg;
    [SerializeField] float DestroyTime;
    [SerializeField] float AttackTime;
    [SerializeField] int destroyCount;
    [SerializeField] bool isDestroy;
    [SerializeField] int n;
    [SerializeField] bool isWood;
    [SerializeField] float StartTime;
    [SerializeField] bool isNin;
    public bool notPush;
    [SerializeField] bool isMeteo;
    public bool notDestoryInBorder;
    private void Start()
    {
        if (DestroyTime > 0)
        {
            Invoke("Des", DestroyTime);
        }
        if (AttackTime > 0)
        {
            Invoke("NonA", AttackTime);
        }
        if (StartTime > 0)
        {
            gameObject.SetActive(false);
            Invoke("BeA", StartTime);
        }
    }
    public void SetDestroyTime(float t)
    {
        DestroyTime = t;
    }
    public void setN(int i)
    {
        n=i;
    }
    public void Des()
    {      
        Destroy(gameObject);
    }
    public void NonA()
    {
        if(StartTime==0)
        gameObject.tag = "Untagged";
        else
        {
          gameObject.SetActive(false);
        }
    }
    public void BeA()
    {
       gameObject.SetActive(true);
    }
    public void SetDestroyCount(int i)
    {
        destroyCount+=i;
    }
    public void DmgX(float a)
    {
        dmg=Mathf.FloorToInt(dmg*a);
    }
    public void Conflict()
    {
        if (!isDestroy) return;
        if (isWood)
        {
            GetComponent<Wood>().conflict();
            Destroy(gameObject);
            return;
        }
        if (isNin)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(10, 10), 0, LayerMask.GetMask("Enemy"));
            var nearObj = cols.OrderBy(obj =>
            {
                return Vector3.Distance(transform.position, obj.gameObject.transform.position);
            }).ToList();
            Vector2 v = Vector2.zero;
            if (cols.Length>1)
                v = nearObj[1].transform.position - transform.position;       
            if (cols.Length > 1)
               GetComponent<Rigidbody2D>().AddForce(v.normalized * 400);
            else
            {
                Destroy(gameObject);
            }
        }
        if (isMeteo)
        {
            GetComponent<Meteo>().MakeExplosion();
            return;
        }
        destroyCount--;
        if (destroyCount == 0) {
            if (StartTime > 0)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            Destroy(gameObject); }
    }
    public int GetDmg()
    {
        return dmg;
    }



}
