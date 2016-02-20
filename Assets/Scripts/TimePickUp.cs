using UnityEngine;
using System.Collections;

public class TimePickUp : pickUp
{

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
	}
}
