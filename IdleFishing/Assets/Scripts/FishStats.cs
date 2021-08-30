using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStats : MonoBehaviour {

    [SerializeField] private string Name;
    public int HP;
    [SerializeField] private Sprite Icon;

    public byte AddFishItem;

    public string Info;
    public int Cost;


    [SerializeField]
    private FishDB _fishDB;
    int fishResp;

    // название картинка снизу картинка добавления
    [SerializeField] private SpriteRenderer _iconFishWater;
    [SerializeField] private SpriteRenderer _iconFishAdd;
    [SerializeField] private UnityEngine.UI.Text _fishName;

    public void SetStats(int level)
    {
        fishResp = Random.Range(0, _fishDB.Levels[level].Name.Length);
        HP = _fishDB.Levels[level].HP[fishResp];
        Name = _fishDB.Levels[level].Name[fishResp];
        Icon = _fishDB.FishSprite[_fishDB.Levels[level].FishID[fishResp]];
        AddFishItem = _fishDB.Levels[level].FishID[fishResp];

        SetStatsInfo();
    }

    public void SetStatsInfo()
    {
        _iconFishWater.sprite = Icon;
        _fishName.text = Name;
    }

    public void SetStatsFishAdd()
    { 
        _iconFishAdd.sprite = Icon;
    }
}
