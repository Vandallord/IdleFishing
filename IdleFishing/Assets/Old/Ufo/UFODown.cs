using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFODown : MonoBehaviour {

    public GameObject vzriv;
    public GameObject soundvztiv;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject aa1 = Instantiate(vzriv, transform.position, this.transform.rotation) as GameObject;
            Destroy(aa1, 3);
            GameObject aa2 = Instantiate(soundvztiv, transform.position, this.transform.rotation) as GameObject;
            Destroy(aa2, 3);
            Destroy(this.gameObject);

        //    GameObject.FindWithTag("Respawn").GetComponent<Ruletka>().DownUfoS();

        }
        
    }
}
