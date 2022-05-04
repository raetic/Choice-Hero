using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public int mount;
    bool come;
    GameObject target;
    float time;
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    public void setMount(int mo)
    {
        mount = mo;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (time > 0.5f)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 8*time * Time.deltaTime);
        
    }
}
