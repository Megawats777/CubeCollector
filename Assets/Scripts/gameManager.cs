using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameManager : MonoBehaviour {

    // Reference the mesh renderer component
    private MeshRenderer objectMesh;

    // Hold the player's score
    [HideInInspector]
    public int playerScore = 0;

    // The target score for the level
    [HideInInspector]
    private int targetScore = 80;

    // Sets the target score for the level
    [HideInInspector]
    public int setTargetScore = 0;

    // Sets if the game is active
    [HideInInspector]
    public bool isGameActive = false;

    // Sets if the pickup counter can be increased
    private bool canIncreasePickUpCount = true;

    // Reference to the player sphere
    [HideInInspector]
    public playerController playerSphere;

    // References to the pickup objects
    [HideInInspector]
    public pickUp[] pickUps;

    // Store the amount of cube pickups
    [HideInInspector]
    public int pickUpAmount;

    // Clock Number
    [Range (5, 150)]
    public float clockLength = 10;

    // Is the clock active
    [HideInInspector]
    public bool isClockActive = false;

    // Default clock length
    private float defaultClockLength;

    // Clock Audio Source
    [HideInInspector]
    public AudioSource clockSoundSource;

    // Clock Audio Clip
    public AudioClip clockTickSound;

    // Reference the mainHUD
    [HideInInspector]
    public hudManager mainHUD;

    // Use this for initialization
    void Start()
    {
        objectMesh = GetComponent<MeshRenderer>();

        // Disable the mesh renderer component
        objectMesh.enabled = false;

        // Get all the cube pickups in the level
        getPickUps();

        // Reference the playerSphere
        getPlayer();

        // Reference the hudManager
        mainHUD = FindObjectOfType<hudManager>();

        // Get the audio source component
        getClockAudioSource();

        // Set clock audio clip
        setClockAudioClip();

        playerScore = 0;

        targetScore = setTargetScore;

        defaultClockLength = clockLength;

        print(targetScore);

    }

    // Update is called once per frame
    void Update() {

        restartGame();

        gameClock();

        gameClockCheck();
        
    }

    // Game Clock
    private void gameClock()
    {
        if (isGameActive == true && clockLength > 0 && isClockActive == true)
        {
            clockLength = clockLength - Time.deltaTime;
            
            // If the clocklength is less than 1 then play a sound
            if (clockLength < 1)
            {
                clockSoundSource.Play();
            }
        }
    }

    // Check the status of the game clock
    private void gameClockCheck()
    {
        if (clockLength < 1)
        {
            // Reset the game clock
            resetClock();

            // Set is clock active to false
            isClockActive = false;

            // Disable the player's movement
            disablePlayerMovement();

            // Allow the player to start the game
            playerSphere.canStartGame = true;

            // Reset the player's locaiton to its initial spawn location
            playerSphere.respawnProcess();

            // Set is game active to false
            isGameActive = false;
        }
    }

    // Reset clock
    public void resetClock()
    {
        clockLength = defaultClockLength;
    }

    // Add to the current time remaining
    public void increaseClock(int increaseAmount)
    {
        clockLength = clockLength + increaseAmount + 1;
        print("Time Extended");
    }

    // Get references to all cube pickups
    private void getPickUps()
    {
        pickUps = FindObjectsOfType<pickUp>();

        foreach (pickUp cubePickups in pickUps)
        {
            pickUpAmount = pickUpAmount + 1;
        }
       
        print("There are " + pickUpAmount + " cubes");
    }

    // Reference the player
    private void getPlayer()
    {
        playerSphere = FindObjectOfType<playerController>();

        if(playerSphere)
        {
            print("PlayerSphere referenced");
        }
        else
        {
            print("PlayerSphere reference failed");
        }
    }

    // Get audio source
    private void getClockAudioSource()
    {
        clockSoundSource = GetComponent<AudioSource>();
    }

    // Set clock audio clip
    private void setClockAudioClip()
    {
        clockSoundSource.clip = clockTickSound;
    }

    // Reduce pickUp amount
    public void reducePickups()
    {
        pickUpAmount = pickUpAmount - 1;

        print("There are " + pickUpAmount + " left!");

        if (pickUpAmount == 0)
        {
            print("All cubes collected you win!");

            // Reset the game clock
            resetClock();

            // Set isClockActive to false
            isClockActive = false;

            playerSphere.setPlayerPhysics(false);

            // Disable player movement
            disablePlayerMovement();
        }
    }

    // Increase pickup amount
    public void increasePickups()
    {
        if (canIncreasePickUpCount == true)
        {
            pickUpAmount = pickUpAmount + 1;
            canIncreasePickUpCount = false;
        }
    }

    // Disable player movement
    void disablePlayerMovement()
    {
        playerSphere.canMove = false;
        playerSphere.setPlayerPhysics(false);
    }

    // Enable player movement
    void enablePlayerMovement()
    {
        playerSphere.canMove = true;
        playerSphere.setPlayerPhysics(true);
    }

    // Allow the player to restart the game
    void restartGame()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pickUpAmount <= 0 & isGameActive == true)
            {
                isGameActive = false;
                playerSphere.respawnProcess();
                disablePlayerMovement();
                playerSphere.canStartGame = true;
            }
        }
    }

    // Pickup reference palet code
    /*
       GameObject foundPickups = GameObject.Find("pickUp");
       pickUps = pickUps.GetComponent<pickUp>();
       pickUpAmount = pickUpAmount + 1;
       */

    /*
    foreach (GameObject cubePickups in pickUps)
    {
        pickUps = GetComponent<pickUp>();
        pickUpAmount = pickUpAmount + 1;
    }
    */




}
