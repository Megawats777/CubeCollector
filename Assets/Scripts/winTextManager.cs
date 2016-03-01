using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class winTextManager : MonoBehaviour {

    // Reference to the text component
    [HideInInspector]
    public Text winLabel;

    // Reference to the gameManager class
    public gameManager gameManagerRef;

    // Message for win message for the text component
    public string winMessage = "You Win";

	// Use this for initialization
	void Start () {

        winLabel = GetComponent<Text>();

        // Reference the gameManager
        getGameManager();

	}
	
	// Update is called once per frame
	void Update () {
	
        // Update the content of the text component
        if (gameManagerRef.pickUpAmount == 0)
        {
            winLabel.text = winMessage;
        }
        else if (gameManagerRef.clockLength < 1 )
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
