using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BottomExitText : MonoBehaviour
{
    // Reference to the gameManager
    [HideInInspector]
    public gameManager gameManagerRef;

    // Reference to the text component
    [HideInInspector]
    public Text exitText;

	// Use this for initialization
	void Start ()
    {
        // Get the gameManager
        getGameManager();

        // Get the text component
        getText();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Update the content of the text component
        updateText();
	}

    // Get the gameManager
    private void getGameManager()
    {
        gameManagerRef = FindObjectOfType<gameManager>();
    }

    // Get the text component
    private void getText()
    {
        exitText = GetComponent<Text>();
    }

    // Update the content of the text component
    private void updateText()
    {
        if (gameManagerRef)
        {
            // If there are any pickups remaining
            if (gameManagerRef.pickUpAmount > 0)
            {
                exitText.text = "Press Esc to Exit";
            }
            // Otherwise make the content blank
            else
            {
                exitText.text = null;
            }
        }
    }
}
