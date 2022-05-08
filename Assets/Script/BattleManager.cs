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
    [SerializeField] GameObject warm;
    [SerializeField] GameObject[] boss;
    bool bossFhase;
    [SerializeField] TextMeshProUGUI timeT;
    [SerializeField] GameObject[] SpawnPoint;
    [SerializeField] LevelUp levelUp;
    [SerializeField] GameObject[] FlySpawnPoint;
    public int LvUpCount;
    public bool bossPhase;

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
            yield return new WaitForSeconds(0.7f);
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
            if (p % 3 == 0)
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
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine("Boss1");
    }
    IEnumerator Boss1()
    {
        bossPhase = true;
        int rand = Random.Range(0, 2);
        GameObject Hound = Instantiate(boss[0], FlySpawnPoint[rand+2].transform.position, transform.rotation);
        while (bossPhase)
        {
            yield return new WaitForSeconds(1);
        }
        Debug.Log("보스 1 컷");
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
