using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    // Reference to the audio source component
    private AudioSource soundSource;

    // A list of music
    [SerializeField]
    private AudioClip[] musicClips;

	// Use this for initialization
	void Start ()
    {
        // Get the audio source
        soundSource = GetComponent<AudioSource>();
        soundSource.playOnAwake = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Set the sound to play
}
