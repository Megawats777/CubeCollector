using UnityEngine;
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (gameManagerRef.pickUpAmount == 0)
        {
            winLabel.text = "You Win!";
        }
        else
        {
            winLabel.text = " ";
        }

	}
}
