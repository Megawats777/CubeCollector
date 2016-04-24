using UnityEngine;
using System.Collections;

public class PlayerHUDCanvasManager : MonoBehaviour {

    // The HUD canvas
    Canvas hudCanvas;

	// Use this for initialization
	void Start ()
    {
        hudCanvas = GetComponent<Canvas>();

        hudCanvas.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
