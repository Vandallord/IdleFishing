using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour {

    public int x;

    public GameObject ClickEnemy;

    public GameObject DelUFO;

    public int HPcurret;
    public int HPmax = 3;


    // Use this for initialization
    void Start()
    {
        HPcurret = HPmax;

    }


	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - Time.deltaTime * x, transform.position.y);
	}


    public void UFOKill()
    {
        HPcurret--;
        GameObject aa1 = Instantiate(ClickEnemy, transform.position, this.transform.rotation) as GameObject;
        Destroy(aa1, 3);

        if (HPcurret <= 0)
        {
            GameObject aa2 = Instantiate(DelUFO, transform.position, this.transform.rotation) as GameObject;
            aa2.transform.parent = GameObject.FindGameObjectWithTag("Resp").transform;
            Destroy(aa2, 5);

            Destroy(gameObject);
        }

    }
}
 

