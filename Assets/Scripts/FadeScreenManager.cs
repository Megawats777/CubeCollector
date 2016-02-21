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
    public float fadeOpacity = 1;

	// Use this for initialization
	void Start ()
    {
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

        // If the opacity of the image is equal or less than one and is greater than 0 then decrease the opacity
        if (fadeOpacity <= 1 && fadeOpacity > 0)
        {
            fadeOpacity = fadeOpacity - 0.01f;
        }

        


    }


}
