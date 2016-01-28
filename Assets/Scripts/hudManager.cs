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
        scoreText.text = "" + gameManagerRef.pickUpAmount + " Remaining";
	
	}
}
