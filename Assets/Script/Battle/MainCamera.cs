using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] BattleManager BM;
    bool isEarthQ;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9); // (가로 / 세로)
        float scalewidth = 1f / scaleheight;
        if (scaleheight < 1)
        {
            rect.height = scaleheight;
            rect.y = (1f - scaleheight) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
       
    }
    public void EQ()
    {
        isEarthQ = true;
        Invoke("EQoff", 0.2f);
    }
    public void EQoff()
    {
        isEarthQ = false;
    }
    void OnPreCull() => GL.Clear(true, true, Color.black);
    void FixedUpdate()
    {   if (!isEarthQ&&!BM.bossPhase)
          transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x , -1.5f , -10), 15* Time.deltaTime);
        else if(isEarthQ&&!BM.bossPhase)
        {

            float rand1 = Random.Range(-50, 50);

            float rand2 = Random.Range(-50, 50);
            transform.position = new Vector3(player.transform.position.x + rand1 / 200, -1.5f + rand2 / 200, -10);

        }
        else if(isEarthQ&&BM.bossPhase)
        {
            float rand1 = Random.Range(-50, 50);
            float rand2 = Random.Range(-50, 50);
            transform.position = new Vector3(transform.position.x + rand1 / 200, -1.5f + rand2 / 200, -10);
        }
    }
}
