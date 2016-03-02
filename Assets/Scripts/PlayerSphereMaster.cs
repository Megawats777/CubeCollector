using UnityEngine;
using System.Collections;

public class PlayerSphereMaster : MonoBehaviour
{
    // Reference to the rigid body component
    [HideInInspector]
    public Rigidbody sphereBody;

    // SphereBody force values
    public float pushForceUp = 75;
    public float pushForceDown = 75;
    public float pushForceRight = 50;
    public float pushForceLeft = 50;

    // Can the sphere move
    [HideInInspector]
    public bool canMove = true;

	// Use this for initialization
	void Start ()
    {
        // Reverse the value of pushForceDown
        pushForceDown = pushForceDown * -1;

        // Reverse the value of pushForceLeft
        pushForceLeft = pushForceLeft * -1;

        // Get the Rigid body component
        sphereBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*------Push the sphere------*/
        pushUp(sphereBody);

        pushDown(sphereBody);

        pushRight(sphereBody);

        pushLeft(sphereBody);

	}

    // Push the sphere up
    public void pushUp(Rigidbody rb)
    {
        if (canMove == true)
        {
            if (Input.GetButton("PushUp"))
            {
                rb.AddForce(new Vector3(0, pushForceUp, 0));
            }
        }
    }


    // Push the sphere down
    public void pushDown(Rigidbody rb)
    {
        if (canMove == true)
        {
            if (Input.GetButton("PushDown"))
            {
                rb.AddForce(new Vector3(0, pushForceDown, 0));
            }
        }
    }


    // Push the sphere right
    public void pushRight(Rigidbody rb)
    {
        if (canMove == true)
        {
            if (Input.GetButton("PushRight"))
            {
                rb.AddForce(new Vector3(pushForceRight, 0, 0));
            }
        }
    }

    // Push the sphere left
    public void pushLeft(Rigidbody rb)
    {
        if (canMove == true)
        {
            if (Input.GetButton("PushLeft"))
            {
                rb.AddForce(new Vector3(pushForceLeft, 0, 0));
            }
        }
    }



}
