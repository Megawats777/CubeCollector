using UnityEngine;
using System.Collections;

public class TimePickUp : pickUp
{
    // Time extension amount
    [Range (5, 50)]
    public int timeExtensionAmount = 10;


	// Use this for initialization
	void Start ()
    {
        // Get the gameManager
        gameManagerRef = FindObjectOfType<gameManager>();

        // Get audioSource component
        collisionSoundSource = GetComponent<AudioSource>();

        // Get collision box component
        colliderBox = GetComponent<BoxCollider>();

        // Get mesh renderer component
        objectMesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Rotate the sphere
        rotateObject();

        // Set the audio clip for the audio source
        setCollisionSound();
	}

    // When the object is overlaped
    void OnTriggerEnter(Collider other)
    {
        // Increase clock amount
        gameManagerRef.increaseClock(timeExtensionAmount);

        // Play collision sound
        playCollisionSound();

        // Disable the pickup
        disablePickup();
    }
}
