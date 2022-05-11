using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleManager : MonoBehaviour
{
    int curCenter;
    float gameTime;
    [SerializeField] GameObject hellHound;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject nightMare;
    [SerializeField] GameObject nightMare2;
    [SerializeField] GameObject warm;
    [SerializeField] GameObject flyeye;
    [SerializeField] GameObject darkelf;
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
            int rand = Random.Range(0, 2);
            GameObject Hound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
            if (rand == 0) Hound.GetComponent<HellHound>().GoRight();
            yield return new WaitForSeconds(2);
        }
      
        while (gameTime < 60)
        {
            int rand = Random.Range(0, 2);
            GameObject Hound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
            if (rand == 0) Hound.GetComponent<HellHound>().GoRight();
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
                int rand = Random.Range(0, 5);
                GameObject b = Instantiate(bat, FlySpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject Hound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) Hound.GetComponent<HellHound>().GoRight();
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
                int rand = Random.Range(0, 2);
                GameObject w = Instantiate(warm, SpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject Hound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) Hound.GetComponent<HellHound>().GoRight();
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
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(nightMare, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) n.GetComponent<Nightmare>().GoRight();
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject Hound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) Hound.GetComponent<HellHound>().GoRight();
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
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(warm, SpawnPoint[rand].transform.position, transform.rotation);
  
            }
            else if (p % 2 == 0)
            {
                int rand = Random.Range(0, 5);
                GameObject b = Instantiate(bat, FlySpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(nightMare, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) n.GetComponent<Nightmare>().GoRight();
            }
            yield return new WaitForSeconds(0.7f);
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
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(warm, SpawnPoint[rand].transform.position, transform.rotation);

            }
            else if (p % 2 == 0)
            {
                int rand = Random.Range(0, 5);
                GameObject b = Instantiate(bat, FlySpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(nightMare2, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) n.GetComponent<Nightmare>().GoRight();
            }
            yield return new WaitForSeconds(0.4f);
        }
        StartCoroutine("Phase7");
    }
    IEnumerator Phase7()
    {
        int p = 0;
        while (gameTime < bossend[0] + 120)
        {
            p++;
            if (p % 10 == 0)
            {
                int rand = Random.Range(0, 2);
                GameObject w = Instantiate(darkelf, SpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(nightMare2, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) n.GetComponent<Nightmare>().GoRight();
            }
            yield return new WaitForSeconds(0.7f);
        }
        StartCoroutine("Phase8");
    }
    IEnumerator Phase8()
    {
        int p = 0;
        while (gameTime < bossend[0] + 180)
        {
            p++;
            if (p % 15 == 0)
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(darkelf, SpawnPoint[rand].transform.position, transform.rotation);

            }
            else if (p % 5 == 0)
            {
                int rand = Random.Range(0, 5);
                GameObject b = Instantiate(flyeye, FlySpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(nightMare2, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) n.GetComponent<Nightmare>().GoRight();
            }
            yield return new WaitForSeconds(0.3f);
        }
        StartCoroutine("Phase9");
    }
    IEnumerator Phase9()
    {
        int p = 0;
        while (gameTime < bossend[0] + 240)
        {
            p++;
            if (p % 5 == 0)
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(darkelf, SpawnPoint[rand].transform.position, transform.rotation);
            }
            else if (p % 3 == 0)
            {
                int rand = Random.Range(0, 2);
                GameObject n = Instantiate(warm, SpawnPoint[rand].transform.position, transform.rotation);
            }
            else
            {
                int rand = Random.Range(0, 5);
                GameObject b = Instantiate(flyeye, FlySpawnPoint[rand].transform.position, transform.rotation);
            }
            yield return new WaitForSeconds(1f);
        }
        StartCoroutine("Boss2");
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
        bossend[1] = gameTime;
        StartCoroutine("BorderOff");
        StartCoroutine("Phase6");
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
}
