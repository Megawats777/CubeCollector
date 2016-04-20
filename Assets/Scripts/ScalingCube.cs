using UnityEngine;
using System.Collections;

public class ScalingCube : MonoBehaviour
{

    /*---Variables---*/
    private float newScaleX = 0;
    private float newScaleY = 0;

    /*---Determine if the object can scale in a paticular axis---*/
    [SerializeField]
    private bool canScaleInXAxis = true;

    [SerializeField]
    private bool canScaleInYAxis = false;

    /*---The rate the object will change size---*/
    [Range(0.0f, 5.0f), SerializeField]
    private float scalingRate = 1.0f;

    /*---The Dimensions of the scaled object---*/
    private float smallestXSize = 0;
    private float smallestYSize = 1;

    [Range(0.0f, 30.0f), SerializeField]
    private float largestXSize = 0.2f;

    [Range(0.0f, 30.0f), SerializeField]
    private float largestYSize = 0.2f;


    [SerializeField]
    private float scaleLerpValue = 0.0001f;
    private bool isGrowing = true;
    private bool isShrinking = false;


    // Use this for initialization
    void Start ()
    {
        // Set the default x axis scale of the object
        smallestXSize = transform.localScale.x;

        // Set the default y axis of the object
        smallestYSize = transform.localScale.y;
    }
	
	// Update is called once per frame
	void Update ()
        {
        	// Set the scale of the object
        	setObjectScale();

	}

    // Set the scale of the object
    void setObjectScale()
    {
        // If the object is growing increase the scale lerp value
        if (isGrowing == true && isShrinking == false)
        {
            scaleLerpValue = Mathf.Clamp(scaleLerpValue + 0.01f * scalingRate, 0, 1);
        }

        // If the object is shrinking decrease the scale lerp value
        if (isShrinking == true && isGrowing == false)
        {
            scaleLerpValue = Mathf.Clamp(scaleLerpValue - 0.01f * scalingRate, 0, 1);
        }

        if (canScaleInXAxis == true)
        {
            // Update the scale lerp value for the X axis
            newScaleX = Mathf.Lerp(smallestXSize, largestXSize, scaleLerpValue);
        }

        if (canScaleInYAxis == true)
        {
            // Update the scale lerp value for the Y axis
            newScaleY = Mathf.Lerp(smallestYSize, largestYSize, scaleLerpValue);
        }

        /*---Set the scale of the object---*/
        
        // If you can scale both the X and Y axis of the object
        if (canScaleInXAxis == true && canScaleInYAxis == true)
        {
            transform.localScale = new Vector3(newScaleX, newScaleY, transform.localScale.z);
	}
	
	// If you can only scale the X axis of the object only scale the X axis in game
	else if (canScaleInXAxis == true && canScaleInYAxis == false)
	{
	    transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);		
	}
	
	// If you can only scale the Y axis of the object only scale the Y axis in game
	else if (canScaleInYAxis == true && canScaleInXAxis == false)
	{
	    transform.localScale = new Vector3(transform.localScale.x, newScaleY, transform.localScale.z);
	}
	
        // Change scaling mode for the X axis of the object
        changeXAxisScaleMode();

        // Change scaling mode for the Y axis of the object
        changeYAxisScaleMode();

    }

    // Change scaling mode for the X axis of the object
    private void changeXAxisScaleMode()
    {
        // If the x axis of the object reaches its limits change the scaling mode
        if (transform.localScale.x == largestXSize)
        {
            isGrowing = false;
            isShrinking = true;

            transform.localScale -= new Vector3(0.000001f, 0.0f, 0.0f);
        }
        else if (transform.localScale.x == smallestXSize)
        {
            isGrowing = true;
            isShrinking = false;

            transform.localScale += new Vector3(0.000001f, 0.0f, 0.0f);
        }
    }

    // Change scaling mode for the Y axis of the object
    private void changeYAxisScaleMode()
    {
        // If the y axis of the object reaches its limits change the scaling mode
        if (transform.localScale.y == largestYSize)
        {
            isGrowing = false;
            isShrinking = true;

            transform.localScale -= new Vector3(0.0f, 0.01f, 0.0f);
        }
        else if (transform.localScale.y == smallestYSize)
        {
            isGrowing = true;
            isShrinking = false;

            transform.localScale += new Vector3(0.0f, 0.01f, 0.0f);
        }
    }



    // Change the scaling mode
    IEnumerator changeScaleMode()
    {
        print("Scale mode changing");

        yield return new WaitForSeconds(1.0f);

        // If the object is growing set it's scaling mode to shrinking
        if (isGrowing == true && isShrinking == false)
        {
            isGrowing = false;
            isShrinking = true;

            

        }

        // If the object is shrinking set it's scaling mode to growing
        if (isShrinking == true && isGrowing == false)
        {
            isShrinking = false;
            isGrowing = true;
            print("Object is growing");

            
        }

    }

}
