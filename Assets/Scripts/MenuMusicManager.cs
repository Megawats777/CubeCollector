using UnityEngine;
using System.Collections;

public class MenuMusicManager : MusicManager
{

    // Use this for initialization
    void Start()
    {
        // Get the audio source
        soundSource = GetComponent<AudioSource>();
        soundSource.playOnAwake = true;

        // Set a song index number and set the audio clip to be played
        setIndexNum();

        /*
        // Check if a song exists in the selected field
        songCheck();

        // Play a song based on the song index number
        soundSource.Play();
        */

        // Start the playing the set of songs
        InvokeRepeating("playSong", 1.0f, musicClips[indexNum].length + 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
