using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespController : MonoBehaviour {

    public GameObject map;

    public GameObject[] BonusRespRight;
    public GameObject[] BonusRespLeft;

    public GameObject  posRight;
    public GameObject posLeft;


    private float Time1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Time1 += Time.deltaTime;

        //if (Time1 > 60)
        //{
        //    int aa = Random.Range(1, 1);

        //    if (aa == 1)
        //    {

        //        RespBonus();
        //    }

        //    Time1 = 0;
        //}
    }







    public void RespBonus()
    {


        //int Respi = Random.Range(0, 2);

        //if (Respi == 0)
        //{
        //    int BonusRandom1 = Random.Range(0, BonusRespRight.Length);
        //    GameObject aa1 = Instantiate(BonusRespRight[BonusRandom1], posRight.transform.position, this.transform.rotation) as GameObject;
        //    aa1.transform.parent = GameObject.FindGameObjectWithTag("Resp").transform;
        //    Destroy(aa1, 11);
        //}

        //if (Respi == 1)
        //{
        //    int BonusRandom2 = Random.Range(0, BonusRespLeft.Length);
        //    GameObject aa1 = Instantiate(BonusRespLeft[BonusRandom2], posLeft.transform.position, this.transform.rotation) as GameObject;
        //    aa1.transform.parent = GameObject.FindGameObjectWithTag("Resp").transform;
        //    Destroy(aa1, 11);
        //}






    }







   
}
