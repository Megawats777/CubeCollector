using UnityEngine;
using System.Collections;

public class ScalingCube : MonoBehaviour {

    /*---Variables---*/
    private float newScaleX = 0;

    /*---The rate the object will change size---*/
    [Range(0.0f, 1.0f), SerializeField]
    private float scalingRate = 1.0f;

    /*---The Dimensions of the scaled object---*/
    private float smallestXSize = 0;

    private float largestXSize = 0.2f;

    [SerializeField]
    private float scaleLerpValue = 0.0001f;
    private bool isGrowing = true;
    private bool isShrinking = false;


    // Use this for initialization
    void Start ()
    {
        // Set the default x axis scale of the object
        smallestXSize = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set the scale of the object
        setObjectScale();

        //StartCoroutine(changeScaleMode());

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

        // Update the scale lerp value
        newScaleX = Mathf.Lerp(smallestXSize, largestXSize, scaleLerpValue);

        // Set the scale properties of the gameobject
        transform.localScale = new Vector3(newScaleX, transform.localScale.y, transform.localScale.z);

        if (transform.localScale.x == largestXSize)
        {
            isGrowing = false;
            isShrinking = true;

            transform.localScale -= new Vector3(0.01f, 0.0f, 0.0f);
        }
        else if (transform.localScale.x == smallestXSize)
        {
            isGrowing = true;
            isShrinking = false;

            transform.localScale += new Vector3(0.01f, 0.0f, 0.0f);
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
