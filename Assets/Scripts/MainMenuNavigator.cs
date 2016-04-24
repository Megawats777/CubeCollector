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

    /*----Sub How to Play Canvas's----*/

    // Controls help canvas
    public GameObject controlsHelpCanvas;

    // Game Rules help canvas
    public GameObject gameRulesHelpCanvas;

    // Event triggered before start
    void Awake()
    {

        // Dont destroy this object on load
        DontDestroyOnLoad(gameObject);

        // Check which menu canvas's to spawn when the menu level is loaded
        canvasSpawnCheck();

        // Find all the other canvases
        findCanvases();
    }

    // Use this for initialization
    void Start()
    {
        // Enable the mouse cursor
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Find all the other canvases
    private void findCanvases()
    {

    }

    // Check for the amount of main menu navigators
    private void menuNavigatorAmountCheck()
    {
        MainMenuNavigator[] menuNavigatiors = FindObjectsOfType<MainMenuNavigator>();

        // Perform a loop to see how many menu naivgators there are in the level
        for (int i = 0; i < menuNavigatiors.Length; i++)
        {
            // If there is more than one menu navigator destroy the second menu navigator
            if (i > 0)
            {
                Destroy(menuNavigatiors[1].gameObject);
            }
        }
    }

    // Check which menu canvas's to spawn when the menu level is loaded
    private void canvasSpawnCheck()
    {
        /*
        // If the player has just started the game spawn the title screen
        if (playedLevel == false)
        {
            print("Spawning title screen");
            MainMenuCanvas.SetActive(true);
            disableSecondaryCanvases();
        }

        // Otherwise spawn the stage select screen
        else if (playedLevel == true)
        {
            print("Spawning stage select screen");
            StageSelectCanvas.SetActive(true);
        }
        */
    }

    // Disable all other menu canvas's other than the main menu
    private void disableSecondaryCanvases()
    {
        // Disable all other menu canvas's
        StageSelectCanvas.SetActive(false);
        easyStagesCanvas.SetActive(false);
        mediumStagesCanvas.SetActive(false);
        hardStagesCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(false);
        controlsHelpCanvas.SetActive(false);
        gameRulesHelpCanvas.SetActive(false);
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

    // Show the controls help canvas
    public void showControlsHelp()
    {
        HowToPlayCanvas.SetActive(false);
        controlsHelpCanvas.SetActive(true);
    }

    // Show the game rules help canvas
    public void showGameRulesHelp()
    {
        HowToPlayCanvas.SetActive(false);
        gameRulesHelpCanvas.SetActive(true);
    }

    // Hide the controls help canvas
    public void hideControlsHelp()
    {
        controlsHelpCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(true);
    }

    // Hide the game rules help canvas
    public void hideGameRulesHelp()
    {
        gameRulesHelpCanvas.SetActive(false);
        HowToPlayCanvas.SetActive(true);
    }

    // Exit the game
    public void exitGame()
    {
        Application.Quit();
        print("Game Closed");
    }
}
