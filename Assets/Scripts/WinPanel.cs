using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinPanel : MonoBehaviour {

    // Reference to the winPanel
    [HideInInspector]
    public Image winPanel;

    // Reference to the gameManager
    [HideInInspector]
    public gameManager gameManagerRef;

	// Use this for initialization
	void Start ()
    {
        // Get the winPanel
        winPanel = GetComponent<Image>();

        // Get the gameManager
        gameManagerRef = FindObjectOfType<gameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    // Toggle the panel's visibility
        if (gameManagerRef.pickUpAmount < 1)
        {
            winPanel.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            winPanel.color = new Color(0, 0, 0, 0);
        }
	}
}
