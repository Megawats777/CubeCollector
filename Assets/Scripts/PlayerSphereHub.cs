using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerSphereHub : PlayerSphereMaster {

	// Use this for initialization
	void Start ()
    {
        // Get rigid body component
        sphereBody = GetComponent<Rigidbody>();

        // Reverse the value of pushForceDown
        pushForceDown = pushForceDown * -1;

        // Reverse the value of pushForceLeft
        pushForceLeft = pushForceLeft * -1;

    }
	
	// Update is called once per frame
	void Update ()
    {
        /*------Push the Sphere------*/
        pushUp(sphereBody);

        pushDown(sphereBody);

        pushRight(sphereBody);

        pushLeft(sphereBody);

        // Exit the hub level
        exitHub();
	}

    // Exit Hub Level
    private void exitHub()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("M_Menu");
            }
        }
    }


}
