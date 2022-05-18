using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSet : MonoBehaviour
{
    [SerializeField] GameObject[] mountain;
    [SerializeField] GameObject[] ground;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 3; i++)
        {
            mountain[i].transform.Translate(new Vector3(0.2f, 0, 0) * Time.deltaTime);
            if (mountain[i].GetComponent<RectTransform>().position.x > 18)
            {

                mountain[i].transform.position -= new Vector3(17.7778f * 2, 0);
            }
            ground[i].transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime);
           
            if (ground[i].GetComponent<RectTransform>().position.x > 18)
            {
               
                ground[i].transform.position -= new Vector3(17.7778f*2, 0);
            }
        }
    }
    public void goBattle() 
    {
        SceneManager.LoadScene("battle");
    }
}
