using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour {


    float damage = 5f;
    Animator anim;
    CapsuleCollider cap_coll;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        cap_coll = GetComponent<CapsuleCollider>();
        cap_coll.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
            this.anim.SetTrigger("Attack");
        }
	}

    public void ActivateCollider(int active) {
        if (active == 0) {
            cap_coll.enabled = false;
        }
        else {
            cap_coll.enabled = true;
        }
    }




    void OnTriggerEnter(Collider c) {
        if (c.gameObject.GetComponent<IAxeHittable>() != null) {
            cap_coll.enabled = false;
            c.gameObject.SendMessage("OnGetHitByAxe", damage);
        }
    }

}
