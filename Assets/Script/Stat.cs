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
    int[] stats = new int[8];
    public void StatUp()
    {
        jumpCount = stats[0];
        physicsDmg = stats[1];
        magicDmg = stats[2];
        cooltime = stats[3];
        attackSpeed = stats[4];
        attackedDmg = stats[5];
        exp = stats[6];
        speed = stats[7];
    }
    public float Exp { get => exp; set => exp = value; }
    public int JumpCount { get => jumpCount; set => jumpCount = value; }
    public float PhysicsDmg { get => physicsDmg; set => physicsDmg = value; }
    public float MagicDmg { get => magicDmg; set => magicDmg = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Cooltime { get => cooltime; set => cooltime = value; }
    public float AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public float AttackedDmg { get => attackedDmg; set => attackedDmg = value; }
    public int[] Stats { get => stats; set => stats = value; }
}
