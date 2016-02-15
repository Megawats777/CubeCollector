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
        clockText.text = "" + (int)gameManagerRef.clocklength;

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
        if (gameManagerRef.clocklength <= 6)
        {
            clockText.color = Color.red;
        }
        else
        {
            clockText.color = Color.white;
        }
    }

}
