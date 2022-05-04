using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int dmg;
    [SerializeField] float DestroyTime;
    [SerializeField] float AttackTime;
    [SerializeField] int destroyCount;
    [SerializeField] bool isDestroy;
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
    }
    public void Des()
    {
        Destroy(gameObject);
    }
    public void NonA()
    {
        gameObject.tag = "Untagged";
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
        destroyCount--;
        if (destroyCount == 0) Destroy(gameObject);
    }
    public int GetDmg()
    {
        return dmg;
    }
    // Update is called once per frame
 
}
