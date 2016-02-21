using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScreenManager : MonoBehaviour
{
    // Reference to the image component
    [HideInInspector]
    public Image fadeImage;

    // Opacity of the fadeImage
    [HideInInspector]
    public float fadeOpacity = 0;

    // Is the image fading out of black
    [HideInInspector]
    public bool fadingOut = false;

    // Is the image fading in to black
    [HideInInspector]
    public bool fadingIn = true;

	// Use this for initialization
	void Start ()
    {
        // The initial image opacity
        fadeOpacity = 1;

        // Set if the image is fading out to black first
        setFadingOut(true);
        
        // Get the image component
        fadeImage = GetComponent<Image>();

        fadeImage.color = new Color(0, 0, 0, fadeOpacity);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Set fade image opacity
        setImageOpactiy();
	}

    // Set fade image opacity
    public void setImageOpactiy()
    {
        // Set the alpha value of the fadeImage
        fadeImage.color = new Color(0, 0, 0, fadeOpacity);

        // If the image is fading out
        if (fadingOut == true && fadingIn == false)
        {
            fadeOpacity = Mathf.Clamp(fadeOpacity, 0, 1) - 0.01f;
        }

        // If the image is fading in
        if (fadingIn == true && fadingOut == false)
        {
            fadeOpacity = Mathf.Clamp(fadeOpacity, 0, 1) + 0.01f;
        }
    }

    // Set the if the image would fade out or not
    public void setFadingOut(bool choice)
    {
        // If choice is set to true then set fading out to true
        if (choice == true)
        {
            fadingOut = true;
            fadingIn = false;
        }
        // Otherwise set fading out to false and fading in to true
        else if (choice == false)
        {
            fadingOut = false;
            fadingIn = true;
        }

    }

}
