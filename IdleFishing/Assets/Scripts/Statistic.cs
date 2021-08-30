using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistic : MonoBehaviour {

    [SerializeField]
    private SaveGame _saveGame;

    public int Score;

    public void AddScore(int addScore)
    {
        Score += addScore;
        SaveScore();
    }

    private void SaveScore()
    {
        // чтоб сохранялся еще там
        _saveGame.SaveScore(Score);

        Application.ExternalCall("kongregate.stats.submit", "Score", Score);
    }
}
