using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDance : MonoBehaviour
{

    [SerializeField] GameObject[] sword;
    int objSize = 1;
    float circleR=0.7f;
    float deg;
    float objSpeed=60;
    [SerializeField] GameObject Player;
    
    public void LevelUp(int i)
    {
        if (i == 2)
        {
            objSpeed = 90;
        }
        if (i == 3)
        {
            circleR = 1f;
        }
        if (i == 4)
        {
            for(int j = 0; j < 3; j++)
            {
                sword[j].GetComponent<Attack>().DmgX(1.3f);
            }
        }
        if (i == 4)
        {
            objSpeed = 120;
        }
        if (i == 5)
        {
            objSize = 2;
            sword[1].SetActive(true);
        }
        if (i == 6)
        {
            for (int j = 0; j < 3; j++)
            {
                sword[j].transform.localScale *= 1.3f;
            }
        }
        if (i == 7)
        {
            for (int j = 0; j < 3; j++)
            {
                sword[j].GetComponent<Attack>().DmgX(1.3f);
            }
        }
        if (i == 8)
        {
            objSpeed = 150;
        }
        if (i == 9)
        {
            objSize = 3;
            sword[2].SetActive(true);
        }
    }

    void Update()
    {
        if (Player.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
        deg += Time.deltaTime * objSpeed;
        if (deg < 360)
        {
            for (int i = 0; i < objSize; i++)
            {
                var rad = Mathf.Deg2Rad * (deg + (i * (360 / objSize)));
                var x = circleR * Mathf.Sin(rad);
                var y = circleR * Mathf.Cos(rad);
                sword[i].transform.position = transform.position + new Vector3(x, y);
                sword[i].transform.rotation = Quaternion.Euler(0, 0, (deg + (i * (360 / objSize))) * -1);
            }

        }
        else
        {
            deg = 0;
        }
    }
}
