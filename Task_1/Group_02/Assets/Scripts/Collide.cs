using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collide : Axe {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {

    }

    void OnTriggerEnter(Collider c) {
        GameObject other = c.gameObject;
        IAxeHittable target = other.GetComponent<IAxeHittable>();
        Debug.Log("We hit something");

        if (target != null && !been_hit.Contains(other)) {
            Debug.Log("AND IT WAS THE ENEMY");
            been_hit.Add(other);
            c.gameObject.SendMessage("OnGetHitByAxe", damage);
        }
    }
}
