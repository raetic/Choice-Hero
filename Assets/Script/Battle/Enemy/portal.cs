using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    SpriteRenderer sprite;
    public float[] c = new float[3];
    int change;
    bool up;
    float time;
    [SerializeField] GameObject boss4;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        c[0] = 1;
        c[1] = 1;
        
    }
    public void downMount(int i)
    {
        c[i] -= Time.deltaTime*2;
    }
    public void upMount(int i)
    {
      c[i] += Time.deltaTime*2;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime*2;
        if (time < 1)
        {
            downMount(1);
        }
        else if (time < 2)
        {
            upMount(2);
        }
        else if (time < 3)
        {
            downMount(0);
        }
        else if (time < 4)
        {
            upMount(1);
        }
        else if (time < 5)
        {
            downMount(2);
        }
        else if (time < 6)
        {
            upMount(0);
        }
        else time = 0;
        sprite.color = new Color(c[0], c[1], c[2]);
    }
    public void Summon()
    {
        GameObject boss = Instantiate(boss4, transform.position, transform.rotation);
        boss.GetComponent<Boss4>().setTransX(transform.position.x);
        Destroy(gameObject);
    }
}
