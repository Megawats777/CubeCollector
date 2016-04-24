using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    // Reference to the audio source component
    [HideInInspector]
    public AudioSource soundSource;

    // A list of music
    [SerializeField]
    protected AudioClip[] musicClips;

    // A number to decide which song to play
    protected int indexNum = 0;

    // Use this for initialization
    void Start()
    {
        // Get the audio source
        soundSource = GetComponent<AudioSource>();
        soundSource.playOnAwake = true;

        // Set a song index number and set the audio clip to be played
        setIndexNum();

        // Check if a song exists in the selected field
        songCheck();

        // Play a song based on the song index number
        soundSource.Play();

        // Start the playing the set of songs
        InvokeRepeating("playSong", 0.0f, musicClips[indexNum].length + 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Set a song index number and set the audio clip to be played
    protected void setIndexNum()
    {
        indexNum = Random.Range(0, musicClips.Length);
        soundSource.clip = musicClips[indexNum];
    }

    // Play a song based on the song index number
    protected void playSong()
    {
        print("Music Changing");

        // Set a song index number and set the audio clip to be played
        setIndexNum();

        // Check if a song exists in the selected field
        songCheck();
    }

    // Check if a song exists in the selected field
    protected void songCheck()
    {
        if (musicClips[indexNum])
        {
            // Play the song
            soundSource.Play();
        }
        else
        {
            print("No song selected in this field");
        }
    }

}
