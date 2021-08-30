using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDB", menuName = "ItemsDB", order = 53)]
public class ItemsDB : ScriptableObject
{
    //[SerializeField]
    //public ItemsStats[] Items;

    [SerializeField]
    public ItemsStats[] ItemsRods;

    [SerializeField]
    public ItemsStats[] ItemsCloths;

    [SerializeField]
    public ItemsStats[] ItemsBoats;
}

[System.Serializable]
public class ItemsStats
{
    public byte ID; // по нему будет считаться есть ли для данной карты или нет

    public string Name;

    public int BonusDamage;

  //  public byte Type;// 0 удочка 1 одежда 2 лодка

    public Sprite Icon;

    public int Cost;
}
