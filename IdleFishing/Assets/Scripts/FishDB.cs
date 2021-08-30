using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishDB", menuName = "FishDB", order = 53)]
public class FishDB : ScriptableObject
{
    [SerializeField] public FishType[] Levels;
    [SerializeField] public Sprite[] FishSprite;
    [SerializeField] public int[] FishCost;
}

[System.Serializable]
public class FishType
{
    public byte[] FishID;

    public string[] Name;

    public int[] HP;

    public string[] Info;

    public Sprite BackGround;
    public Sprite BackGroundWater;
}

