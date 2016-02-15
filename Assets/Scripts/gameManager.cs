using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class gameManager : MonoBehaviour {

    // Reference the mesh renderer component
    private MeshRenderer objectMesh;

    // Hold the player's score
    public int playerScore = 0;

    // The target score for the level
    private int targetScore = 80;

    // Sets the target score for the level
    public int setTargetScore = 0;

    // Sets if the game is active
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
    public float clock = 10;

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

        playerScore = 0;

        targetScore = setTargetScore;

        print(targetScore);


    }

    // Update is called once per frame
    void Update() {

        restartGame();

        gameClock();
    }

    // Game Clock
    private void gameClock()
    {
        clock = clock + Time.deltaTime;
        print((int)clock);
        
    }

    // Add to the player's score
    public void addToScore(int value)
    {
        playerScore = playerScore + value;

        if (playerScore >= targetScore)
        {
            print("You Win!");
        }
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


    // Reduce pickUp amount
    public void reducePickups()
    {
        pickUpAmount = pickUpAmount - 1;

        print("There are " + pickUpAmount + " left!");

        if (pickUpAmount == 0)
        {
            print("All cubes collected you win!");

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
                enablePlayerMovement();
                isGameActive = false;
                playerSphere.respawnProcess();
                playerSphere.setPlayerPhysics(false);
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
