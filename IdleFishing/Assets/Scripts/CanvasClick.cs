using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasClick : MonoBehaviour
{
    [SerializeField]
    private Animator _animPlayer;
    [SerializeField]
    private Animator _animFish;

    [SerializeField]
    private GameObject _animAddFish;

    private bool _fishLife;

    [SerializeField]
    private LevelController _levelController;

    private bool _fishDie;
    private bool _fishResp;
    private bool _upFishBug;

    [SerializeField]
    private Slider _sliderFishHP;
    public FishStats _fishStats;

    [SerializeField]
    private PlayerStats _playerStats;

    [SerializeField]
    private Inventory _inventory;

    [SerializeField]
    private AudioSource _clickSound;

    [SerializeField]
    private AudioSource _downRopeSound;

    private int _soundClick;

    void Start()
    {
        StartCoroutine(IdleAttack());
    }

    private IEnumerator IdleAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f);
            Click();
        }
    }

    public void Click()
    {
        if (!_fishLife)
        {

            RespFish();
        }
        else
        {
            ClickFish();
        }
    }

    private void RespFish()
    {
        if (!_fishResp)
        {
            _animPlayer.SetTrigger("goFising");// это срабатывает отдельно от 

            StartCoroutine("PauseRespFish");
        }
    }

    private void ClickFish()
    {
        if (!_fishDie) // чтоб когда мертвая рыба ничего не кликал
        {
            if (!_clickSound.isPlaying)
            {
                _clickSound.Play();
            }

            _fishStats.HP -= _playerStats.Damage();
            _sliderFishHP.value = _fishStats.HP;
            _animPlayer.SetTrigger("click");

            if (_fishStats.HP <= 0)//& _fixBug
            {
                _fishStats.HP = 0;
                // улов
                _sliderFishHP.gameObject.SetActive(false);

                // и запуск куратины через несколько секунд чтоб опять можно закинуть было
                // и в конце включаем fishLife
                _fishDie = true;
                StartCoroutine("PauseUpFish");
            }
        }
    }

    private IEnumerator PauseRespFish()
    {
        _fishStats.SetStats(_levelController.ReturnLevel());
        _animFish.SetTrigger("StartFish");

        // обновить кликалку
        _sliderFishHP.maxValue = _fishStats.HP;
        _sliderFishHP.value = _fishStats.HP;
        _fishResp = true;

        yield return new WaitForSeconds(1.2f);
        _downRopeSound.Play();
        yield return new WaitForSeconds(1.5f);
        _sliderFishHP.gameObject.SetActive(true);

        _fishLife = true;
        _fishResp = false;
    }

    private IEnumerator PauseUpFish()
    {
        _fishStats.SetStatsFishAdd();
        _animFish.SetTrigger("FishUp");

        _inventory.AddFishItem(_fishStats.AddFishItem);

        yield return new WaitForSeconds(1.1f);
        _animPlayer.SetTrigger("pecks");
        yield return new WaitForSeconds(2f);//2.3
        _animAddFish.SetActive(true);
        _animPlayer.ResetTrigger("click");
        _fishLife = false;
        _fishDie = false;
    }

    public void StopFising()
    {
        _animFish.Rebind();
        _animPlayer.Rebind();

        _fishLife = false;
        _fishResp = false;
        _fishDie = false;

        StopCoroutine("PauseUpFish");
        StopCoroutine("PauseUpFish");

        _sliderFishHP.gameObject.SetActive(false);
    }
}
