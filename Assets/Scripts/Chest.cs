using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

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
            ui_controller.ShowWinMessage();
        }
    }
}
