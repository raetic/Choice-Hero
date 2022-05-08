using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    float t;
    
    void Update()
    {
        t += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, t*rotateSpeed);
        if (t * rotateSpeed >= 360) t = 0;
        
    }
}
