using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClockTextManager : MonoBehaviour {

    // Reference to the text componet
    [HideInInspector]
    public Text clockText;

    // Reference to the gameManager object
    [HideInInspector]
    public gameManager gameManagerRef;

	// Use this for initialization
	void Start ()
    {
        clockText = GetComponent<Text>();
        gameManagerRef = FindObjectOfType<gameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set the content of the text component
        setTextContent();

        // Set the color of the text component
        setTextColour();
	}

    // Set the content of the text
    private void setTextContent()
    {
        // Update the content of clockText
        clockText.text = "Time " + (int)gameManagerRef.clocklength;

        // If the game clock reaches zero
        if (gameManagerRef.clocklength < 1)
        {
            clockText.text = null;
        }
        else if (gameManagerRef.pickUpAmount == 0)
        {
            clockText.text = null;
        }
    }

    // Set the color of the text
    private void setTextColour()
    {
        // If the clocklength is 5 and below then set the clock color to red
        if (gameManagerRef.clocklength <= 6)
        {
            clockText.color = Color.red;
        }
        // Otherwise set the clock color to white
        else
        {
            clockText.color = Color.black;
        }
    }

}
