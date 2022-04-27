using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public int mount;
    bool come;
    GameObject target;
    public void ComeTo(GameObject t)
    {
        target = t;
        come = true;
    }
    private void Update()
    {
        if (come)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 10 * Time.deltaTime);
        }
    }
}
