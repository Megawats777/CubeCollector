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
    public GameObject MainMenuCanvas;

    // Stage Select Canvas
    public GameObject StageSelectCanvas;

    /*----Sub Stage Select Canavas's----*/

    // Easy Stages Canvas
    public GameObject easyStagesCanvas;

    // Medium Stages Canvas
    public GameObject mediumStagesCanvas;

    // Hard Stages Canvas
    public GameObject hardStagesCanvas;

    // How to play canvas
    public GameObject HowToPlayCanvas;

	// Use this for initialization
	void Start ()
    {
        canSelectLevel = true;

        // Enable the mouse cursor
        Cursor.visible = true;

        MainMenuCanvas.SetActive(true);
        StageSelectCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
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

    // Open the stage select canvas
    public void openStageSelect()
    {
        if (StageSelectCanvas)
        {
            MainMenuCanvas.SetActive(false);
            StageSelectCanvas.SetActive(true);
        }
    }

    //Open the sub stage select canvas's

    // Open the easy stages canvas
    public void openEasyStages()
    {
        if (easyStagesCanvas)
        {
            StageSelectCanvas.SetActive(false);
            easyStagesCanvas.SetActive(true);
        }
    }

    // Open the medium stages canvas
    public void openMediumStages()
    {
        if (mediumStagesCanvas)
        {
            StageSelectCanvas.SetActive(false);
            mediumStagesCanvas.SetActive(true);
        }
    }

    // Open the hard stages canvas
    public void openHardStages()
    {
        if (hardStagesCanvas)
        {
            StageSelectCanvas.SetActive(false);
            hardStagesCanvas.SetActive(true);
        }
    }

    // Open the how to play canvas
    public void openHowtoPlay()
    {
        if (HowToPlayCanvas)
        {
            MainMenuCanvas.SetActive(false);
            HowToPlayCanvas.SetActive(true);
        }
    }

    // Hide the stage select canvas
    public void hideStageSelect()
    {
        StageSelectCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    //Hide the sub stage select canvas's

    // Hide the easy stages canvas
    public void hideEasyStages()
    {
        easyStagesCanvas.SetActive(false);
        StageSelectCanvas.SetActive(true);
    }

    // Hide the medium stages canvas
    public void hideMediumStages()
    {
        mediumStagesCanvas.SetActive(false);
        StageSelectCanvas.SetActive(true);
    }

    // Hide the hard stages canvas
    public void hideHardStages()
    {
        hardStagesCanvas.SetActive(false);
        StageSelectCanvas.SetActive(true);
    }

    // Hide the how to play canvas
    public void hideHowtoPlay()
    {
        HowToPlayCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }

    // Exit the game
    public void exitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
}
