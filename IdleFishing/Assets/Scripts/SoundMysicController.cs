using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMysicController : MonoBehaviour
{
    // изменить паблик
    [SerializeField]
    private GameObject musicButton;
    [SerializeField]
    private GameObject soundButton;
    [SerializeField]
    private bool musicBButton;
    [SerializeField]
    private bool soundBButton;
    [SerializeField]
    private Sprite[] NoMusic;
    [SerializeField]
    private Sprite[] NoSound;

    public AudioMixer audioMixer;

    public GameObject music;

    public void Start()
    {
     //   PlayerPrefs.DeleteAll();
        LoadMusicAndSound();
    }

    public void MusicStop()
    {
        if (!musicBButton)
        {
            musicButton.GetComponent<Image>().sprite = NoMusic[0];
            musicBButton = true;
            music.SetActive(true);
            PlayerPrefs.SetInt("saveMusic", 0);
        }
        else if (musicBButton)
        {
            musicButton.GetComponent<Image>().sprite = NoMusic[1];
            musicBButton = false;
            music.SetActive(false);
            PlayerPrefs.SetInt("saveMusic", 1);
        }
    }

    public void SoundStop()
    {
        if (!soundBButton)
        {
            audioMixer.SetFloat("editSoundV", 10);
            soundButton.GetComponent<Image>().sprite = NoSound[0];
            PlayerPrefs.SetInt("saveSound", 0);
            soundBButton = true;
        }
        else if (soundBButton)
        {
            audioMixer.SetFloat("editSoundV", -80);
            soundButton.GetComponent<Image>().sprite = NoSound[1];
            PlayerPrefs.SetInt("saveSound", 1);
            soundBButton = false;
        }
    }

    public void LoadMusicAndSound()
    {
        int saveMusic = PlayerPrefs.GetInt("saveMusic");

        if (saveMusic == 1)
        {
            musicButton.GetComponent<Image>().sprite = NoMusic[1];
            musicBButton = false;
            music.SetActive(false);
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = NoMusic[0];
            musicBButton = true;
            music.SetActive(true);
        }

        int saveSound = PlayerPrefs.GetInt("saveSound");

        if (saveSound == 1)
        {
            audioMixer.SetFloat("editSoundV", -80);
            soundButton.GetComponent<Image>().sprite = NoSound[1];
            soundBButton = false;
        }
        else
        {
            audioMixer.SetFloat("editSoundV", 10);
            soundButton.GetComponent<Image>().sprite = NoSound[0];
            soundBButton = true;
        }
    }
}

