﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class winTextManager : MonoBehaviour {

    // Reference to the text component
    [HideInInspector]
    public Text winLabel;

    // Reference to the gameManager class
    public gameManager gameManagerRef;

	// Use this for initialization
	void Start () {

        winLabel = GetComponent<Text>();

        // Reference the gameManager
        getGameManager();

	}
	
	// Update is called once per frame
	void Update () {
	
        if (gameManagerRef.pickUpAmount == 0)
        {
            winLabel.text = "You Win!";
        }
        else if (gameManagerRef.clocklength < 1 )
        {
            winLabel.text = "Game Over";
        }
        else
        {
            winLabel.text = " ";
        }
	}

    // Reference the gameManager
    private void getGameManager()
    {
        gameManagerRef = FindObjectOfType<gameManager>();
    }
}
