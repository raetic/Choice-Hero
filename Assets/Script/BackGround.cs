using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    int curCenter;
    GameObject player;
    [SerializeField]BattleManager BM;
    
    [SerializeField] GameObject[] backs;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > curCenter + 30)
        {
            curCenter += 30;
            backs[0].transform.position = new Vector3(backs[0].transform.position.x + 90, backs[0].transform.position.y, 0);
            GameObject temp = backs[0];
            backs[0] = backs[1];
            backs[1] = backs[2];
            backs[2] = temp;
            BM.SetCurCenter(curCenter);
        }
        if (player.transform.position.x < curCenter - 30)
        {
            curCenter -= 30;
          
            backs[2].transform.position = new Vector3(backs[2].transform.position.x - 90, backs[2].transform.position.y, 0);
            GameObject temp = backs[2];
            backs[2] = backs[1];
            backs[1] = backs[0];
            backs[0] = temp;
            BM.SetCurCenter(curCenter);
        }
    }
}
