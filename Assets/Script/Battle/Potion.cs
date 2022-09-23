using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField] int value;
    bool t;
    SpriteRenderer sprite;
    private void Awake()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 50);
        Invoke("Die", 12);
        sprite = GetComponent<SpriteRenderer>();
    }
    void Die()
    {
        StartCoroutine("DieCor");
    }
    IEnumerator DieCor()
    {
        int k = 0;
        while (k < 12)
        {
            k++;
            if (!t)
            {
                sprite.color = new Color(1, 1, 1, 0.2f);
                t = true;

            }
            else
            {
                sprite.color = new Color(1, 1, 1, 1f);
                t = false;
            }
            yield return new WaitForSeconds(0.25f);
        }
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SfxControl.Instance.UseSfxHp();
            collision.gameObject.GetComponent<Player>().HpUp(value);
            Destroy(gameObject);
        }
    }
}
