﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SkillManager : MonoBehaviour
{
    public float cooltime;
    Player player;
    [SerializeField]int[] skills=new int[20];
    [SerializeField]GameObject weapon;
    enum skill{
            smash=0,
            wave=1,
            bolt=2,
            root=3,
            wood=4,
            thun=5,
            ninja=6,
            ax=7,
            ice=8,
            swordDance=9,
            rageGround=10,
            holy=11,
    }

    [SerializeField] GameObject smashPrefebs;
    [SerializeField] GameObject smashPrefebs2;
    
    [SerializeField] GameObject wavePrefebs;
    [SerializeField] GameObject boltPrefebs;
    [SerializeField] GameObject rootPrefebs;
    [SerializeField] GameObject woodPrefebs;
    [SerializeField] GameObject thunPrefebs;
    [SerializeField] GameObject ninjaPrefebs;
    [SerializeField] GameObject axPrefebs;
    [SerializeField] GameObject icePrefebs;
    [SerializeField] GameObject swordDance;
    [SerializeField] GameObject groundPrefebs;
    [SerializeField] GameObject holyPrefebs;
    Stat stat;
    [SerializeField] LayerMask enemyMask;

    bool haveAx;
    public int[] Skills { get => skills; set => skills = value; }

    private void Awake()
    {
        player = GetComponent<Player>();
        stat = GetComponent<Stat>();
        skills[0] = 1;
        //InstHoly();
    }
    public void InstSkill(int s)
    {
        if (s == 1) InstWave();
        if (s == 2) InstBolt();
        if (s == 3) InstRoot();
        if (s == 4) InstWood();
        if (s == 5) InstThun();
        if (s == 6) InstNinja();
        if (s == 7) InstAx();
        if (s == 8) InstIce();
        if (s == 10) InstRageGround();
        if (s == 11) InstHoly();
    }
    public void InstSmash()
    {if (skills[0] <2) return;
   
        GameObject newObj = Instantiate(smashPrefebs, weapon.transform.position, transform.rotation);
        newObj.GetComponent<Attack>().DmgX(1+0.2f*stat.PhysicsDmg);
        if (skills[(int)skill.smash] > 2)
        {
            newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
            if (skills[(int)skill.smash] > 3)
            {
                GameObject windObj = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                windObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * -600);
                windObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
                windObj.GetComponent<Attack>().DmgX(1 + 0.2f * stat.PhysicsDmg);
                if (skills[(int)skill.smash] > 4)
                {
                    windObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                    if (skills[(int)skill.smash] > 5)
                    {
                        windObj.GetComponent<Attack>().SetDestroyCount(1);
                        if (skills[(int)skill.smash] > 6)
                        {
                           
                            windObj.GetComponent<Attack>().DmgX(1.5f);
                            newObj.GetComponent<Attack>().DmgX(1.5f);
                            if (skills[(int)skill.smash] > 7)
                            {
                                GameObject windObj2 = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                                windObj2.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * 600);
                                windObj2.transform.localScale *= new Vector2(player.transform.localScale.x * 1, 1);
                                windObj2.transform.localScale *= new Vector2(1.5f, 1.5f);
                                windObj2.GetComponent<Attack>().DmgX(1 + 0.2f * stat.PhysicsDmg);
                                windObj2.GetComponent<Attack>().SetDestroyCount(1);
                                windObj2.GetComponent<Attack>().DmgX(1.5f);
                                if (skills[(int)skill.smash] > 8)
                                {
                                    newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    windObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    windObj2.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    if(skills[(int)skill.smash] > 9)
                                    {
                                        newObj.GetComponent<Attack>().DmgX(1.5f);
                                        windObj.GetComponent<Attack>().DmgX(1.5f);
                                        windObj2.GetComponent<Attack>().DmgX(1.5f);
                                    }
                                }
                            }
                        }
                    }
                }
              
            }
        }
        
       
    }

    public void InstWave()
    {
        float cool = 5;
        float speed = -400;
        int pen = 0;
        float dmg = 1;
        float scale = 1;
        if (skills[(int)skill.wave] > 1) speed *= 1.3f;
        if (skills[(int)skill.wave] > 2) pen+=1;
        if (skills[(int)skill.wave] > 3) scale *= 1.5f;
        if (skills[(int)skill.wave] > 4) pen += 1;
        if (skills[(int)skill.wave] > 5) dmg *= 1.5f;
        if (skills[(int)skill.wave] > 6) cool -= 1.5f;
        if (skills[(int)skill.wave] > 7) speed *= 1.5f ;
        if (skills[(int)skill.wave] > 8) scale *= 2; ;
        if (skills[(int)skill.wave] > 9) pen+=5;
        GameObject waveObj = Instantiate(wavePrefebs, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
        waveObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * speed);
        waveObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
        waveObj.transform.localScale *= scale;
        waveObj.GetComponent<Attack>().DmgX(dmg*(1+0.2f*stat.MagicDmg));
        waveObj.GetComponent<Attack>().SetDestroyCount(pen);


        Invoke("InstWave", cool / (1+0.2f* stat.Cooltime));
    }
    public void InstBolt()
    {
        float scale = 1;
        int pen = 0;
        float dmg = 1;
        int n = 3;
        float speed = 150;
        float cool = 7;
        if (skills[(int)skill.bolt] > 1) speed *= 1.3f;
        if (skills[(int)skill.bolt] > 2) n = 5;
        if (skills[(int)skill.bolt] > 3) scale *= 1.3f;
        if (skills[(int)skill.bolt] > 4) n = 8;
        if (skills[(int)skill.bolt] > 5) dmg *= 1.3f;
        if (skills[(int)skill.bolt] > 6) cool -= 2;
        if (skills[(int)skill.bolt] > 7) n = 10;
        if (skills[(int)skill.bolt] > 8) pen += 2;
        if (skills[(int)skill.bolt] > 9) n = 15;
        for(int i = 0; i <n; i++)
        {
         GameObject boltObj = Instantiate(boltPrefebs, player.transform.position + new Vector3(0, 0.3f),
         Quaternion.Euler(0,0, (180*i / (n-1))+180)); //투사체의 각도가 자연스럽게 회전값을 넣었다.
         Vector2 dirVec = new Vector2(Mathf.Cos((Mathf.PI)*i / (n-1)), Mathf.Sin((Mathf.PI) * i / (n-1)));
            //원을 기준으로 각각의 투사체마다 벡터를 정리
            boltObj.transform.localScale *= scale;
            boltObj.GetComponent<Rigidbody2D>().AddForce(dirVec*speed);
            boltObj.GetComponent<Attack>().DmgX(dmg* (1 + 0.2f * stat.MagicDmg));
            boltObj.GetComponent<Attack>().SetDestroyCount(pen);
        }
        Invoke("InstBolt", cool/ (1 + 0.2f * stat.Cooltime));
    }
    public void InstRoot()
    {
        float cool = 7;
        float dmg = 1;
        float scale = 1;
        int n = 2;
        if (skills[(int)skill.root] > 1) scale *= 1.3f;
        if (skills[(int)skill.root] > 2) n = 3;
        if (skills[(int)skill.root] > 3) n = 4;
        if (skills[(int)skill.root] > 4) scale *= 1.3f;
        if (skills[(int)skill.root] > 5) dmg *= 1.5f;
        if (skills[(int)skill.root] > 6) n = 5;
        if (skills[(int)skill.root] > 7) cool -= 1f;
        if (skills[(int)skill.root] > 8) scale *= 1.3f;
        if (skills[(int)skill.root] > 9) n = 7;    
        Collider2D[] cols = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, -4.3f), new Vector2(12, 1),0 ,enemyMask);
        var nearCol = cols.OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.gameObject.transform.position);
        }).ToList();
        for (int i = 0; i < cols.Length; i++)
        {
            if (i == n) break;
            GameObject Obj = Instantiate(rootPrefebs, nearCol[i].gameObject.transform.position , transform.rotation);
            Obj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
            Obj.transform.localScale *= scale;
            Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
        }
        Invoke("InstRoot", cool / (1 + 0.2f * stat.Cooltime));
    }
    public void InstWood()
    {
        float cool = 5;
        float dmg = 1;
        float woodScale = 1;
        float speed = 300;
        float pscale = 1;
        int n = 4;
        int pen = 0;
        if (skills[(int)skill.wood] > 1) speed *= 1.2f;
        if (skills[(int)skill.wood] > 2) woodScale *= 1.5f;
        if (skills[(int)skill.wood] > 3) pen = 1;
        if (skills[(int)skill.wood] > 4) pscale *= 1.3f;
        if (skills[(int)skill.wood] > 5) n = 8;
        if (skills[(int)skill.wood] > 6) cool--;
        if (skills[(int)skill.wood] > 7) pen = 2;
        if (skills[(int)skill.wood] > 8) {pscale *= 1.3f; woodScale *= 1.3f; }
        if (skills[(int)skill.wood] > 9) n = 12;
        GameObject Obj = Instantiate(woodPrefebs, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
        Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * -speed);
        Obj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
        Obj.transform.localScale *= woodScale;
        Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.PhysicsDmg));
        Obj.GetComponent<Attack>().SetDestroyCount(pen);
        Obj.GetComponent<Wood>().set(pscale, pen, n, (1 + 0.2f * stat.PhysicsDmg));
        Invoke("InstWood", cool / (1 + 0.2f * stat.Cooltime));
    }
    public void InstThun()
    {
        int no = 5;
        float cool = 7;
        float dmg = 1;
        float scale = 1;
        int n = 2;
        if (skills[no] > 1) scale*= 1.2f;
        if (skills[no] > 2) n = 3;
        if (skills[no] > 3) cool--;
        if (skills[no] > 4) n = 4;
        if (skills[no] > 5) cool--;
        if (skills[no] > 6) n = 5;
        if (skills[no] > 7) scale *= 1.5f;
        if (skills[no] > 8) dmg *= 1.5f;
        if (skills[no] > 9) n = 7;
        for (int i = 0; i < n; i++)
        {
            float rand = Random.Range(-60, 60);
            GameObject Obj = Instantiate(thunPrefebs, new Vector3(player.transform.position.x+rand/10, -3.7f), transform.rotation);
            //Obj.GetComponent<Rigidbody2D>().AddForce(Vector2.down*600);
            Obj.transform.localScale *= scale;
            Obj.transform.GetChild(0).GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
        }
        Invoke("InstThun", cool / (1 + 0.2f*stat.Cooltime));
    }
    public void InstNinja()
    {
        int no = 6;
        float cool = 4.5f;
        float dmg = 1;
        float scale = 1;
        int pen = 0;
        float speed = 400;
        if (skills[no] > 1) pen++;
        if (skills[no] > 2) pen++;
        if (skills[no] > 3) scale*=1.3f;
        if (skills[no] > 4) pen++;
        if (skills[no] > 5) dmg *= 1.5f;
        if (skills[no] > 6) pen++;
        if (skills[no] > 7) scale *= 1.3f;
        if (skills[no] > 8) cool--;
        if (skills[no] > 9) pen += 2;

        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position+new Vector3(-3*transform.localScale.x,0), new Vector2(6, 10), 0, enemyMask);
        var nearObj = cols.OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.gameObject.transform.position);
        }).FirstOrDefault();
        Vector2 v = Vector2.zero;
        if (nearObj != null)
          v = nearObj.transform.position - transform.position;
        GameObject Obj = Instantiate(ninjaPrefebs,player.transform.position+new Vector3(0,0.5f), transform.rotation);
        if(nearObj!=null)
            Obj.GetComponent<Rigidbody2D>().AddForce(v.normalized*speed);
        else
        {
            Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) *-1* speed);
        }
            Obj.transform.localScale *= scale;
            Obj.GetComponent<Attack>().SetDestroyCount(pen);
            Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
        
        Invoke("InstNinja", cool / (1 + 0.2f * stat.Cooltime));
    }
    public void InstAx()
    {
        haveAx = false;
        int no = 7;
        float cool = 10;
        float dmg = 1;
        float scale = 1;
        float speed = 300;
        if (skills[no] > 1) dmg *= 1.3f;
        if (skills[no] > 2) scale *= 1.2f;
        if (skills[no] > 3) speed *= 1.2f;
        if (skills[no] > 4) dmg *= 1.3f;
        if (skills[no] > 5) speed *= 1.3f;
        if (skills[no] > 6) scale *= 1.2f;
        if (skills[no] > 7) cool -= 2;
        if (skills[no] > 8) dmg *= 1.3f;
        if (skills[no] > 9) scale *= 1.5f;


        GameObject Obj = Instantiate(axPrefebs, player.transform.position + new Vector3(0, 0.5f), transform.rotation);
        Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x * -1 * speed, 0));     
        Obj.transform.localScale *= scale;
        Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
       StartCoroutine(ReAx(cool / (1 + stat.Cooltime)));
    }
   IEnumerator ReAx(float cool)
    {   int t = 0;
        while (t<100)
        {
            t++;
            if(haveAx)
            {
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(cool / 100);
            }
        }
        Destroy(GameObject.FindGameObjectWithTag("Ax"));
        InstAx();
    }
   
    public void GetAx()
    {
        Invoke("InstAx", 1);
        haveAx = true;
      
    }
    int curIce;
    public void InstIce()
    {
       
        int no = 8;
        float cool = 1.5f;
        float dmg = 1;
        float scale = 1;
        float speed = 250;
        int n = 4;
        int pen = 0;
        curIce++;
        
        if (skills[no] > 1) speed *= 1.3f;
        if (skills[no] > 2) scale *= 1.2f;
        if (skills[no] > 3) pen++;
        if (skills[no] > 4) cool -= 0.5f;
        if (skills[no] > 5) n = 6;
        if (skills[no] > 6) pen++;
        if (skills[no] > 7) dmg *= 1.5f;
        if (skills[no] > 8) scale *= 1.3f;
        if (skills[no] > 9) n = 8;
        if (curIce == n) curIce = 0;
        var quaternion = Quaternion.Euler(0, 0, curIce * (360/n));
        Vector2 newDirection = quaternion * Vector2.right;
        GameObject Obj = Instantiate(icePrefebs, player.transform.position + new Vector3(0, 0.5f), quaternion);
        Obj.transform.GetComponent<Rigidbody2D>().AddForce(speed*newDirection);
        Obj.transform.localScale *= scale;
        Obj.transform.GetChild(0).GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
        Obj.transform.GetChild(0).GetComponent<Attack>().SetDestroyCount(pen);
        Invoke("InstIce",cool / (1 + stat.Cooltime));
    }
    public void SmashDanceLevelUp(int i)
    {
        if (i == 0)
        {
            swordDance.SetActive(true);
        }
        else
        {
            swordDance.GetComponent<SwordDance>().LevelUp(i + 1);
        }
    }
    public void InstRageGround()
    {

        int no = 10;
        float cool = 9f;
        float dmg = 1;
        float scale = 1;
        float power = 0;
        int n = 1;


        if (skills[no] > 1) power = 1000;
        if (skills[no] > 2) scale *= 1.3f;
        if (skills[no] > 3) cool -= 1.5f;
        if (skills[no] > 4) dmg *= 1.5f;
        if (skills[no] > 5) n = 2;
        if (skills[no] > 6) power = 1300;
        if (skills[no] > 7) cool -= 1.5f;
        if (skills[no] > 8) scale *= 1.3f;
        if (skills[no] > 9) power = 1500;

       
            GameObject Obj = Instantiate(groundPrefebs,new Vector2(transform.position.x+transform.localScale.x*-3,-3.5f), transform.rotation);
         Obj.transform.localScale = transform.localScale;
        Obj.transform.localScale *= scale;
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
            Obj.transform.GetComponent<RageGround>().upPower = power;
        if (n == 2) {
            GameObject Obj2 = Instantiate(groundPrefebs, new Vector2(transform.position.x + transform.localScale.x * 3, -3.5f), transform.rotation);
            Obj2.transform.localScale = new Vector2(transform.localScale.x*-1,1);
            Obj2.transform.localScale *= scale;
            Obj2.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
            Obj2.transform.GetComponent<RageGround>().upPower = power;
        }
        Invoke("InstRageGround", cool / (1 + stat.Cooltime));
    }
    public void InstHoly()
    {

        int no = 11;
        float cool = 4f;
        float dmg = 1;
        float scale = 1;
        int n = 1;


        if (skills[no] > 1) dmg *= 1.2f;
        if (skills[no] > 2) dmg *= 1.3f;
        if (skills[no] > 3) cool -= 0.5f;
        if (skills[no] > 4) scale *= 1.3f;
        if (skills[no] > 5) n = 2;
        if (skills[no] > 6) dmg *= 1.3f;
        if (skills[no] > 7) cool -= 0.5f;
        if (skills[no] > 8) n = 3;
        if (skills[no] > 9) scale *= 1.5f;
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(12, 12), 0, enemyMask);
        var nearObj = cols.OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.gameObject.transform.position);
        }).FirstOrDefault();

        if (nearObj != null)
        {
            Vector3 v = nearObj.transform.position+new Vector3(0,0.2f);
            StartCoroutine(HolyCor(n, scale, dmg,v));
        }
      
        Invoke("InstHoly", cool / (1 + stat.Cooltime));
    }
    IEnumerator HolyCor(int n,float scale,float dmg,Vector3 v)
    {
        int t = 0;
        while (t < n)
        {
            t++;
            GameObject Obj = Instantiate(holyPrefebs, v, transform.rotation);
            Obj.transform.localScale *= scale;
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.2f * stat.MagicDmg));
            yield return new WaitForSeconds(1);
        }
    }
}
