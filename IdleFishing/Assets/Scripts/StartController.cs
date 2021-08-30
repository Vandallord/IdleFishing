using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour {


    [SerializeField] private GameObject _gameConvas;
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _mapGame;

    public void StartGame()
    {
        _gameConvas.SetActive(true);
        _mapGame.SetActive(true);
        _startScreen.SetActive(false);
    }
}
