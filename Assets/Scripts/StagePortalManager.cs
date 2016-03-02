using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StagePortalManager : MonoBehaviour {

    // Reference to the box trigger component
    [HideInInspector]
    public BoxCollider portalTrigger;

    // Destination of the portal
    public string levelDestination;

    // Can the player open a new level
    private bool canChangeLevel = false;

	// Use this for initialization
	void Start ()
    {
        // Get the box trigger
        portalTrigger = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Open a level
        openLevel(levelDestination);
	}

    // When the trigger is entered by the player
    void OnTriggerEnter(Collider other)
    {
        canChangeLevel = true;
    }


    // When the trigger is no longer overlaped by the player
    void OnTriggerExit(Collider other)
    {
        canChangeLevel = false;
    }

    // Open a level
    private void openLevel(string name)
    {
        if (canChangeLevel == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(name);
            }
        }
    }

}
