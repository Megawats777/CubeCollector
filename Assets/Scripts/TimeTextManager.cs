using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeTextManager : MonoBehaviour {

    // Reference to the gameManager object
    private gameManager gameManagerRef;

    // Reference to a text UI component
    private Text timeText;

	// Use this for initialization
	void Start ()
    {
        // Get GameManager Object
        getGameManager();

        // Get text UI Component
        getText();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set Timer Text
        setTimeText();
	}

    // Get text UI Component
    private void getText()
    {
        timeText = GetComponent<Text>();
    }

    // Get GameManager Object
    private void getGameManager()
    {
        gameManagerRef = FindObjectOfType<gameManager>();
    }

    // Set Timer Text
    private void setTimeText()
    {
        timeText.text = "Time Remaning: " + gameManagerRef.clock;
    }
}
