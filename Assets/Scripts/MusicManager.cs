using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    // Reference to the audio source component
    [HideInInspector]
    public AudioSource soundSource;

    // A list of music
    [SerializeField]
    private AudioClip[] musicClips;

    int indexNum = 0;

    // Use this for initialization
    void Start ()
    {
        // Get the audio source
        soundSource = GetComponent<AudioSource>();
        soundSource.playOnAwake = true;

        setMusicClip();

        InvokeRepeating("setMusicClip", musicClips[indexNum].length + 0.5f, 1.0f);
        print(indexNum);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    // Set the sound to play
    private void setMusicClip()
    {
        soundSource.clip = musicClips[getNewNum()];
        soundSource.Play();
    }

    // Generate a random number to select a song
    private int getNewNum()
    {
        indexNum = Random.Range(0, 1);

        return indexNum;
    }

}
