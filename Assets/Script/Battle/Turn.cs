using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public float rotateSpeed;
    float t;
    public float startRotate;
    
    void Update()
    {
        t += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, startRotate+t*rotateSpeed);
        if (t * rotateSpeed >= 360) t = 0;
        
    }
}
