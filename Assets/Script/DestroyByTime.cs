using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] float t;
     void Start()
    {
        Invoke("des", t);
    }
    void des()
    {
        Destroy(gameObject);
    }
   
}
