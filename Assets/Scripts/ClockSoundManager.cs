using UnityEngine;
using System.Collections;

public class ClockSoundManager : MonoBehaviour
{
    // Reference to the game manager
    gameManager gameManagerRef;

    // Reference to the audio source component
    [HideInInspector]
    public AudioSource soundSource;

    // Clip to for the sound object to play
    [SerializeField]
    private AudioClip clockSound;

	// Use this for initialization
	void Start ()
    {
        // Get the game manager
        gameManagerRef = GetComponentInParent<gameManager>();

        // Get the audio source component
        soundSource = GetComponent<AudioSource>();

        soundSource.clip = clockSound;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    // If the clock is less than zero play the sound
        if (gameManagerRef.clockLength < 1)
        {
            soundSource.Play();
        }
	}
}
