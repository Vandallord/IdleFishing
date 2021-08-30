using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Equip _equip;
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private Statistic _statistic;

    private bool[] _items;
    private string _saveString;

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        LoadLevel();
        LoadAll();
    }

    public void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", _inventory.ShowMoney());
    }

    public void SaveOneFish(byte id)
    {
        PlayerPrefs.SetInt("FishItem" + id, _inventory.ReturnOneFishItem(id));
    }

    public void AllFishClearSave()//нужна? чтобы когда очищяем сохранять пустой?
    {
        for (int i = 0; i < _inventory.ReturnAllFishItem().Length; i++)
        {
            PlayerPrefs.SetInt("FishItem" + i, 0);
        }
    }

    public void SaveItems(byte type)//?
    {
        switch (type)
        {
            case 1:
                _items = _equip.GetAllRods();
                _saveString = null;
                for (int i = 0; i < _items.Length; i++)
                {
                    _saveString += BoolToInt(_items[i]);
                }
                PlayerPrefs.SetString("EqipRods", _saveString);
                break;
            case 2:
                _items = _equip.GetAllCloths();
                _saveString = null;
                for (int i = 0; i < _items.Length; i++)
                {
                    _saveString += BoolToInt(_items[i]);
                }
                PlayerPrefs.SetString("EqipCloths", _saveString);
                break;
            case 3:
                _items = _equip.GetAllBoats();
                _saveString = null;
                for (int i = 0; i < _items.Length; i++)
                {
                    _saveString += BoolToInt(_items[i]);
                }
                PlayerPrefs.SetString("EqipBoats", _saveString);
                // PlayerPrefs.SetString("EqipBoats", JsonConvert.SerializeObject(_equip.GetAllBoats()));
                break;
        }
    }

    private int BoolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    private bool IntToBool(int val)
    {
        if (val == 1)
            return true;
        else
            return false;
    }

    public void SaveLevel(byte lvl)
    {
        PlayerPrefs.SetInt("lvl", lvl);
    }

    public void LoadAll()
    {
        LoadMoney();
        LoadFish();
        LoadItems();
        LoadScore();
    }

    public void LoadMoney()
    {
        _inventory.AddMoneyLoad(PlayerPrefs.GetInt("Money"));
    }

    public void LoadFish()
    {
        _inventory.LoadFishItem();
    }

    public void LoadItems()
    {
        string LoadRodsStr = PlayerPrefs.GetString("EqipRods");
        string LoadClothsStr = PlayerPrefs.GetString("EqipCloths");
        string LoadBoatsStr = PlayerPrefs.GetString("EqipBoats");
        //   bool[] LoadRods = JsonConvert.DeserializeObject<bool[]>(PlayerPrefs.GetString("EqipRods"));
        //   bool[] LoadCloths = JsonConvert.DeserializeObject<bool[]>(PlayerPrefs.GetString("EqipCloths"));
        //   bool[] LoadBoats = JsonConvert.DeserializeObject<bool[]>(PlayerPrefs.GetString("EqipBoats"));

        if (LoadRodsStr != null)
        {
            bool[] LoadRods = new bool[8];
            for (int i = 0; i < LoadRodsStr.Length; i++)
            {
                LoadRods[i] = IntToBool(System.Convert.ToUInt16(LoadRodsStr[i].ToString()));
            }

            _equip.LoadEquip(LoadRods, 1);
            _equip.LoadEquipToArray(1);
        }

        if (LoadClothsStr != null)
        {
            bool[] LoadCloths = new bool[8];
            for (int i = 0; i < LoadClothsStr.Length; i++)
            {
                LoadCloths[i] = IntToBool(System.Convert.ToUInt16(LoadClothsStr[i].ToString()));
            }

            _equip.LoadEquip(LoadCloths, 2);
            _equip.LoadEquipToArray(2);
        }

        if (LoadBoatsStr != null)
        {
            bool[] LoadBoats = new bool[8];
            for (int i = 0; i < LoadBoatsStr.Length; i++)
            {
                LoadBoats[i] = IntToBool(System.Convert.ToUInt16(LoadBoatsStr[i].ToString()));
            }
            _equip.LoadEquip(LoadBoats, 3);
            _equip.LoadEquipToArray(3);
        }
    }

    public void LoadLevel()
    {
        _levelController.LoadLevel((byte)PlayerPrefs.GetInt("lvl"));
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }

    public void LoadScore()
    {
        _statistic.Score = PlayerPrefs.GetInt("Score");
    }
}
