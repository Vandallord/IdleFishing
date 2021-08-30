using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    [SerializeField]
    private bool[] ItemsRods;
    [SerializeField]
    private bool[] ItemsCloths;
    [SerializeField]
    private bool[] ItemsBoats;

    public ItemsDB _itemsDB;

    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private SaveGame _saveGame;

    [SerializeField]
    private Shop _shop;

    private int _loadCloth;
    private int _loadRods;

    [SerializeField]
    private ChengeItems _chengeItems;

    public void OpenItem(byte IdItem, byte type)
    {
        TakeMoney(IdItem, type);

        AddStats(IdItem, type);

        switch (type)
        {
            case 1:
                ItemsRods[IdItem] = true;
                RefreshRodsSprite();
                break;
            case 2:
                ItemsCloths[IdItem] = true;
                RefreshClothsSprite();
                break;
            case 3:
                ItemsBoats[IdItem] = true;
                break;
        }

        _saveGame.SaveItems(type);
    }

    public void AddStats(int IdItem, byte type)
    {
        switch (type)
        {
            case 1:
                _playerStats.AddDamage(_itemsDB.ItemsRods[IdItem].BonusDamage);
                break;
            case 2:
                _playerStats.AddDamage(_itemsDB.ItemsCloths[IdItem].BonusDamage);
                break;
            case 3:
                _playerStats.AddDamage(_itemsDB.ItemsBoats[IdItem].BonusDamage);
                break;
        }
    }

    private void RefreshClothsSprite()
    {
        _loadCloth = 0;
        for (int i = 0; i < ItemsCloths.Length; i++)
        {
            if (ItemsCloths[i])
            {
                _loadCloth = i;
            }
        }

        if (_loadCloth != 0)
        {
            _chengeItems.Cloth = _loadCloth.ToString();
        }
    }

    private void RefreshRodsSprite()
    {
        _loadRods = 0;
        for (int i = 0; i < ItemsRods.Length; i++)
        {
            if (ItemsRods[i])
            {
                _loadRods = i;
            }
        }

        if (_loadRods != 0)
        {
            _chengeItems.Rod = _loadRods.ToString();
        }
    }

    public bool HaveMoney(int IdItem, byte type)
    {
        switch (type)
        {
            case 1:
                return _itemsDB.ItemsRods[IdItem].Cost <= _inventory.ShowMoney();
            // break;
            case 2:
                return _itemsDB.ItemsCloths[IdItem].Cost <= _inventory.ShowMoney();
            // break;
            default://3
                return _itemsDB.ItemsBoats[IdItem].Cost <= _inventory.ShowMoney();
                //     break;
        }
    }

    public void TakeMoney(int IdItem, byte type)
    {
        switch (type)
        {
            case 1:
                _inventory.TakeMoney(_itemsDB.ItemsRods[IdItem].Cost);
                break;
            case 2:
                _inventory.TakeMoney(_itemsDB.ItemsCloths[IdItem].Cost);
                break;
            case 3:
                _inventory.TakeMoney(_itemsDB.ItemsBoats[IdItem].Cost);
                break;
        }
    }

    public bool[] GetAllRods()
    {
        return ItemsRods;
    }
    public bool[] GetAllCloths()
    {
        return ItemsCloths;
    }
    public bool[] GetAllBoats()
    {
        return ItemsBoats;
    }

    public void LoadEquip(bool[] arry, byte type)
    {

        switch (type)
        {
            case 1:
                ItemsRods = arry;
                break;
            case 2:
                ItemsCloths = arry;
                break;
            case 3:
                ItemsBoats = arry;
                break;
        }
    }

    public void LoadEquipToArray(byte type)
    {
        switch (type)
        {
            case 1:
                for (int i = 0; i < ItemsRods.Length; i++)
                {
                    if (ItemsRods[i])
                    {
                        AddStats(i, 1);
                        RefreshRodsSprite();
                        _shop.HideButton(i, 1);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < ItemsCloths.Length; i++)
                {
                    if (ItemsCloths[i])
                    {
                        AddStats(i, 2);
                        RefreshClothsSprite();
                        _shop.HideButton(i, 2);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < ItemsBoats.Length; i++)
                {
                    if (ItemsBoats[i])
                    {
                        AddStats(i, 3);
                        _shop.HideButton(i, 3);
                    }
                }
                break;
        }
    }

    public bool OpenOrCloseLvl(int lvl)
    {
        if (lvl != 0)
        {
            if (ItemsRods[lvl] && ItemsCloths[lvl] && ItemsBoats[lvl])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}
