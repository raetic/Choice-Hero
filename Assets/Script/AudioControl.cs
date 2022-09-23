using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioControl : MonoBehaviour
{
    public AudioMixer myMix;

    public Slider bgmSlider;
    public Slider effectSlider;
    public void audioControl(int i)
    {
      
        if (i == 0)
        {
            float sound = bgmSlider.value;
            if (sound == -40f) myMix.SetFloat("BGM", -80);
            else myMix.SetFloat("BGM", sound);


        }
        else
        {
            float sound = effectSlider.value;
            if (sound == -40f) myMix.SetFloat("SFX", -80);
            else myMix.SetFloat("SFX", sound);
        }
    }
}
