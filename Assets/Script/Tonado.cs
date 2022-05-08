using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tonado : MonoBehaviour
{
    public float speed = 1;
    int v=1;
    [SerializeField] GameObject g;
    float f = 0;
    bool isOn;
    public float destroyTime;
    private void Start()
    {
        v = Random.Range(0, 2);
        v = -1 + 2 * v;
        Invoke("Think", 1f);
        Invoke("Des", destroyTime);
    }
    void Des()
    {
        Destroy(gameObject);
    }
    void Think()
    {
        v = Random.Range(0, 2);
        v = -1 + 2 * v;
        Invoke("Think", 1f);
    }
    private void Update()
    {
        transform.Translate(new Vector3(v, 0) * speed * Time.deltaTime);
        f += Time.deltaTime;
        if (!isOn && f >= 0.3f)
        {
            isOn = true;
            g.SetActive(true);
            f = 0;
        }
        if (isOn && f >= 0.1f)
        {
            isOn = false;
            g.SetActive(false);
            f = 0;
        }
    }
}
