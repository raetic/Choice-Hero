using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SkillManager : MonoBehaviour
{
    public float cooltime;
    Player player;
    [SerializeField]int[] skills=new int[25];
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
            hammer=12,
            tonado=13,
            claw=14,
            leaf=15,
            meteo=16,
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
    [SerializeField] GameObject hammerPrefebs;
    [SerializeField] GameObject tonadoPrefebs;
    [SerializeField] GameObject leafPrefebs;
    [SerializeField] GameObject meteoPrefebs;
    [SerializeField] GameObject swordPrefebs;
    [SerializeField] GameObject stPrefebs;
    [SerializeField] GameObject myolPrefebs;
    [SerializeField] GameObject chainPrefebs;
    [SerializeField] GameObject[] castPrefebs;
    [SerializeField] GameObject waterPrefebs;
    [SerializeField] GameObject Claw;
    List<GameObject> myolList = new List<GameObject>();
    Stat stat;
    [SerializeField] LayerMask enemyMask;

    bool haveAx;
    public int[] Skills { get => skills; set => skills = value; }

    int smashCount;

    private void Awake()
    {
        player = GetComponent<Player>();
        stat = GetComponent<Stat>();
        skills[0] = 1;    
    }
    public void InstSkill(int s)
    {if (s == 0) player.GetComponent<Player>().startAttack();
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
        if (s == 12) InstHammer();
        if (s == 13) InstTonado();
        if (s == 15) InstLeaf();
        if (s == 16) InstMeteo();
        if (s == 17) InstSwordRain();
        if (s == 18) InstShurikenTonado();
        if (s == 21) InstChain();
        if (s == 22) InstWater();
    }
    public void InstSmash()
    {
        if (skills[14] > 0) InstClaw();
        if (skills[20] > 0) InstCast();
        if (skills[0] <2) return;
        
        GameObject newObj = Instantiate(smashPrefebs, weapon.transform.position, transform.rotation);
        newObj.GetComponent<Attack>().DmgX(1+0.1f*stat.PhysicsDmg);
        if (skills[(int)skill.smash] > 2)
        {
            newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
            if (skills[(int)skill.smash] > 3)
            {
                GameObject windObj = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                windObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * -600);
                windObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
                windObj.GetComponent<Attack>().DmgX(1 + 0.1f * stat.PhysicsDmg);
                if (skills[(int)skill.smash] > 4)
                {
                    windObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                    if (skills[(int)skill.smash] > 5)
                    {
                        windObj.GetComponent<Attack>().SetDestroyCount(1);
                        if (skills[(int)skill.smash] > 6)
                        {
                           
                            windObj.GetComponent<Attack>().DmgX(1.2f);
                            newObj.GetComponent<Attack>().DmgX(1.2f);
                            if (skills[(int)skill.smash] > 7)
                            {
                                GameObject windObj2 = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                                windObj2.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * 600);
                                windObj2.transform.localScale *= new Vector2(player.transform.localScale.x * 1, 1);
                                windObj2.transform.localScale *= new Vector2(1.5f, 1.5f);
                                windObj2.GetComponent<Attack>().DmgX(1 + 0.1f * stat.PhysicsDmg);
                                windObj2.GetComponent<Attack>().SetDestroyCount(1);
                                windObj2.GetComponent<Attack>().DmgX(1.2f);
                                if (skills[(int)skill.smash] > 8)
                                {
                                    newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    windObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    windObj2.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    if(skills[(int)skill.smash] > 9)
                                    {
                                        newObj.GetComponent<Attack>().DmgX(1.2f);
                                        windObj.GetComponent<Attack>().DmgX(1.2f);
                                        windObj2.GetComponent<Attack>().DmgX(1.2f);
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
        float cool = 3;
        float speed = -400;
        int pen = 0;
        float dmg = 1;
        float scale = 1;
        if (skills[(int)skill.wave] > 1) speed *= 1.3f;
        if (skills[(int)skill.wave] > 2) pen+=1;
        if (skills[(int)skill.wave] > 3) scale *= 1.5f;
        if (skills[(int)skill.wave] > 4) pen += 1;
        if (skills[(int)skill.wave] > 5) dmg *= 1.2f;
        if (skills[(int)skill.wave] > 6) cool -= 1.5f;
        if (skills[(int)skill.wave] > 7) speed *= 1.5f ;
        if (skills[(int)skill.wave] > 8) scale *= 2; ;
        if (skills[(int)skill.wave] > 9) pen+=5;
        GameObject waveObj = Instantiate(wavePrefebs, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
        waveObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * speed);
        waveObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
        waveObj.transform.localScale *= scale;
        waveObj.GetComponent<Attack>().DmgX(dmg*(1+0.1f*stat.MagicDmg));
        waveObj.GetComponent<Attack>().SetDestroyCount(pen);


        Invoke("InstWave", cool / (1+0.1f* stat.Cooltime));
    }
    public void InstBolt()
    {
        float scale = 1;
        int pen = 0;
        float dmg = 1;
        int n = 3;
        float speed = 150;
        float cool = 5;
        if (skills[(int)skill.bolt] > 1) speed *= 1.3f;
        if (skills[(int)skill.bolt] > 2) n = 5;
        if (skills[(int)skill.bolt] > 3) scale *= 1.3f;
        if (skills[(int)skill.bolt] > 4) n = 8;
        if (skills[(int)skill.bolt] > 5) dmg *= 1.15f;
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
            boltObj.GetComponent<Attack>().DmgX(dmg* (1 + 0.1f * stat.MagicDmg));
            boltObj.GetComponent<Attack>().SetDestroyCount(pen);
        }
        Invoke("InstBolt", cool/ (1 + 0.1f * stat.Cooltime));
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
        if (skills[(int)skill.root] > 5) dmg *= 1.3f;
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
            GameObject Obj = Instantiate(rootPrefebs, new Vector3(nearCol[i].gameObject.transform.position.x
                ,-3.8f), transform.rotation);
            Obj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
            Obj.transform.localScale *= scale;
            Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
        }
        Invoke("InstRoot", cool / (1 + 0.1f * stat.Cooltime));
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
        Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.PhysicsDmg));
        Obj.GetComponent<Attack>().SetDestroyCount(pen);
        Obj.GetComponent<Wood>().set(pscale, pen, n, (1 + 0.1f * stat.PhysicsDmg));
        Invoke("InstWood", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstThun()
    {
        int no = 5;
        float cool = 9;
        float dmg = 1;
        float scale = 1;
        int n = 2;
        if (skills[no] > 1) scale*= 1.2f;
        if (skills[no] > 2) n = 3;
        if (skills[no] > 3) cool--;
        if (skills[no] > 4) n = 4;
        if (skills[no] > 5) cool--;
        if (skills[no] > 6) n = 5;
        if (skills[no] > 7) scale *= 1.3f;
        if (skills[no] > 8) dmg *= 1.2f;
        if (skills[no] > 9) n = 7;
        for (int i = 0; i < n; i++)
        {
            float rand = Random.Range(-60, 60);
            GameObject Obj = Instantiate(thunPrefebs, new Vector3(player.transform.position.x+rand/10, -3.7f+(scale-1)*0.5f), transform.rotation);
            //Obj.GetComponent<Rigidbody2D>().AddForce(Vector2.down*600);
            Obj.transform.localScale *= scale;
            Obj.transform.GetChild(0).GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
        }
        Invoke("InstThun", cool / (1 + 0.1f*stat.Cooltime));
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
        if (skills[no] > 5) dmg *= 1.3f;
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
            Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.PhysicsDmg));
        
        Invoke("InstNinja", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstAx()
    {
        haveAx = false;
        int no = 7;
        float cool = 10;
        float dmg = 1;
        float scale = 1;
        float speed = 300;
        if (skills[no] > 1) dmg *= 1.5f;
        if (skills[no] > 2) scale *= 1.2f;
        if (skills[no] > 3) speed *= 1.2f;
        if (skills[no] > 4) dmg *= 1.5f;
        if (skills[no] > 5) speed *= 1.3f;
        if (skills[no] > 6) scale *= 1.2f;
        if (skills[no] > 7) cool -= 2;
        if (skills[no] > 8) dmg *= 1.5f;
        if (skills[no] > 9) scale *= 1.5f;


        GameObject Obj = Instantiate(axPrefebs, player.transform.position + new Vector3(0, 0.5f), transform.rotation);
        Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x * -1 * speed, 0));     
        Obj.transform.localScale *= scale;
        Obj.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.PhysicsDmg));
       StartCoroutine(ReAx(cool / (1 + 0.1f*stat.Cooltime)));
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
        Obj.transform.GetChild(0).GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
        Obj.transform.GetChild(0).GetComponent<Attack>().SetDestroyCount(pen);
        Invoke("InstIce",cool / (1 + 0.1f * stat.Cooltime));
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
        float cool = 5.5f;
        float dmg = 1;
        float scale = 1;
        float power = 550;
        int n = 1;


        if (skills[no] > 1) power = 1200;
        if (skills[no] > 2) scale *= 1.5f;
        if (skills[no] > 3) cool -= 1f;
        if (skills[no] > 4) dmg *= 1.5f;
        if (skills[no] > 5) n = 2;
        if (skills[no] > 6) power = 1500;
        if (skills[no] > 7) cool -= 1f;
        if (skills[no] > 8) scale *= 1.3f;
        if (skills[no] > 9) power = 1800;

       
            GameObject Obj = Instantiate(groundPrefebs,new Vector2(transform.position.x+transform.localScale.x*-3,-3.5f), transform.rotation);
         Obj.transform.localScale = transform.localScale;
        Obj.transform.localScale *= scale;
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
            Obj.transform.GetComponent<RageGround>().upPower = power;
        if (n == 2) {
            GameObject Obj2 = Instantiate(groundPrefebs, new Vector2(transform.position.x + transform.localScale.x * 3, -3.5f), transform.rotation);
            Obj2.transform.localScale = new Vector2(transform.localScale.x*-1,1);
            Obj2.transform.localScale *= scale;
            Obj2.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
            Obj2.transform.GetComponent<RageGround>().upPower = power;
        }
        Invoke("InstRageGround", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstHoly()
    {

        int no = 11;
        float cool = 8f;
        float dmg = 1;
        float scale = 1;
        int n = 1;


        if (skills[no] > 1) dmg *= 1.1f;
        if (skills[no] > 2) dmg *= 1.1f;
        if (skills[no] > 3) cool -= 1f;
        if (skills[no] > 4) scale *= 1.3f;
        if (skills[no] > 5) n = 2;
        if (skills[no] > 6) dmg *= 1.1f;
        if (skills[no] > 7) cool -=1f;
        if (skills[no] > 8) n = 3;
        if (skills[no] > 9) scale *= 1.5f;
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(12, 12), 0, enemyMask);
        var nearObj = cols.OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.gameObject.transform.position);
        }).FirstOrDefault();

        if (nearObj != null)
        {
            Vector3 v = nearObj.transform.position+new Vector3(0,0.1f);
            StartCoroutine(HolyCor(n, scale, dmg,v));
        }
      
        Invoke("InstHoly", cool / (1 + 0.1f * stat.Cooltime));
    }
    IEnumerator HolyCor(int n,float scale,float dmg,Vector3 v)
    {
        int t = 0;
        while (t < n)
        {
            t++;
            GameObject Obj = Instantiate(holyPrefebs, v, transform.rotation);
            Obj.transform.localScale *= scale;
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
            yield return new WaitForSeconds(1);
        }
    }
    public void InstHammer()
    {
        if (transform.position.y > -4)
        {
            Invoke("InstHammer", 1);
            return;
        }
        int no = 12;
        float cool = 7;
        float dmg = 4;
        float upPower = 300;
        int size = 4;
        if (skills[no] > 1) size = 5;
        if (skills[no] > 2) upPower += 100;
        if (skills[no] > 3) dmg *= 1.3f;
        if (skills[no] > 4) size = 6;
        if (skills[no] > 5) upPower += 100;
        if (skills[no] > 6) cool -= 2;
        if (skills[no] > 7) size = 7;
        if (skills[no] > 8) upPower += 100;
        if (skills[no] > 9) dmg *= 1.3f;
        GameObject Obj = Instantiate(hammerPrefebs, transform.position+new Vector3(0,0.5f), Quaternion.Euler(0,0,45));
        Obj.GetComponent<Turn>().startRotate = 45;
        if (transform.localScale.x < 0) Obj.GetComponent<Turn>().rotateSpeed *= -1;
        Obj.transform.GetChild(0).GetComponent<Hammer>().setting(size, dmg * (1 + 0.1f * stat.PhysicsDmg), upPower);
        
        Invoke("InstHammer", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstTonado()
    {
       
        int no = 13;
        float cool = 17;
        float dmg = 1;
        float speed = 1;
        float time = 5;
        float scale = 1;
        if (skills[no] > 1) time+=1;
        if (skills[no] > 2) dmg*=1.2f;
        if (skills[no] > 3) speed*=1.5f;
        if (skills[no] > 4) scale*=1.3f;
        if (skills[no] > 5) dmg*=1.2f;
        if (skills[no] > 6) cool -= 3;
        if (skills[no] > 7) speed*=1.5f;
        if (skills[no] > 8) scale*=1.3f;
        if (skills[no] > 9) time+=2;
        GameObject Obj = Instantiate(tonadoPrefebs, new Vector3(transform.position.x, -3f+(scale-1)*1.3f), transform.rotation);
        Obj.transform.GetComponent<Tonado>().destroyTime = time;
        Obj.GetComponent<Tonado>().speed = speed;
        Obj.transform.localScale *= scale;
        Obj.transform.GetChild(0).GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));

        Invoke("InstTonado", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstClaw()
    {

        int no = 14;
        float dmg = 3;
        int n = 1;
        float size = 3;
        if (skills[no] > 1) dmg *= 1.2f;
        if (skills[no] > 2) size = 4;
        if (skills[no] > 3) n++;
        if (skills[no] > 4) dmg *= 1.2f;
        if (skills[no] > 5) size = 5;
        if (skills[no] > 6) n++;
        if (skills[no] > 7) dmg *= 1.2f;
        if (skills[no] > 8) size = 7;
        if (skills[no] > 9) n++;
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(size, size), 0, enemyMask);
        var nearObj = cols.OrderBy(obj =>
        {
            return Vector3.Distance(transform.position, obj.gameObject.transform.position);
        }).ToList();
        for(int i = 0; i < nearObj.Count; i++)
        {
            if (i == n) break;
            nearObj[i].GetComponent<Enemy>().OnHit(Mathf.FloorToInt(dmg*(1+stat.PhysicsDmg*0.1f)));
            GameObject Obj = Instantiate(Claw, nearObj[i].transform.position, transform.rotation);
        }

    }
    public void InstLeaf()
    {
        int no = 15;
        float dmg = 1;
        int n = 3;
        float scale = 1;
        float cool = 1;
        float speed = 200;
        if (skills[no] > 1) speed += 50;
        if (skills[no] > 2) n = 5;
        if (skills[no] > 3) scale *= 1.2f;
        if (skills[no] > 4) speed+=50;
        if (skills[no] > 5) n = 7;
        if (skills[no] > 6) scale *= 1.2f;
        if (skills[no] > 7) dmg *= 1.3f;
        if (skills[no] > 8) cool = 0.7f;
        if (skills[no] > 9) n = 9;
        for(int i = 0; i < n; i++)
        {
            float x = Random.Range(-30, 30);
            float xspeed = Random.Range(-5, 5)*100;
            GameObject Obj = Instantiate(leafPrefebs, new Vector3(transform.position.x+x/10, 3), transform.rotation);
            Obj.transform.localScale *= scale;
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
            Obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(xspeed, -speed));
        }
     
        Invoke("InstLeaf", cool / (1 + 0.1f * stat.Cooltime));
    }

    public void InstMeteo()
    {
        int no = 16;
        float dmg = 1;
        int n = 1;
        float scale = 1;
        float cool = 8;
        float speed = 400;
        if (skills[no] > 1) scale *= 1.2f;
        if (skills[no] > 2) n = 2;
        if (skills[no] > 3) dmg *= 1.15f;
        if (skills[no] > 4) cool -= 1f;
        if (skills[no] > 5) n = 3;
        if (skills[no] > 6) scale *= 1.2f;
        if (skills[no] > 7) dmg *= 1.15f;
        if (skills[no] > 8) cool -= 1f;
        if (skills[no] > 9) n = 4;
        for (int i = 0; i < n; i++)
        {

            float xspeed = Random.Range(-5, 6) * 30;
            Vector2 v = new Vector2(xspeed, -speed);
            float angle = Vector2.Angle(v, Vector2.down);
            GameObject Obj = Instantiate(meteoPrefebs, new Vector3(transform.position.x, 3), transform.rotation);
            if (xspeed < 0) {
                Obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 240));
            }
            else
            {
                Obj.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 300));
            }
            Obj.transform.localScale *= scale;
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.MagicDmg));
            Obj.GetComponent<Rigidbody2D>().AddForce(v);
            Obj.GetComponent<Meteo>().set(scale, dmg * (1 + 0.1f * stat.MagicDmg));
        }

        Invoke("InstMeteo", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstSwordRain()
    {
        float cool = 5;
        StartCoroutine("SwordRain");
        Invoke("InstSwordRain", cool / (1 + 0.1f * stat.Cooltime));
    }

    IEnumerator SwordRain()
    {
        int no = 17;
        float dmg = 1;
        int n = 10;        
        float speed = 450;
        bool over = false;
        if (skills[no] > 1) speed *= 1.5f;
        if (skills[no] > 2) n = 15;
        if (skills[no] > 3) dmg *= 1.2f;
        if (skills[no] > 4) dmg *= 1.2f;
        if (skills[no] > 5) n = 20;
        if (skills[no] > 6) over = true;
        if (skills[no] > 7) dmg *= 1.2f;
        if (skills[no] > 8) dmg *= 1.2f;
        if (skills[no] > 9) n = 30;
        for (int i = 0; i < n; i++)
        {         
            GameObject Obj = Instantiate(swordPrefebs, transform.position, Quaternion.Euler(new Vector3(0, 0, 45)));
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.PhysicsDmg));
            Obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 600);
            if (over) Obj.GetComponent<SwordRain>().over = true;
            float t = 0.5f / n;
           
            yield return new WaitForSeconds(t);
        }
      
    }
    public void InstShurikenTonado()
    {
        float cool = 6;
        if (skills[18] > 5) cool -= 1;
        StartCoroutine("ShurikenTonado");
        Invoke("InstShurikenTonado", cool / (1 + 0.1f * stat.Cooltime));
    }

    IEnumerator ShurikenTonado()
    {
        int no = 18;
        float dmg = 1;
        int n = 20;
        float scale = 1;
        int pen = 0;
        if (skills[no] > 1) dmg *= 1.2f;
        if (skills[no] > 2) dmg *= 1.2f;
        if (skills[no] > 3) n = 30;
        if (skills[no] > 4) scale *= 1.5f;
        if (skills[no] > 6) dmg *= 1.2f;
        if (skills[no] > 7) dmg *= 1.2f;
        if (skills[no] > 8) pen++;
        if (skills[no] > 9) n = 40;
        for (int i = 0; i <= n; i++)
        {
            GameObject Obj = Instantiate(stPrefebs, transform.position, Quaternion.Euler(new Vector3(0, 0, 45))); 
            Vector2 dirVec = new Vector2(Mathf.Cos((Mathf.PI) * 2 * i / (n)), Mathf.Sin((Mathf.PI) * 2 * i / (n)));
            //원을 기준으로 각각의 투사체마다 벡터를 정리
            Obj.transform.localScale *= scale;
            Obj.GetComponent<Attack>().SetDestroyCount(pen);
            Obj.transform.GetComponent<Attack>().DmgX(dmg * (1 + 0.1f * stat.PhysicsDmg));
            Obj.GetComponent<Rigidbody2D>().AddForce(dirVec * 550);            
            float t = 2 / n;
            yield return new WaitForSeconds(t);
        }

    }
    public void MyolLevelUp()
    {
        int no = 19;
        if (skills[no] == 1) {
            GameObject myolObj = Instantiate(myolPrefebs, transform.position, transform.rotation);
            myolObj.GetComponent<Attack>().DmgX(1 + 0.1f * stat.PhysicsDmg);
            myolList.Add(myolObj);
        }
        if (skills[no] == 2) {
            myolList[0].transform.localScale *= 1.3f;
        }
        if (skills[no] == 3) {
            myolList[0].GetComponent<myol>().cool -= 0.5f;
        }
        if (skills[no] == 4) {
            myolList[0].GetComponent<myol>().speed = 7;
        }
        if (skills[no] == 5)
        {
            myolList[0].GetComponent<Attack>().DmgX(1.3f);
        }
        if (skills[no] == 6) {
            GameObject myolObj = Instantiate(myolList[0], transform.position, transform.rotation);
            myolList.Add(myolObj);
        }
        if (skills[no] == 7) { 
            for(int i = 0; i < 2; i++)
            {
                myolList[i].GetComponent<myol>().cool -= 0.5f;
            }
        }
        if (skills[no] == 8) {
            for (int i = 0; i < 2; i++)
                myolList[i].GetComponent<myol>().speed = 10;
        }
        if (skills[no] == 9) {
            for (int i = 0; i < 2; i++)
                myolList[i].transform.localScale *= 1.3f;

        }
        if (skills[no] == 10)
        {
            for (int i = 0; i < 2; i++)
                myolList[i].GetComponent<Attack>().DmgX(1.3f);
        }
    }
    public void InstCast()
    {
        smashCount++;
        int no = 20;
        float dmg =5;
        int n = 5;
        float scale = 1;
        if (skills[no] > 4) n = 4;
        if (skills[no] > 8) n = 3;
        if (smashCount < n) return;
        if (skills[no] > 1) dmg *= 1.2f;
        if (skills[no] > 2) dmg *= 1.2f;
        if (skills[no] > 3) scale *= 1.3f;
        if (skills[no] > 5) dmg *= 1.2f;
        if (skills[no] > 6) dmg *= 1.2f;
        if (skills[no] > 7) scale *= 1.3f;
        smashCount = 0;
        Instantiate(castPrefebs[0], transform.position+new Vector3(0,0.5f,0), transform.rotation).transform.localScale*=scale;
        Collider2D[] cols = Physics2D.OverlapBoxAll(transform.position, new Vector2(6,6)*scale, 0, enemyMask);
        if (skills[no] <= 9)
        {
           for(int i = 0; i < cols.Length; i++)
            {
                Instantiate(castPrefebs[1], cols[i].transform.position, transform.rotation);
                cols[i].GetComponent<Enemy>().OnHit(Mathf.FloorToInt((1 + 0.1f * stat.PhysicsDmg) * dmg));
            }

        }
        else
        {
            for (int i = 0; i < cols.Length; i++)
            {
                Instantiate(castPrefebs[1], cols[i].transform.position+new Vector3(0.3f,-0.3f), transform.rotation);
                Instantiate(castPrefebs[1], cols[i].transform.position + new Vector3(-0.3f, 0.3f), transform.rotation);
                cols[i].GetComponent<Enemy>().OnHit(Mathf.FloorToInt((1 + 0.1f * stat.PhysicsDmg) * dmg));
            }
        }
    }
    public void InstChain()
    {
        float dmg = 3f;
        int no = 21;
        float cool = 3;
        if (skills[no] > 1) dmg *= 1.2f;
        if (skills[no] > 2) dmg *= 1.2f;
        if (skills[no] > 3) cool -= 0.5f;
        if (skills[no] > 4) dmg *= 1.2f;
        if (skills[no] > 5) dmg *= 1.2f;
        if (skills[no] > 6) cool -= 0.5f;
        if (skills[no] > 7) dmg *= 1.2f;
        if (skills[no] > 8) dmg *= 1.2f;
        if (skills[no] > 9) cool -= 0.5f;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 priV = transform.position + new Vector3(0, 0.5f);
        var enemyslist = enemys.OrderBy(obj =>
         {
             return Vector3.Distance(transform.position, obj.transform.position);
         }).ToList();
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector3 t = enemyslist[i].transform.position - priV;
            float gd = Mathf.Atan2(t.y, t.x) * Mathf.Rad2Deg;
            GameObject sq = Instantiate(chainPrefebs, (priV + enemyslist[i].transform.position) * 0.5f, Quaternion.Euler(0, 0, gd));
            int count = Mathf.FloorToInt(Vector3.Distance(enemyslist[i].transform.position, priV)) * 2;
            sq.GetComponent<SpriteRenderer>().size = new Vector2(count, 1);
            enemyslist[i].GetComponent<Enemy>().OnHit(Mathf.FloorToInt((1 + 0.1f * stat.MagicDmg) * dmg));
            priV = enemyslist[i].transform.position;
        }
        Invoke("InstChain", cool / (1 + 0.1f * stat.Cooltime));
    }
    public void InstWater()
    {
        float dmg = 1f;
        int no = 22;
        float cool = 14;
        float scale=1;
        int n=10;
        float t=0.5f;
        if (skills[no] > 1) scale *= 1.2f;
        if (skills[no] > 2) dmg *= 1.1f;
        if (skills[no] > 3) cool -= 1;
        if (skills[no] > 4)
        {
            t -= 0.1f;
            n += 3;
        }
     
        if (skills[no] > 5) dmg *= 1.1f;
        if (skills[no] > 6) scale *= 1.2f;
        if (skills[no] > 7) dmg *= 1.1f;
        if (skills[no] > 8) cool -= 1;
        if (skills[no] > 9) { n += 3;
            t -= 0.1f;
        }
        StartCoroutine(WaterCor(dmg, scale, n, t));
        Invoke("InstWater", cool / (1 + 0.1f * stat.Cooltime));
    }
    IEnumerator WaterCor(float dmg,float scale,int n,float t)
    {
        int counter = 0;
        while (counter < n)
        {
            counter++;
            GameObject obj = Instantiate(waterPrefebs, new Vector2(transform.position.x + Random.Range(-600, 601) / 100, -4.3f), transform.rotation);
            obj.GetComponent<Water>().set(dmg * (1 + 0.1f * stat.MagicDmg), scale);
            yield return new WaitForSeconds(t);
        }
    }
}
