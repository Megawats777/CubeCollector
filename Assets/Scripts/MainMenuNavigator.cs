using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuNavigator : MonoBehaviour
{
    // Level names
    public string[] levelNames;

    // Can the user select a level
    [HideInInspector]
    public bool canSelectLevel;

	// Use this for initialization
	void Start ()
    {
        canSelectLevel = true;

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Exit the game
        exitGame();
	}

    /*
    // Level selection 
    private void selectLevel()
    {
        // Select level one
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // If level One exists
            if (levelNames[0] != null)
            {
                canSelectLevel = false;
                SceneManager.LoadSceneAsync(levelNames[0]);
            }
        }

    

    }
    */

    // Exit the game
    private void exitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
