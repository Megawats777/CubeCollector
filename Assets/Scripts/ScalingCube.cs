using UnityEngine;
using System.Collections;

public class ScalingCube : MonoBehaviour {

    /*---Variables---*/
    private float newScaleX = 0;
    private float newScaleY = 0;
    private float newScaleZ = 0;
    
    // Is the user scaling the object in a paticular direction


    private float scaleLerpValue = 0;
    private bool isGrowing = true;



    // Use this for initialization
    void Start ()
    {
	
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
        transform.localScale += new Vector3(.1f, .1f, .1f); 


    }


}
