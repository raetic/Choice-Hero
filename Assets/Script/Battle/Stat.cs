using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat : MonoBehaviour
{
    [SerializeField] float exp = 0;
    [SerializeField] int jumpCount=0;
    [SerializeField] float physicsDmg = 0;
    [SerializeField] float magicDmg = 0;
    [SerializeField] float speed = 0;
    [SerializeField] float cooltime=0;
    [SerializeField] float attackSpeed=0;
    [SerializeField] float attackedDmg=0;
    [SerializeField] int teleport = 0;
    int[] stats = new int[9];
    public void StatUp(int i)
    {
        if (i == 0)
            jumpCount++;
        if (i == 1)
            physicsDmg++;
        if (i == 2)
            magicDmg++;
        if (i == 3)
            cooltime++;
        if (i == 4)
            attackSpeed++;
        if (i == 5)
            attackedDmg++;
        if (i == 6)
            exp++;
        if (i == 7)
            speed++;
        if (i == 8)
            teleport++;
    }
    public float Exp { get => exp; set => exp = value; }
    public int JumpCount { get => jumpCount; set => jumpCount = value; }
    public float PhysicsDmg { get => physicsDmg; set => physicsDmg = value; }
    public float MagicDmg { get => magicDmg; set => magicDmg = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Cooltime { get => cooltime; set => cooltime = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float AttackedDmg { get => attackedDmg; set => attackedDmg = value; }
    public int Teleport { get => teleport; set => teleport = value; }
    public int[] Stats { get => stats; set => stats = value; }
}
