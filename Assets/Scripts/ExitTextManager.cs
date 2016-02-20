using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitTextManager : MonoBehaviour
{
    // Reference to the text component
    [HideInInspector]
    public Text exitText;

    // Reference to the gameManager class
    [HideInInspector]
    public gameManager gameManagerRef;

    // Content of the exitText component
    public string exitTextContent = "Press Esc to Exit";

	// Use this for initialization
	void Start ()
    {
        // Get the text component
        exitText = GetComponent<Text>();

        // Get the gameManager class
        gameManagerRef = FindObjectOfType<gameManager>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set the content of the text component
        setTextContent();
	}

    // Set the content of the text component
    private void setTextContent()
    {
        // If there are not pickups left in the level display the exit message
        if (gameManagerRef.pickUpAmount == 0)
        {
            exitText.text = exitTextContent;
        }
        // Otherwise set the content to null
        else
        {
            exitText.text = null;
        }
    }



}
