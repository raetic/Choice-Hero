using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public float cooltime;
    Player player;
    [SerializeField]int[] skills=new int[20];
    [SerializeField]GameObject weapon;
    enum skill{
            smash=0,
            wave=1,
            bolt=2
    }

    [SerializeField] GameObject smashPrefebs;
    [SerializeField] GameObject smashPrefebs2;
    
    [SerializeField] GameObject wavePrefebs;
    [SerializeField] GameObject boltPrefebs;
    Stat stat;
    
    public int[] Skills { get => skills; set => skills = value; }

    private void Awake()
    {
        player = GetComponent<Player>();
        stat = GetComponent<Stat>();
        skills[0] = 1;
    }
    public void InstSkill(int s)
    {
        if (s == 1) InstWave();
        if (s == 2) InstBolt();
    }
    public void InstSmash()
    {if (skills[0] <2) return;
        GameObject newObj = Instantiate(smashPrefebs, weapon.transform.position, transform.rotation);
        if (skills[(int)skill.smash] > 2)
        {
            newObj.transform.localScale *= new Vector2(1.5f, 1.5f);
            if (skills[(int)skill.smash] > 3)
            {
                GameObject windObj = Instantiate(smashPrefebs2, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
                windObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * -600);
                windObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
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
                                windObj2.GetComponent<Attack>().SetDestroyCount(1);
                                windObj2.GetComponent<Attack>().DmgX(1.5f);
                                if (skills[(int)skill.smash] > 8)
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
        float cool = 5;
        float speed = -400;
        if (skills[(int)skill.wave] > 1)
        {
            speed *= 1.5f;
            if (skills[(int)skill.wave] > 6) cool -= 2;
            if (skills[(int)skill.wave] > 7) speed *= 1.5f;
        }
        GameObject waveObj = Instantiate(wavePrefebs, player.transform.position + new Vector3(0, 0.3f), transform.rotation);
        waveObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(player.transform.localScale.x, 0) * speed);
        waveObj.transform.localScale *= new Vector2(player.transform.localScale.x * -1, 1);
        if (skills[(int)skill.wave] > 2)
        {
            waveObj.GetComponent<Attack>().SetDestroyCount(2);
            if (skills[(int)skill.wave] > 3)
            {
                waveObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                if (skills[(int)skill.wave] > 4)
                {
                    waveObj.GetComponent<Attack>().SetDestroyCount(2);
                    if (skills[(int)skill.wave] > 5)
                    {
                        waveObj.GetComponent<Attack>().DmgX(2);
                        if (skills[(int)skill.wave] > 8)
                        {
                            waveObj.transform.localScale *= new Vector2(1.5f, 1.5f);
                            if (skills[(int)skill.wave] > 9)
                            {
                                waveObj.GetComponent<Attack>().SetDestroyCount(100);
                            }
                        }
                    }
                }
            }




        }
        Invoke("InstWave", cool / (1+0.2f*cooltime));
    }
    public void InstBolt()
    {
        float scale = 1;
        int pen = 0;
        float dmg = 1;
        int n = 5;
        float speed = 150;
        float cool = 8;
        if (skills[(int)skill.bolt] > 1) speed *= 1.3f;
        if (skills[(int)skill.bolt] > 2) pen++;
        if (skills[(int)skill.bolt] > 3) scale *= 1.5f;
        if (skills[(int)skill.bolt] > 4) n = 8;
        if (skills[(int)skill.bolt] > 5) dmg *= 1.5f;
        if (skills[(int)skill.bolt] > 6) cool -= 3;
        if (skills[(int)skill.bolt] > 7) n = 10;
        if (skills[(int)skill.bolt] > 8) pen += 3;
        if (skills[(int)skill.bolt] > 9) n = 20;
        for(int i = 0; i <n; i++)
        {
         GameObject boltObj = Instantiate(boltPrefebs, player.transform.position + new Vector3(0, 0.3f),
         Quaternion.Euler(0,0, (180*i / (n-1))+180)); //투사체의 각도가 자연스럽게 회전값을 넣었다.
         Vector2 dirVec = new Vector2(Mathf.Cos((Mathf.PI)*i / (n-1)), Mathf.Sin((Mathf.PI) * i / (n-1)));
            //원을 기준으로 각각의 투사체마다 벡터를 정리
            boltObj.transform.localScale *= scale;
            boltObj.GetComponent<Rigidbody2D>().AddForce(dirVec*speed);
            boltObj.GetComponent<Attack>().DmgX(dmg);
            boltObj.GetComponent<Attack>().SetDestroyCount(pen);
        }
        Invoke("InstBolt", cool/ (1 + 0.2f * cooltime));
    }
}
