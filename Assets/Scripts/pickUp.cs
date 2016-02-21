using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour
{

    // The rotation rate for the gameObject
    public float rotationRate = 20;

    // The score gained from this object
    [HideInInspector]
    public int scoreValue = 10;

    // Reference mesh render component
    [HideInInspector]
    public MeshRenderer objectMesh;

    // Reference mesh collider component
    [HideInInspector]
    public BoxCollider colliderBox;

    // Reference to the audio source component
    [HideInInspector]
    public AudioSource collisionSoundSource;

    // Reference the gameManager class
    [HideInInspector]
    public gameManager gameManagerRef;

    // Sound that plays when the pickUp is collected
    public AudioClip collectedSound;

    // Sound played when the pickUp is the last in the level and is collected
    public AudioClip finalCollectedSound;

    // Use this for initialization
    void Start()
    {

        objectMesh = GetComponent<MeshRenderer>();
        colliderBox = GetComponent<BoxCollider>();
        collisionSoundSource = GetComponent<AudioSource>();

        // Reference the gameManager
        getGameManager();

        gameManagerRef.playerScore = 0;

    }

    // Update is called once per frame
    void Update()
    {
        rotateObject();
    }

    // Rotates the gameobject
    public void rotateObject()
    {
        transform.Rotate(new Vector3(0, rotationRate, rotationRate) * Time.deltaTime);
    }

    // Reference gameManager
    void getGameManager()
    {
        gameManagerRef = FindObjectOfType<gameManager>();
    }

    // Set pickup collision sound
    public void setCollisionSound()
    {
        if (gameManagerRef.pickUpAmount > 1)
        {
            collisionSoundSource.clip = collectedSound;
        }
        else if (gameManagerRef.pickUpAmount == 1)
        {
            collisionSoundSource.clip = finalCollectedSound;
        }
    }

    // Play collision sound
    public void playCollisionSound()
    {
        // Set pickup collision sound
        setCollisionSound();

        // Play the collision sound
        collisionSoundSource.Play();
    }


    // When the trigger is overlaped
    void OnTriggerEnter(Collider other)
    {
        // Play the collision sound
        playCollisionSound();

        // Disable the pickup
        disablePickup();
    }

    // Renables pickups
    public void enablePickup()
    {
        if (gameManagerRef != null)
        {
            // Enable the box collider component
            colliderBox.enabled = true;

            // Enable the mesh renderer component
            objectMesh.enabled = true;

            // Enable the entire gameobject
            enabled = true;

            // Increase cube pickup count
            gameManagerRef.increasePickups();
        }
    }

    // Disables pickups
    public void disablePickup()
    {
        if (gameManagerRef != null)
        {
            print("Score!");

            // Disable the box collider component
            colliderBox.enabled = false;

            // Disable the mesh renderer component
            objectMesh.enabled = false;

            // Disable the entire gameobject
            enabled = false;

            // Add to the player's score
            gameManagerRef.addToScore(scoreValue);

            // Reduce the pickUp amount
            gameManagerRef.reducePickups();
        }
    }
}
