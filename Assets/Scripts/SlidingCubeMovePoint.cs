using UnityEngine;
using System.Collections;

public class SlidingCubeMovePoint : MonoBehaviour
{
    /*----Variables----*/

    // Reference to the mesh renderer
    MeshRenderer navPointMesh;

    // The location of the navPoint
    [HideInInspector]
    public Vector3 navPointLocation = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start ()
    {
        // Get the navPointMesh mesh renderer
        navPointMesh = GetComponent<MeshRenderer>();

        // Disable the navPointMesh mesh renderer
        navPointMesh.enabled = false;

        // Set the value of the nav point location
        navPointLocation = transform.position;

        print("The location of the nav point is " + navPointLocation.ToString());
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }
}
