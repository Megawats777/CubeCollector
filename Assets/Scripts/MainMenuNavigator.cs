using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuNavigator : MonoBehaviour
{
    // Level names
    public string[] levelNames;

    // Can the user select a level
    [HideInInspector]
    public bool canSelectLevel;

    // Main Menu Canvas
    public Canvas MainMenuCanvas;

    // Stage Select Canvas
    public Canvas StageSelectCanvas;

    // How to play canvas
    public Canvas HowToPlayCanvas;

	// Use this for initialization
	void Start ()
    {
        canSelectLevel = true;

        // Enable the mouse cursor
        Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
	}

    // Open a level
    public void openLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void hideCanvas()
    {
        if (isActiveAndEnabled == true)
        {
            HowToPlayCanvas.enabled = false;
        }
    }
    // Exit the game
    public void exitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
}
