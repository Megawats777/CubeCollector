using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class hudManager : MonoBehaviour {

    public gameManager gameManagerRef;

    private Text scoreText;

	// Use this for initialization
	void Start () {

        scoreText = GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {

        // Set the content of the hud score text
        if (gameManagerRef.pickUpAmount > 0 & gameManagerRef.isGameActive == true)
        {
            scoreText.text = "" + gameManagerRef.pickUpAmount + " Remaining";
        }
        else if (gameManagerRef.pickUpAmount <= 0)
        {
            // Content of score text will contain nothing
            scoreText.text = null;
        }
        else if (gameManagerRef.isGameActive == false)
        {
            scoreText.text = "Press Space to start game";
        }
	}
}
