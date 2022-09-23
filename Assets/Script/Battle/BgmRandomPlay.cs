using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmRandomPlay : MonoBehaviour
{

    public AudioClip[] Music = new AudioClip[4]; // 사용할 BGM
    AudioSource AS;
    bool InGame;

    void Awake()
    {
        AS = this.GetComponent<AudioSource>();
    }
    public void defeat()
    {
        AS.clip = Music[2];
        AS.Play();
        AS.loop = true;
    }
    void Update()
    {
        if (!AS.isPlaying)
            RandomPlay();
    }

    void RandomPlay()
    {
        AS.clip = Music[Random.Range(0,2)];
        AS.Play();
    }
}
