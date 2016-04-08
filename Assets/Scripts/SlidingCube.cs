using UnityEngine;
using System.Collections;

public class SlidingCube : MonoBehaviour
{
    /*---Variables---*/

    /*
    // Determine if the object can move in a paticular axis
    [SerializeField]
    private bool canMoveInX = true;

    [SerializeField]
    private bool canMoveInY = false;
    */

    // Set which direction is the object moving in
    private bool isMovingToNavPoint = true;
    private bool isMovingToOrigin = false;

    // The rate at which the object is moving
    [SerializeField, Range(0.0f, 3.0f)]
    private float movementSpeed = 0.5f;

    // The lerp value of the location
    [SerializeField, Range(0.0f, 1.0f)]
    private float positionLerpValue = 0.0001f;

    // The new locations of the object per axis
    private float newLocationX = 0.0f;
    private float newLocationY = 0.0f;
    private float newLocationZ = 0.0f;

    // Reference to the navPoint
    SlidingCubeMovePoint navPointRef;

    // Reference to the location of the navPoint
    [SerializeField]
    private Vector3 navPointLocation = new Vector3(0, 0, 0);

    // The origin location
    private Vector3 originLocation;

	// Use this for initialization
	void Start ()
    {
        // Get the SlidingCubeMovePoint
        navPointRef = GetComponentInChildren<SlidingCubeMovePoint>();

        // Set the origin location
        originLocation = transform.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        // Get the location of the nav point
        navPointLocation = navPointRef.navPointLocation;

        // Perform the object's movement
        objectMovement();
    }

    // Perform the object's movement
    private void objectMovement()
    {
        // Set the position lerp value
        setPositionLerpValue();

        // Set the object's location
        setObjectLocation();

        // Set the object's moving direction
        setMovementDirection();
    }

    // Set the position lerp value
    private void setPositionLerpValue()
    {
        // If the object is moving to the nav point increase the lerp value
        if (isMovingToNavPoint == true && isMovingToOrigin == false)
        {
            Mathf.Clamp(positionLerpValue += 0.01f * movementSpeed, 0.0f, 1.0f);
        }

        // If the object is moving to the origin point decrease the lerp value
        else if (isMovingToNavPoint == false && isMovingToOrigin == true)
        {
            Mathf.Clamp(positionLerpValue -= 0.01f * movementSpeed, 0.0f, 1.0f);
        }
    }

    // Set the object's location
    private void setObjectLocation()
    {
        // Blend the object's location in the X axis
        newLocationX = Mathf.Lerp(originLocation.x, navPointLocation.x, positionLerpValue);

        // Blend the object's location in the Y axis
        newLocationY = Mathf.Lerp(originLocation.y, navPointLocation.y, positionLerpValue);

        // Blend the object's location in the Z axis
        newLocationZ = Mathf.Lerp(originLocation.z, navPointLocation.z, positionLerpValue);

        // Set the new object location
        transform.position = new Vector3(newLocationX, newLocationY, newLocationZ);
    }

    // Set the object's moving direction
    private void setMovementDirection()
    {
        // If the location of the object is equal to the location of the nav point move back to the origin point
        if (transform.position == navPointLocation)
        {
            isMovingToNavPoint = false;
            isMovingToOrigin = true;

            // Decrease the lerp value a little bit
            positionLerpValue -= 0.00001f;
        }
        
        // If the location of the object is equal to the location of the origin point move to the nav point 
        else if (transform.position == originLocation)
        {
            isMovingToNavPoint = true;
            isMovingToOrigin = false;

            // Increase the lerp value a little bit
            positionLerpValue += 0.00001f;
        }
    }

    

}
