using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int _damage = 1;

    [SerializeField]
    private int _maxLevel;

    public int Damage()
    {
        return _damage;
    }

    public void AddDamage(int AddDmg)
    {
        _damage += AddDmg;
    }
}
