using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public float score = 15f;
    public UIController ui_controller;
    SphereCollider coll;

	// Use this for initialization
	void Start () {
        coll = GetComponent<SphereCollider>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Player approaches the chest");
            ui_controller.PutScore(score);
            ui_controller.ShowWinMessage();
        }
    }
}
