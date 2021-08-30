using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private byte _level;

    [SerializeField]
    private SaveGame _saveGame;

    [SerializeField]
    private SpriteRenderer _bg;
    [SerializeField]
    private SpriteRenderer _bgWater;

    private byte _lvlByte;

    [SerializeField]
    private FishDB _fishDB;

    [SerializeField]
    private ButtonController _buttonController;

    [SerializeField]
    private Equip _equip;

    [SerializeField]
    private CanvasClick _canvasClick;

    [SerializeField]
    private GameObject _noItemsScreen;

    [SerializeField]
    private Image[] _ImageNeedItems;
    [SerializeField]
    private GameObject[] _ImageNeedItemsGameObject;

    [SerializeField]
    private ItemsDB _itemsDB;

    [SerializeField]
    private GameObject[] _boats;

    [SerializeField]
    private Transform[] _positionPlayer;

    [SerializeField]
    private Transform _playerPosition;

    [SerializeField]
    private Image[] _imageButton;

    [SerializeField]
    private Sprite[] _clouds;

    [SerializeField]
    private SpriteRenderer[] _cloudMap;
    [SerializeField]
    private GameObject _cloudObjMap;

    [SerializeField]
    private AudioSource _audioMapNoItems;

    [SerializeField]
    private AudioSource _audioAriaTeleport;

    public void StartLevel(int lvl)
    {
        // проверка есть ли необходимые вещи если нетто пишиться чего не хватает
        if (_equip.OpenOrCloseLvl(lvl))
        {
            _lvlByte = (byte)lvl;
            LoadLevel(_lvlByte);
            _saveGame.SaveLevel(_lvlByte);
            _buttonController.PanelClose();
            // чтоб рыба и анимация обнулялась
            _canvasClick.StopFising();
            _audioAriaTeleport.Play();
        }
        else
        {
            // показывается картинка чего не хватает для данного уровня, чтобы туда отправиться что нужно

            if (!_equip.GetAllRods()[lvl])
            {
                _ImageNeedItems[0].sprite = _itemsDB.ItemsRods[lvl].Icon;
                _ImageNeedItemsGameObject[0].SetActive(true);
            }

            if (!_equip.GetAllCloths()[lvl])
            {
                _ImageNeedItems[1].sprite = _itemsDB.ItemsCloths[lvl].Icon;
                _ImageNeedItemsGameObject[1].SetActive(true);
            }

            if (!_equip.GetAllBoats()[lvl])
            {
                _ImageNeedItems[2].sprite = _itemsDB.ItemsBoats[lvl].Icon;
                _ImageNeedItemsGameObject[2].SetActive(true);
            }
            _noItemsScreen.SetActive(true);
            _audioMapNoItems.Play();
        }
    }

    public byte ReturnLevel()
    {
        return _level;
    }
    public void LoadLevel(byte level) // в начало еще
    {
        _level = level;
        _bg.sprite = _fishDB.Levels[level].BackGround;
        _bgWater.sprite = _fishDB.Levels[level].BackGroundWater;
        LoadBoat(level);
        LoadPositionPlayer(level);
        LoadButtonMap(level);
        LoadClouds(level);
        // бг загрузить
    }

    private void LoadPositionPlayer(byte level)
    {
        _playerPosition.position = _positionPlayer[level].position;
    }

    private void LoadBoat(byte level)
    {
        foreach (var item in _boats)
        {
            if (item.activeSelf)
            {
                item.SetActive(false);
            }
        }
        _boats[level].SetActive(true);
    }

    private void LoadButtonMap(byte level)
    {
        foreach (var item in _imageButton)
        {
            if (item.color == Color.green)
            {
                item.color = Color.white;
            }
        }
        _imageButton[level].color = Color.green;
    }

    private void LoadClouds(byte level)
    {
        if (_clouds[level] != null)
        {
            _cloudObjMap.SetActive(true);
            _cloudMap[0].sprite = _clouds[level];
            _cloudMap[1].sprite = _clouds[level];
        }
        else
        {
            _cloudObjMap.SetActive(false);
        }
    }

    public void RefreshMap()
    {
        for (int i = 0; i < _imageButton.Length; i++)
        {
            if (_equip.OpenOrCloseLvl(i))
            {
                if (_imageButton[i].color == Color.grey)
                {
                    _imageButton[i].color = Color.white;
                }
            }
            else
            {
                if (_imageButton[i].color == Color.white)
                {
                    _imageButton[i].color = Color.grey;
                }
            }
        }
    }
}
