using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text on_screen_message;
    public Text on_screen_score;
    public Canvas canvas;
    public int startMessageDuration = 4;
    public Color fadeColor = new Color(0, 0, 1, 2.0f/255.0f);
    public float score = 0;
    private long startTime;
    private bool fadingOutText;
    private float max_score;

	// Use this for initialization
	void Start () {
        fadeColor = new Color(0, 0, 0, 2.0f / 255.0f);
        fadingOutText = true;
        foreach (GameObject coin in GameObject.FindGameObjectsWithTag("Coin")) {
            Chest chest = coin.GetComponent<Chest>();
            Rotator rot = coin.GetComponent<Rotator>();
            if (chest != null) {
                max_score += chest.score;
            }
            else if (rot != null) {
                max_score += rot.score;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        on_screen_score.text = score.ToString();
	}

    private void FixedUpdate()
    {
        if(Time.fixedTime > startMessageDuration && fadingOutText)
        {
            on_screen_message.color -= fadeColor;
            if(on_screen_message.color.a <= 0)
            {
                fadingOutText = false;
            }
        }
    }

    public void ShowWinMessage()
    {
        on_screen_message.text = string.Format("You found the treasure!\n You collected {0} of {1} coins!", score, max_score);
        on_screen_message.color += new Color(0, 0, 0, 1);
    }

    public void PutScore(float amount) {
        score += amount;
    }
}
