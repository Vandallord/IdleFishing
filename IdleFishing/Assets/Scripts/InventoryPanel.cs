using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text _money;

    [SerializeField]
    private UnityEngine.UI.Text _sellForText;

    [SerializeField]
    private UnityEngine.UI.Text[] _fishCount;

    [SerializeField]
    private GameObject[] _fishObj;

    [SerializeField]
    private Image[] _fishSprite;

    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private FishDB _fishDB;

    private int _sellFor;

    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private Statistic _statistic;

    private int _sellItemsFor;

    [SerializeField]
    private AudioSource _audio;

    public void RefreshInventoryPanel()
    {
        for (int i = 0; i < _inventory._fishItem.Length; i++)
        {
            if (_inventory._fishItem[i] > 0)
            {
                _fishSprite[i].sprite = _fishDB.FishSprite[i];
                _fishCount[i].text = _inventory._fishItem[i].ToString();
                _fishObj[i].SetActive(true);
            }
            else
            {
                if (_fishObj[i].activeSelf)
                {
                    _fishObj[i].SetActive(false);

                }
            }
        }

        RefreshMoney();
        RefreshSellFor();
    }

    private void RefreshMoney()
    {
        _money.text = "Gold: " + _inventory.ShowMoney();
    }

    private int SellFor()
    {
        _sellFor = 0;

        for (int i = 0; i < _inventory._fishItem.Length; i++)
        {
            if (_inventory._fishItem[i] > 0)
            {
                _sellFor += _inventory._fishItem[i] * _fishDB.FishCost[i];
            }
        }
        return _sellFor;
    }

    private void RefreshSellFor()
    {
        _sellForText.text = "Sell for: " + SellFor();
    }

    public void SellItems()
    {
        if (SellFor() != 0)
        {
            _sellItemsFor = SellFor();
            _inventory.AddMoney(_sellItemsFor);
            _statistic.AddScore(_sellItemsFor);
            _inventory.ClearInventory();

            RefreshInventoryPanel();

            _audio.Play();
        }
    }
}

