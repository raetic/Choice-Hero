using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleManager : MonoBehaviour
{
    int curCenter;
    float gameTime;
    [SerializeField] GameObject hellHound;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject nightMare;
    [SerializeField] GameObject nightMare2;
    [SerializeField] GameObject nightMare3;
    [SerializeField] GameObject golem;
    [SerializeField] GameObject warm;
    [SerializeField] GameObject flyeye;
    [SerializeField] GameObject darkelf;
    [SerializeField] GameObject elf2;
    [SerializeField] GameObject slime;
    [SerializeField] GameObject skull;
    [SerializeField] GameObject skull2;
    [SerializeField] GameObject fireskull;
    [SerializeField] GameObject[] boss;
    bool bossFhase;
    [SerializeField] TextMeshProUGUI timeT;
    [SerializeField] GameObject[] SpawnPoint;
    [SerializeField] GameObject[] bossSpawnPoint;
    [SerializeField] LevelUp levelUp;
    [SerializeField] GameObject[] FlySpawnPoint;
    public int LvUpCount;
    public bool bossPhase;
    [SerializeField] GameObject exploPrefebs;
    [SerializeField] GameObject[] bossBorder;
    float[] bossend = new float[5];

    public GameObject hpBar;
    public Image hpImage;
    public  Image greenImage;
    public TextMeshProUGUI levelT;
    void Start()
    {
      StartCoroutine("Phase1");
        
    }
    public void LvUp()
    {
        LvUpCount++;
        levelUp.PopupOn();
    }
    IEnumerator Phase1()
    {
        while (gameTime < 30)
        {
            MakeHellHound();
            yield return new WaitForSeconds(2);
        }
      
        while (gameTime < 60)
        {
            MakeHellHound();
            yield return new WaitForSeconds(1.3f);
        }
        StartCoroutine("Phase2");
    }
    IEnumerator Phase2()
    {
        int p = 0;
        while (gameTime < 120)
        {
            p++;
            if (p % 3 == 0)
            {
                MakeBat();
            }
            else
            {
                MakeHellHound();
            }
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Phase3");
    }
    IEnumerator Phase3()
    {
        int p = 0;
        while (gameTime < 180)
        {
            p++;
            if (p % 12 == 0)
            {
                MakeWarm();
            }
            else
            {
                MakeHellHound();
            }
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Phase4");
    }
   
    IEnumerator Phase4()
    {
        int p = 0;
        while (gameTime < 240)
        {
            p++;
            if (p % 2 == 0)
            {
                MakeNightMare();
            }
            else
            {
                MakeHellHound();
            }
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Phase5");
    }
    IEnumerator Phase5()
    {
        int p = 0;
        while (gameTime < 300)
        {
            p++;
            if (p % 10 == 0)
            {
                MakeWarm();
            }
            else if (p % 2 == 0)
            {
                MakeBat();
            }
            else
            {
                MakeNightMare();
            }
            yield return new WaitForSeconds(0.8f);
        }
        StartCoroutine("Boss1");
    }
    IEnumerator Phase6()
    {
        int p = 0;
        while (gameTime < bossend[0]+60)
        {
            p++;
            if (p % 7 == 0)
            {
                MakeWarm();

            }
            else if (p % 2 == 0)
            {
                MakeBat();
            }
            else
            {
                MakeNightMare();
            }
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Phase7");
    }
    IEnumerator Phase7()
    {
        int p = 0;
        while (gameTime < bossend[0] + 120)
        {
            p++;
            if (p % 15 == 0)
            {
                MakeElf();
            }
            else
            {
                MakeHardNightmare();
            }
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Phase8");
    }
    IEnumerator Phase8()
    {
        int p = 0;
        while (gameTime < bossend[0] + 180)
        {
            p++;
            if (p % 25 == 0)
            {
                MakeElf();

            }
            else if (p % 5 == 0)
            {
                MakeEyes();
            }
            else
            {
                MakeHardNightmare();
            }
            yield return new WaitForSeconds(0.8f);
        }
        StartCoroutine("Phase9");
    }
    IEnumerator Phase9()
    {
        int p = 0;
        while (gameTime < bossend[0] + 240)
        {
            p++;
            if (p % 10 == 0)
            {
                MakeElf();
            }
            else if (p % 6 == 0)
            {
                MakeWarm();
            }
            else
            {
                MakeEyes();
            }
            yield return new WaitForSeconds(0.6f);
        }
        StartCoroutine("Boss2");
    }
    IEnumerator Phase10()
    {
        int p = 0;
        while (gameTime < bossend[0] + 60)
        {
            p++;
            if (p % 4 == 0)
            {
                MakeSlime();
            }
            else
            {
                MakeHardNightmare();
            }
            yield return new WaitForSeconds(0.4f);
        }
        StartCoroutine("Phase11");
    }
    IEnumerator Phase11()
    {
        int p = 0;
        while (gameTime < bossend[0] + 120)
        {
            p++;
            if (p % 5 == 0)
            {
                MakeEyes();
            }
            else
            {
                MakeSlime();
            }
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine("Phase12");
    }
    IEnumerator Phase12()
    {
        int p = 0;
        while (gameTime < bossend[0] + 180)
        {
            p++;
            if (p % 5 == 0)
            {
                MakeWarm();
            }
            else
            {
                MakeSkull();
            }
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine("Phase13");
    }
    IEnumerator Phase13()
    {
        int p = 0;
        while (gameTime < bossend[0] + 240)
        {
            p++;
            if (p % 9 == 0)
            {
                MakeElf();
            }
            else
            {
                MakeSkull();
            }
            yield return new WaitForSeconds(0.4f);
        }
        StartCoroutine("Boss3");
    }
    public void BossSummon()
    {
        GameObject[] Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemys.Length>0)
        for (int i = Enemys.Length - 1; i >= 0; i--)
        {
            GameObject obj = Instantiate(exploPrefebs, Enemys[i].transform.position, transform.rotation);
            Destroy(Enemys[i]);
        }
        StartCoroutine("BorderUp");
    }
    IEnumerator BorderUp()
    {
        int t = 0;
        while (t < 15)
        {
            t++;
            for(int i = 0; i < 2; i++)
            {
                bossBorder[i].transform.localScale += new Vector3(0, 0.1f);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator BorderOff()
    {
        int t = 0;
        while (t < 15)
        {
            t++;
            for (int i = 0; i < 2; i++)
            {
                bossBorder[i].transform.localScale -= new Vector3(0, 0.1f);
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator Boss1()
    {
        BossSummon();
        bossPhase = true;
        int rand = Random.Range(0, 2);
        GameObject b = Instantiate(boss[0], FlySpawnPoint[rand+2].transform.position, transform.rotation);
        while (bossPhase)
        {
            yield return new WaitForSeconds(1);
        }
        bossend[0] = gameTime;
        StartCoroutine("BorderOff");
        StartCoroutine("Phase6");
    }
    IEnumerator Boss2()
    {
        BossSummon();
        bossPhase = true;
        int rand = Random.Range(0, 2);
        GameObject b = Instantiate(boss[1], bossSpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 1) b.GetComponent<Boss2>().GoLeft();
        else b.GetComponent<Boss2>().GoRight();
        while (bossPhase)
        {
            yield return new WaitForSeconds(1);
        }
        bossend[0] = gameTime;
        StartCoroutine("BorderOff");
        StartCoroutine("Phase10");
    }
    IEnumerator Boss3()
    {
        BossSummon();
        bossPhase = true;
        int rand = Random.Range(0, 2);
        GameObject b = Instantiate(boss[2], bossSpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 1) b.GetComponent<Boss3>().GoLeft();
        else b.GetComponent<Boss3>().GoRight();
        while (bossPhase)
        {
            yield return new WaitForSeconds(1);
        }
        bossend[0] = gameTime;
        StartCoroutine("BorderOff");
        StartCoroutine("Phase14");
    }
    IEnumerator Phase14()
    {
        int p = 0;
        while (gameTime < bossend[0] + 60)
        {
            p++;
            if (p % 15 == 0)
            {
                MakeFireskull();
            }
            else if (p % 8 == 0)
            {
                MakeSkull();
            }
            else
            {
                MakeHardNightmare();
            }
            yield return new WaitForSeconds(0.3f);
        }
        StartCoroutine("Phase15");
    }
    IEnumerator Phase15()
    {
        int p = 0;
        while (gameTime < bossend[0] + 120)
        {
            p++;
            if (p % 10 == 0)
            {
                MakeElf2();
            }
            else if (p % 7 == 0)
            {
                MakeGolem();
            }
            else
            {
                MakeHellNightMare();
            }
            yield return new WaitForSeconds(0.3f);
        }
        StartCoroutine("Phase16");
    }
    IEnumerator Phase16()
    {
        int p = 0;
        while (gameTime < bossend[0] + 180)
        {
            p++;
            if (p % 5 == 0)
            {
                MakeGolem();
                
            }
            else if (p % 7==0)
            {
                MakeFireskull();
            }
            else
            {
                MakeSkull2();
            }
            yield return new WaitForSeconds(0.2f);
        }
        StartCoroutine("Phase17");
    }
    IEnumerator Phase17()
    {
        int p = 0;
        while (gameTime < bossend[0] + 240)
        {
            p++;
            if (p % 3 == 0)
            {
                MakeElf2();
            }
            else if (p % 2 == 0)
            {
                MakeGolem();
            }
            else
            {
                MakeSkull2();
            }
            yield return new WaitForSeconds(0.3f);
        }
        StartCoroutine("Boss3");
    }
    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;
        int m = (int)gameTime / 60;
        int s = (int)gameTime % 60;
        if (m == 0) timeT.text = "Time 0:" + string.Format("{0:D2}",s);
        else timeT.text = "Time "+m+":" + string.Format("{0:D2}", s);
    }
    public void SetCurCenter(int c)
    {
        curCenter = c;
    }
    public void MakeHardNightmare()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(nightMare2, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) n.GetComponent<Nightmare>().GoRight();
    }
    public void MakeBat()
    {
        int rand = Random.Range(0, 5);
        GameObject b = Instantiate(bat, FlySpawnPoint[rand].transform.position, transform.rotation);
    }
    public void MakeEyes()
    {
        int rand = Random.Range(0, 5);
        GameObject b = Instantiate(flyeye, FlySpawnPoint[rand].transform.position, transform.rotation);
    }
    public void MakeFireskull()
    {
        int rand = Random.Range(0, 5);
        GameObject b = Instantiate(fireskull, FlySpawnPoint[rand].transform.position, transform.rotation);
    }
    public void MakeWarm()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(warm, SpawnPoint[rand].transform.position, transform.rotation);
    }
    public void MakeNightMare()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(nightMare, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) n.GetComponent<Nightmare>().GoRight();
    }
    public void MakeHellHound()
    {
        int rand = Random.Range(0, 2);
        GameObject Hound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) Hound.GetComponent<HellHound>().GoRight();
    }
    public void MakeSkull()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(skull, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) n.GetComponent<Nightmare>().GoRight();
    }
    public void MakeSkull2()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(skull2, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) n.GetComponent<Nightmare>().GoRight();
    }
    public void MakeElf()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(darkelf, SpawnPoint[rand].transform.position, transform.rotation);
    }
    public void MakeElf2()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(elf2, SpawnPoint[rand].transform.position, transform.rotation);
    }
    public void MakeSlime()
    {
        int rand = Random.Range(0, 2);
        GameObject obj = Instantiate(slime, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) obj.GetComponent<Slime>().GoRight();
        else obj.GetComponent<Slime>().GoLeft();
    }
    public void MakeHellNightMare()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(nightMare3, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) n.GetComponent<Nightmare>().GoRight();
    }
    public void MakeGolem()
    {
        int rand = Random.Range(0, 2);
        GameObject n = Instantiate(golem, SpawnPoint[rand].transform.position, transform.rotation);
        if (rand == 0) n.GetComponent<Golem>().GoRight();
    }
}
