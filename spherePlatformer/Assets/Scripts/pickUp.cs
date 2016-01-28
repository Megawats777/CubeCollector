using UnityEngine;
using System.Collections;

public class pickUp : MonoBehaviour {

    // The rotation rate for the gameObject
    public float rotationRate = 20;

    // The score gained from this object
    public int scoreValue = 10;

    // Reference mesh render component
    private  MeshRenderer objectMesh;

    // Reference mesh collider component
    private BoxCollider colliderBox;

    // Reference the gameManager class
    public gameManager gameManagerRef;

	// Use this for initialization
	void Start () {

        objectMesh = GetComponent<MeshRenderer>();
        colliderBox = GetComponent<BoxCollider>();

        gameManagerRef.playerScore = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        rotateObject();
	}

    // Rotates the gameobject
    void rotateObject()
    {
        transform.Rotate(new Vector3(0, rotationRate, rotationRate)* Time.deltaTime);
    }

    // When the trigger is overlaped
    void OnTriggerEnter(Collider other)
    {
        disablePickups();
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
    public void disablePickups()
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
