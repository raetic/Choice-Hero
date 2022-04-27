using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dmg : MonoBehaviour
{

    float a = 1f;
    [SerializeField] TextMeshPro t;
    public void SetText(int dmg,bool isRed)
    {
        t.text = dmg + "";
        if (isRed) t.color = new Color(1, 0, 0);
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime*0.5f);
        Color color = t.color;
        color.a = a;
        t.color = color;
        a -= Time.deltaTime;
        if (a < 0) Destroy(gameObject);
    }
}
