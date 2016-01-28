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
    public bool isGameActive = true;

    // Sets if the pickup counter can be increased
    private bool canIncreasePickUpCount = true;

    // Reference to the player sphere
    public playerController playerSphere;

    // References to the pickup objects
    [HideInInspector]
    public GameObject[] pickUps;

    // Store the amount of cube pickups
    [HideInInspector]
    public int pickUpAmount;

	// Use this for initialization
	void Start ()
    {
        objectMesh = GetComponent<MeshRenderer>();

        // Disable the mesh renderer component
        objectMesh.enabled = false;

        // Get all the cube pickups in the level
        getPickUps();

        playerScore = 0;

        targetScore = setTargetScore;

        print(targetScore);

	}
	
	// Update is called once per frame
	void Update () {
	
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
        pickUps = GameObject.FindGameObjectsWithTag("cubePickup");

        foreach (GameObject cubePickups in pickUps)
        {
            pickUpAmount = pickUpAmount + 1;
        }

        print("There are " + pickUpAmount + " cubes");
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
        playerSphere.sphereBody.useGravity = false;
        playerSphere.sphereBody.isKinematic = true;
    }

}
