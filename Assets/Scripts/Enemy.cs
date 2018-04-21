using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IAxeHittable {

    float health = 10f;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0) {
            Debug.Log("I am dead.");
            Destroy(gameObject);
        }
	}

    public void OnGetHitByAxe(float hitValue) {
        Debug.Log("Ouch! I got hit!");
        this.health -= hitValue;

    }
}
