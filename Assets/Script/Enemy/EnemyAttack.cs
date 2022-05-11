using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]int dmg;
    public bool notD;
    public int GetDmg()
    {
        return dmg;
    }
}
