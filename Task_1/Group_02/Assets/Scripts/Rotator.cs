using UnityEngine;

public class Rotator : MonoBehaviour {

    public UIController ui_controller;
    public AudioClip clip;
    public float score = 1f;

	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);	
	}

    void OnTriggerEnter(Collider c) {
        if (c.gameObject.CompareTag("Player")) {
            this.gameObject.SetActive(false);
            ui_controller.PutScore(score);
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
