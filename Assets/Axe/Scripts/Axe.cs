using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class Axe : MonoBehaviour {


    float damage = 5f;
    Animator anim;
    CapsuleCollider cap_coll;
    List<GameObject> been_hit = new List<GameObject>();
    bool in_attack = false;
    RigidbodyFirstPersonController player;
        

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

        cap_coll = GetComponent<CapsuleCollider>();
        cap_coll.enabled = false;

        player = this.transform.root.gameObject.GetComponent<RigidbodyFirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        var pos = transform.position;
        var current_position = new Vector2(pos.x, pos.y);
		if (!in_attack && Input.GetKeyDown(KeyCode.Mouse0)) {
            in_attack = true;
            this.anim.SetTrigger("Attack");
        }
	}

    public void ActivateCollider(int active) {
        cap_coll.enabled = !(active == 0);
    }

    public void ReadyAttack() {
        in_attack = false;
        been_hit = new List<GameObject>();
    }

    private void FixedUpdate() {
        var input = GetInput();
        var moved = (input.x != 0 || input.y != 0);
        Debug.Log(moved);
        this.anim.SetBool("Walk", moved);

        this.anim.SetBool("Run", player.movementSettings.Running);
    }



    void OnTriggerEnter(Collider c) {
        GameObject other = c.gameObject;
        IAxeHittable target = other.GetComponent<IAxeHittable>();

        if (target != null && !been_hit.Contains(other)) {
            been_hit.Add(other);
            c.gameObject.SendMessage("OnGetHitByAxe", damage);
        }
    }

    private Vector2 GetInput() {

        Vector2 input = new Vector2 {
            x = CrossPlatformInputManager.GetAxis("Horizontal"),
            y = CrossPlatformInputManager.GetAxis("Vertical")
        };

        return input;
    }

}
