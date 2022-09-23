using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxControl : MonoBehaviour
{

    public static SfxControl Instance = null;
    
    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject);}
        else { if (Instance != this) Destroy(this.gameObject);  }


        sfx = GetComponents<AudioSource>();
    }


    //게임 매니저 인스턴스에 접근할 수 있는 프로퍼티. static이므로 다른 클래스에서 맘껏 호출할 수 있다.

    [SerializeField] AudioSource[] sfx;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip levelUp;
    [SerializeField] AudioClip[] Skills;
    [SerializeField] AudioClip EnemyHit;
    [SerializeField] AudioClip GetHp;
    [SerializeField] AudioClip GetRe;
    public void UseSfxJump()
    {
        for (int i = 0; i < 30; i++)
        {
            if (!sfx[i].isPlaying)
            {
                sfx[i].PlayOneShot(jump);
                break;
            }
        }
    }
    public void UseSfxLevelUp()
    {
        for (int i = 0; i < 30; i++)
        {
            if (!sfx[i].isPlaying)
            {
                sfx[i].PlayOneShot(levelUp);
                break;
            }
        }
    }
    public void UseSfxSkill(int s)
    {
        for (int i = 0; i < 30; i++)
        {
            if (!sfx[i].isPlaying)
            {
                sfx[i].PlayOneShot(Skills[s]);
                break;
            }
        }
    }
    public void UseSfxEnemyHit()
    {
        for (int i = 0; i < 30; i++)
        {
            if (!sfx[i].isPlaying)
            {
                sfx[i].PlayOneShot(EnemyHit);
                break;
            }
        }
    }
    public void UseSfxHp()
    {
        for (int i = 0; i < 30; i++)
        {
            if (!sfx[i].isPlaying)
            {
                sfx[i].PlayOneShot(GetHp);
                break;
            }
        }
    }
    public void UseSfxre()
    {
        for (int i = 0; i < 30; i++)
        {
            if (!sfx[i].isPlaying)
            {
                sfx[i].PlayOneShot(GetRe);
                break;
            }
        }
    }
}
