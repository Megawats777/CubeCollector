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
        // Update the content of clockText
        clockText.text = "Time: " + (int)gameManagerRef.clocklength;

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
}
