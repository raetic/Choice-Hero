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
    bool bossFhase;
    [SerializeField] TextMeshProUGUI timeT;
    [SerializeField] GameObject[] SpawnPoint;
    [SerializeField] LevelUp levelUp;
    
    void Start()
    {
        StartCoroutine("SpawnCor");
    }
    public void LvUp()
    {
        levelUp.PopupOn();
    }
    IEnumerator SpawnCor()
    {
        int batCount=0;
        while (!bossFhase)
        {
           if (gameTime <= 60)
            {
                int rand = Random.Range(0, 2);
               
                GameObject HellHound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
                if (rand == 0) HellHound.GetComponent<HellHound>().GoRight();
                yield return new WaitForSeconds(2);
            }
            else if (gameTime <= 120)
            {
                if (batCount != 3)
                {
                    int rand = Random.Range(0, 2);
                   
                   GameObject HellHound = Instantiate(hellHound, SpawnPoint[rand].transform.position, transform.rotation);
                   if (rand == 0) HellHound.GetComponent<HellHound>().GoRight();
                    batCount++;
                }
                else if (batCount == 3)
                {
                    int rand = Random.Range(0, 2);
                    
                  GameObject Bat = Instantiate(bat, SpawnPoint[rand].transform.position, transform.rotation);
                    batCount = 0;
                }
                yield return new WaitForSeconds(1);
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
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
