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
       
	}

    // Open a level
    public void openLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }


    // Exit the game
    public void exitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
}
