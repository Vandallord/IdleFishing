using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseToClick : MonoBehaviour {

    [SerializeField]
    private GameObject _thisObj;

    [SerializeField]
    private GameObject[] _imageObj;

    void Update () {

        if (Input.anyKeyDown)
        {
            _thisObj.SetActive(false);
            _imageObj[0].SetActive(false);
            _imageObj[1].SetActive(false);
            _imageObj[2].SetActive(false);
        }
	}
}
