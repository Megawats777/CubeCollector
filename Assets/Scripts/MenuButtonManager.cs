using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButtonManager : MonoBehaviour
{

    // Reference to text component
    [HideInInspector]
    public Text buttonText;

    // Color of the text when hovered
    //public Color32 hoverTextColor;

    // Use this for initialization
    void Start()
    {
        // Get the text component
        buttonText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        print("Button Hovered");
        buttonText.color = Color.blue;
    }
}
