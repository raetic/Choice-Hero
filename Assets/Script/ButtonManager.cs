using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    public void OnLeft()
    {
        p.isLeft = true;
    }
    public void OffLeft()
    {
        p.isLeft = false;
    }
    public void OnRight()
    {
       p.isRight = true;
    }
    public void OffRight()
    {
        p.isRight = false;
    }
    public void Jump()
    {
        p.Jump();
    }
}
