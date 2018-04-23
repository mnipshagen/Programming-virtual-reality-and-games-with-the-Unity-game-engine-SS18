using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameState gameState;
    //public GUIText text;
    public Text text;
    public Canvas canvas;
    public int startMessageDuration = 4;
    public Color fadeColor = new Color(0, 0, 1, 2.0f/255.0f);
    private long startTime;

	// Use this for initialization
	void Start () {
        //canvas.GetComponentInChildren<Text>;
        fadeColor = new Color(0, 0, 0, 2.0f / 255.0f);
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        //Debug.Log(text.color);
        //Debug.Log(Time.fixedTime);
        if(Time.fixedTime > startMessageDuration && text.color.a > 0)
        {
            text.color -= fadeColor;
        }
        if(Time.fixedTime > 7)
        {
            text.text = "You found the treasure, \n you win!";
            text.color += new Color(0, 0, 0, 1);
        }
    }
}
