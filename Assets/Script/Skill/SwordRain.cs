using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRain : MonoBehaviour
{
    bool isDown;
    public bool over;
    [SerializeField] Sprite[] s;
    private void Start()
    {
        int rand = Random.Range(0, s.Length);
        GetComponent<SpriteRenderer>().sprite = s[rand];
    }
    void down()
    {
        isDown = true;
        int rand = Random.Range(-400,400);
        if (over) rand *= 2;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 225));
        GetComponent<Rigidbody2D>().AddForce(new Vector2(rand, -1500));
    }
    void Update()
    {
        if (transform.position.y > 3&&!isDown)
        {
            down();
        }
    }
}
