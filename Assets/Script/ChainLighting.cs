using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLighting : MonoBehaviour
{
    float t;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*2;
        if (t > 1) Destroy(gameObject);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1 - t);
    }
}
