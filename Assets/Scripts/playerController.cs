﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    // Reference to gameManager class
    public gameManager gameManagerRef;

    // Variables to quickly configure input
    public KeyCode pushUpInput = KeyCode.W;
    public KeyCode pushDownInput = KeyCode.S;
    public KeyCode pushLeftInput = KeyCode.A;
    public KeyCode pushRightInput = KeyCode.D;

    // Variables to adjust force amounts
    public float pushUpForce = 100;
    public float pushDownForce = 100;
    public float pushLeftForce = 100;
    public float pushRightForce = 100;

    // Reference to rigidbody on player
    [HideInInspector]
    public Rigidbody sphereBody;

    // Reference to the mesh renderer component
    [HideInInspector]
    public MeshRenderer playerMesh;

    // Checks if the gameobject is controlled by the player
    private bool isPossessed = true;

    // Checks if the gameobject can move
    [HideInInspector]
    public bool canMove = false;

    // Can be damaged
    private bool damagedEnabled = true;

    // Checks if the player is able to start the game
    [HideInInspector]
    public bool canStartGame = true;

    // Get the name of the level
    public string sceneName;

    // Reference to all cube pickups in the level
    public pickUp[] levelPickups;

    // Store the respawn location for the player
    [HideInInspector]
    public Vector3 respawnLocation;


    private bool justPushedUp = false;

    private bool justPushedDown = false;

    private bool justPushedLeft = false;

    private bool justPushedRight = false;

	// Use this for initialization
	void Start ()
    {

        sphereBody = GetComponent<Rigidbody>();

        playerMesh = GetComponent<MeshRenderer>();

        pushDownForce = pushDownForce * -1;

        pushLeftForce = pushLeftForce * -1;

        // Set the respawn point for the player
        setRespawnPoint();

        setPlayerPhysics(false);

	}
	
	// Update is called once per frame
	void Update ()
    {
        startGame();

        exitGame();
	}

    // Called every frame before physics calculations
    void FixedUpdate()
    {
        pushUp(sphereBody);

        pushDown(sphereBody);

        pushLeft(sphereBody);

        pushRight(sphereBody);
    }

    // When the player collides with an object
    void OnCollisionEnter(Collision collision)
    {
        if (damagedEnabled == true)
        {
            if (collision.gameObject.tag == "Wall")
            {
                print("Hit!");

                // Hide the player
                playerMesh.enabled = false;

                // Disable the player's physics
                setPlayerPhysics(false);

                // Set the active state of the game to false
                gameManagerRef.isGameActive = false;

                // Allow the player to start the game
                canStartGame = true;

                // Wait a few seconds

                // Perform the respawn process
                respawnProcess();
            }
        }
    }


    // Pushes the sphere up
    void pushUp(Rigidbody rb)
    {
        if (isPossessed == true)
        {
            if (canMove == true)
            {

                // If I just pushed down then subtract my push up force by an amount


                // If not then keep the same pushUpForce amount

                if (Input.GetButton("PushUp"))
                {
                    rb.AddForce(new Vector3(0, pushUpForce, 0));
                }
            }
        }
    }

    // Pushes the sphere down
    void pushDown(Rigidbody rb)
    {
        if (isPossessed == true)
        {
            if (canMove == true)
            {

                // If I just pushed up then subtract my push down force by an amount


                if (Input.GetButton("PushDown"))
                {
                    rb.AddForce(new Vector3(0, pushDownForce, 0));
                }
            }
        }
    }

    // Pushes the sphere to the left
    void pushLeft(Rigidbody rb)
    {
        if (isPossessed == true)
        {
            if (canMove == true)
            {
                if (Input.GetButton("PushLeft"))
                {
                    rb.AddForce(new Vector3(pushLeftForce, 0, 0));
                }
            }
        }

    }

    // Pushes the sphere to the right
    void pushRight(Rigidbody rb)
    {
        if (isPossessed == true)
        {
            if (canMove == true)
            {
                if (Input.GetButton("PushRight"))
                {
                    rb.AddForce(new Vector3(pushRightForce, 0, 0));
                }
            }
        }
    }

    // Destroy all pickups in the level
    void destroyPickups()
    {
        for (int i = 0; i < levelPickups.Length; i++)
        {
            levelPickups[i].disablePickups();
        }
    }

    // Set the respawn point for the player
    void setRespawnPoint()
    {
        respawnLocation = transform.position;

        print("The respawn location is " + respawnLocation);
    }

    // Respawning process
    public void respawnProcess()
    {
        // Set the player's new location
        transform.position = respawnLocation;

        // Respawn all cube pickUps
        respawnblocks();

        // Make the player's visibiity active
        playerMesh.enabled = true;

        // Renable the player's gravity
        sphereBody.useGravity = true;

        // Reduce and set the cube pickUp counter
        gameManagerRef.pickUpAmount = 0;
        gameManagerRef.pickUpAmount = levelPickups.Length;
    }



    // Respawn all cube pickUps
    void respawnblocks()
    {
        for (int i = 0; i < levelPickups.Length; i++)
        {
            levelPickups[i].enablePickup();
        }
    }

    // Disable or enable player physics
    public void setPlayerPhysics(bool choice)
    {
        if (choice == true)
        {
            sphereBody.useGravity = true;
            sphereBody.isKinematic = false;
        }
        else if (choice == false)
        {
            sphereBody.useGravity = false;
            sphereBody.isKinematic = true;
        }

    }

    // Allow the player to start the game
    void startGame()
    {
        // Toggle the visibility of the cursor based on if the game is playing in the editor or the standalone player
        if (Application.isEditor == false)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

        // When the user presses space start the game
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canStartGame == true)
            {
                canMove = true;
                setPlayerPhysics(true);
                canStartGame = false;

                print("Game Start!");

                gameManagerRef.isGameActive = true;
            }
        }

    }

    // Allow the player to exit the game
    void exitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Game Exit");
            Application.Quit();
        }
    }
}
