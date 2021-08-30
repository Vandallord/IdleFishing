using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    [SerializeField]
    private GameObject _panel;

    [SerializeField]
    private GameObject _panel1;
    [SerializeField]
    private GameObject _panel2;
    [SerializeField]
    private GameObject _panel3;

    [SerializeField]
    private InventoryPanel _inventoryPanel;

    [SerializeField]
    private Shop _shop;

    [SerializeField]
    private LevelController _levelController;

    [SerializeField]
    private AudioSource _audio;

    public void PanelOpen()
    {
        _panel.SetActive(true);

        if (_panel2.activeSelf)
        {
            _inventoryPanel.RefreshInventoryPanel();
        }
        else if (_panel3.activeSelf)
        {
            _shop.RefreshEquip();
        }
        else if (_panel1.activeSelf)
        {
            _levelController.RefreshMap();
        }

        _audio.Play();
    }

    public void PanelClose()
    {
        _panel.SetActive(false);
        _audio.Play();
    }

    public void Panel1Open()
    {
        _panel1.SetActive(true);
        _panel2.SetActive(false);
        _panel3.SetActive(false);

        _levelController.RefreshMap();

        _audio.Play();
    }

    public void Panel2Open()
    {
        _panel1.SetActive(false);
        _panel2.SetActive(true);
        _panel3.SetActive(false);

        _inventoryPanel.RefreshInventoryPanel();

        _audio.Play();
    }

    public void Panel3Open()
    {
        _panel1.SetActive(false);
        _panel2.SetActive(false);
        _panel3.SetActive(true);

        _shop.RefreshEquip();

        _audio.Play();
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
