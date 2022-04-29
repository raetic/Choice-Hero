using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public float cooltime;
    Player player;
    [SerializeField]GameObject weapon;
    public int smash;
    [SerializeField] GameObject smashPrefebs;
    [SerializeField] GameObject smashPrefebs2;
    public int wave;
    [SerializeField] GameObject wavePrefebs;
    [SerializeField] GameObject boltPrefebs;
    public int bolt;
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    public void InstSmash()
    {
        GameObject newObj = Instantiate(smashPrefebs, weapon.transform.position, transform.rotation);
        if (smash > 2)
        {
            newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
            if (smash > 3)
            {
                GameObject windObj = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                windObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * -600);
                windObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
                if (smash > 4)
                {
                    windObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                    if (smash > 5)
                    {
                        windObj.GetComponent<Attack>().SetDestroyCount(2);
                        if (smash > 6)
                        {
                            windObj.GetComponent<Attack>().DmgX(1.5f);
                            newObj.GetComponent<Attack>().DmgX(1.5f);
                            if (smash > 7)
                            {
                                GameObject windObj2 = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                                windObj2.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * 600);
                                windObj2.transform.localScale *= new Vector2(player.transform.localScale.x * 1, 1);
                                windObj2.transform.localScale *= new Vector2(1.5f, 1.5f);
                                windObj2.GetComponent<Attack>().SetDestroyCount(2);
                                windObj2.GetComponent<Attack>().DmgX(1.5f);
                                if (smash > 8)
                                {
                                    newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    windObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                                    windObj2.transform.localScale *= new Vector2(1.5f, 1.5f);
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
        GameObject waveObj=Instantiate(wavePrefebs, player.transform.position+new Vector3(0,0.3f), transform.rotation);
        waveObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * -400);
        waveObj.transform.localScale *= new Vector2(player.transform.localScale.x*-1,1);
        if (wave <2)
        {
            Invoke("InstWave", 5 / cooltime);
        }
      
     
    }
    public void InstBolt()
    {
        int n = 5;
        int speed = 150;
        float cool = 8;
        for(int i = 0; i <n; i++)
        {
         GameObject boltObj = Instantiate(boltPrefebs, player.transform.position + new Vector3(0, 0.3f),
         Quaternion.Euler(0,0, (180*i / (n-1))+180)); //투사체의 각도가 자연스럽게 회전값을 넣었다.
         Vector2 dirVec = new Vector2(Mathf.Cos((Mathf.PI)*i / (n-1)), Mathf.Sin((Mathf.PI) * i / (n-1)));
         //원을 기준으로 각각의 투사체마다 벡터를 정리
         boltObj.GetComponent<Rigidbody2D>().AddForce(dirVec*speed);
        }
        Invoke("InstBolt", cool/cooltime);
    }
}
