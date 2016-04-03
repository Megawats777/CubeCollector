﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{

    // Reference to gameManager class
    [HideInInspector]
    public gameManager gameManagerRef;

    /*
    // Variables to quickly configure input
    public KeyCode pushUpInput = KeyCode.W;
    public KeyCode pushDownInput = KeyCode.S;
    public KeyCode pushLeftInput = KeyCode.A;
    public KeyCode pushRightInput = KeyCode.D;
    */

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

    // Checks if collisions would end the game
    [HideInInspector]
    public bool canCollide = true;

    // Get the name of the level
    [HideInInspector]
    public string sceneName;

    // Reference to all cube pickups in the level
    [HideInInspector]
    public pickUp[] levelPickups;

    // Store the respawn location for the player
    [HideInInspector]
    public Vector3 respawnLocation;

    // Audio source when the player collides with a wall
    private AudioSource collisionAudioSource;

    // Audio clip for player collision
    public AudioClip collisionAudioClip;

    // Reference the fadeImage class
    [HideInInspector]
    public FadeScreenManager fadeImageRef;

    int pickupAmount;

    /*
    private bool justPushedUp = false;

    private bool justPushedDown = false;

    private bool justPushedLeft = false;

    private bool justPushedRight = false;
    */

	// Use this for initialization
	void Start ()
    {

        sphereBody = GetComponent<Rigidbody>();

        playerMesh = GetComponent<MeshRenderer>();

        collisionAudioSource = GetComponent<AudioSource>();

        // Get the fade image class
        fadeImageRef = FindObjectOfType<FadeScreenManager>();

        pushDownForce = pushDownForce * -1;

        pushLeftForce = pushLeftForce * -1;

        // Hide the player's mouse cursor
        if (Application.isEditor)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }

        // Set the respawn point for the player
        setRespawnPoint();

        // Reference all level pickups
        getPickups();

        // Reference the gameManager
        getGameManager();

        // Disable the player's physics properties
        setPlayerPhysics(false);
        sphereBody.useGravity = false;

        // Set collision audio
        setCollisionClip();
	}
	
	// Update is called once per frame
	void Update ()
    {
        startGame();

        exitGame();

        // If the game clock reaches zero then set canCollide to false
        if (gameManagerRef.clockLength < 1)
        {
            canCollide = false;
        }

        /*--DEBUG QUIT COMMAND--*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
	}

    // Called every frame before physics calculations
    void FixedUpdate()
    {
        // Push the sphere up
        pushUp(sphereBody);

        // Push the sphere down
        pushDown(sphereBody);

        // Push the sphere left
        pushLeft(sphereBody);

        // Push the sphere right
        pushRight(sphereBody);
    }

    // When the player collides with an object
    void OnCollisionEnter(Collision collision)
    {
        if (damagedEnabled == true)
        {
            if (collision.gameObject.tag == "Wall")
            {
                if (canCollide == true)
                {
                    print("Hit!");

                    // Play collision audio
                    playCollisionAudio();

                    // Hide the player
                    playerMesh.enabled = false;

                    // Disable the player's physics
                    setPlayerPhysics(false);

                    // Set the active state of the game to false
                    gameManagerRef.isGameActive = false;

                    // Allow the player to start the game
                    canStartGame = true;

                    // Reset the game clock
                    gameManagerRef.resetClock();

                    // Wait a few seconds

                    // Perform the respawn process
                    respawnProcess();
                }
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
                if (Input.GetButton("Push Up"))
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
                if (Input.GetButton("Push Down"))
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
                if (Input.GetButton("Push Left"))
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
                if (Input.GetButton("Push Right"))
                {
                    rb.AddForce(new Vector3(pushRightForce, 0, 0));
                }
            }
        }
    }

    // Reference all the gameManagers in the level
    private void getGameManager()
    {
        gameManagerRef = FindObjectOfType<gameManager>();

        if (gameManagerRef)
        {
            print("Gamemanager refrenced");
        }
        else
        {
            print("Gamemanager reference failed");
        }
    }

    // Reference the cubePickups in the level
    private void getPickups()
    {
        levelPickups = FindObjectsOfType<pickUp>();

        foreach (pickUp cubePickups in levelPickups)
        {
            pickupAmount = pickupAmount + 1;
        }

        print(pickupAmount + " cubes referenced");
    }

    // Set collision audio
    private void setCollisionClip()
    {
        collisionAudioSource.clip = collisionAudioClip;
    }

    // Play collision audio
    private void playCollisionAudio()
    {
        collisionAudioSource.Play();
    }


    // Destroy all pickups in the level
    void destroyPickups()
    {
        for (int i = 0; i < levelPickups.Length; i++)
        {
            levelPickups[i].disablePickup();
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
        sphereBody.useGravity = false;

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
        // If the choice was true set physics enabled to true
        if (choice == true)
        {
            sphereBody.useGravity = true;
            sphereBody.isKinematic = false;
        }
        // If the choice was true set physics enabled to false
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
                gameManagerRef.isClockActive = true;

                // Add one second to the clock when the gamestarts
                gameManagerRef.clockLength++;
            }
        }

    }

    // Allow the player to exit the current level
    void exitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            print("Game Exit");

            // Load the main menu
            SceneManager.LoadScene("M_Menu");

            // Renable the mouse cursor
            Cursor.visible = true;
        }
    }
}
