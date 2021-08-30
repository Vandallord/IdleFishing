using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _shopRods;
    [SerializeField]
    private GameObject[] _shopCloths;
    [SerializeField]
    private GameObject[] _shopBoats;

    [SerializeField]
    private Equip _equip;

    [SerializeField]
    private Image[] _ImageEquipRod;
    [SerializeField]
    private Image[] _ImageEquipCloth;
    [SerializeField]
    private Image[] _ImageEquipBoat;

    [SerializeField]
    private AudioSource _audio;

    public void RefreshEquip()
    {
        for (byte i = 1; i < 7; i++)
        {
            if (_equip.HaveMoney(i, 1))
            {
                _ImageEquipRod[i].color = Color.green;
            }
            else
            {
                if (_ImageEquipRod[i].color == Color.green)
                {
                    _ImageEquipRod[i].color = Color.white;
                }
            }

            if (_equip.HaveMoney(i, 2))
            {
                _ImageEquipCloth[i].color = Color.green;
            }
            else
            {
                if (_ImageEquipCloth[i].color == Color.green)
                {
                    _ImageEquipCloth[i].color = Color.white;
                }
            }

            if (_equip.HaveMoney(i, 3))
            {
                _ImageEquipBoat[i].color = Color.green;
            }
            else
            {
                if (_ImageEquipBoat[i].color == Color.green)
                {
                    _ImageEquipBoat[i].color = Color.white;
                }
            }
        }
    }

    public void BuyRods(int id)
    {
        if (_equip.HaveMoney(id, 1))
        {
            _equip.OpenItem((byte)id, 1);// там отнимаются деньги
            _shopRods[id].SetActive(false);
            // передается
            // сохраняется

            RefreshEquip();
            _audio.Play();
        }
    }
    public void BuyCloths(int id)
    {
        if (_equip.HaveMoney(id, 2))
        {
            _equip.OpenItem((byte)id, 2);// там отнимаются деньги
            _shopCloths[id].SetActive(false);

            RefreshEquip();
            _audio.Play();
        }
    }
    public void BuyBoats(int id)
    {
        if (_equip.HaveMoney(id, 3))
        {
            _equip.OpenItem((byte)id, 3);// там отнимаются деньги
            _shopBoats[id].SetActive(false);

            RefreshEquip();
            _audio.Play();
        }
    }

    public void HideButton(int i, byte type)
    {
        switch (type)
        {
            case 1:
                _shopRods[i].SetActive(false);
                break;
            case 2:
                _shopCloths[i].SetActive(false);
                break;
            case 3:
                _shopBoats[i].SetActive(false);
                break;
        }
    }
}
