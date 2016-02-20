using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RestartTextManager : MonoBehaviour
{
    // Reference to the text component
    [HideInInspector]
    public Text restartText;

    // Reference to the gameManager class
    [HideInInspector]
    public gameManager gameManagerRef;

    // Content for the restartText component
    public string restartTextContent = "Press Space to restart game";

	// Use this for initialization
	void Start ()
    {
        // Get the text component
        restartText = GetComponent<Text>();

        // Get the gameManager
        gameManagerRef = FindObjectOfType<gameManager>();

        // Set the content of the text component to null
        restartText.text = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set text component content
        setTextContent();

	}

    // Set text component content
    private void setTextContent()
    {
        // If all pickups were collected then set the content to notify the player they can restart the game
        if (gameManagerRef.pickUpAmount == 0)
        {
            restartText.text = restartTextContent;
        }
        // Otherwise set the content of the text component to null
        else
        {
            restartText.text = null;
        }
    }
}
