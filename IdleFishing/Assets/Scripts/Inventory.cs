using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public ushort[] _fishItem;

    [SerializeField]
    private int _money;

    [SerializeField] private SaveGame _saveGame;

    public void AddFishItem(byte id)
    {
        _fishItem[id]++;
        _saveGame.SaveOneFish(id);
    }

    public void LoadFishItem()
    {
        for (int i = 0; i < _fishItem.Length; i++)
        {
            _fishItem[i] = (ushort)PlayerPrefs.GetInt("FishItem" + i);
        }
    }

    public ushort ReturnOneFishItem(byte id)
    {
        return _fishItem[id];
    }

    public ushort[] ReturnAllFishItem()
    {
        return _fishItem;
    }

    public void ClearInventory()
    {
        ClearFish();
        _saveGame.AllFishClearSave();
    }

    private void ClearFish()
    {
        for (int i = 0; i < _fishItem.Length; i++)
        {
            if (_fishItem[i] > 0)
            {
                _fishItem[i] = 0;
            }
        }
    }

    public void TakeMoney(int CostMoney)
    {
        _money -= CostMoney;
        _saveGame.SaveMoney();
    }

    public void AddMoney(int AddMoney)
    {
        _money += AddMoney;
        _saveGame.SaveMoney();
    }

    public void AddMoneyLoad(int AddMoney)
    {
        _money += AddMoney;
    }

    public int ShowMoney()
    {
        return _money;
    }
}
