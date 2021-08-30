using UnityEngine;
using System.Collections;
using System;

public class CoinAnimation : MonoBehaviour
{
    void OnEnable()
    {
        // звук
        // старт анимации
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            gameObject.SetActive(false);
            break;
        }
    }
}
