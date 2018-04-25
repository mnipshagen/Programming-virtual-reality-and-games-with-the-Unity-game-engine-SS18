using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text text;
    public Canvas canvas;
    public int startMessageDuration = 4;
    public Color fadeColor = new Color(0, 0, 1, 2.0f/255.0f);
    private long startTime;
    private bool fadingOutText;

	// Use this for initialization
	void Start () {
        fadeColor = new Color(0, 0, 0, 2.0f / 255.0f);
        fadingOutText = true;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        if(Time.fixedTime > startMessageDuration && fadingOutText)
        {
            text.color -= fadeColor;
            if(text.color.a <= 0)
            {
                fadingOutText = false;
            }
        }
    }

    public void ShowWinMessage()
    {
        text.text = "You found the treasure, \n you win!";
        text.color += new Color(0, 0, 0, 1);
    }
}
