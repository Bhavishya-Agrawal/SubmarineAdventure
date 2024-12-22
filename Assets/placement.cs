using UnityEngine;
using UnityEngine.UI;

public class Placement : MonoBehaviour
{
    public float padding = 10f; // Padding from the edges

    void Start()
    {
        // Get the RectTransform component of the Text object this script is attached to
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (rectTransform == null)
        {
            Debug.LogError("This GameObject does not have a RectTransform component!");
            return;
        }

        // Ensure the text is in the top-left corner
        rectTransform.anchorMin = new Vector2(0, 1); // Top-left corner
        rectTransform.anchorMax = new Vector2(0, 1); // Top-left corner
        rectTransform.pivot = new Vector2(0, 1); // Anchor point at top-left

        // Apply padding
        rectTransform.anchoredPosition = new Vector2(padding, -padding);

        // Adjust font size based on platform
        Text textComponent = GetComponent<Text>(); // Get the Text component attached to this GameObject

        if (textComponent != null)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                textComponent.fontSize = 2000; // Font size for Android
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                textComponent.fontSize = 50; // Font size for Windows
            }
        }
        else
        {
            Debug.LogError("Text component is not attached to the GameObject!");
        }
    }

    void Update()
    {
        // Optionally, update the position in case screen size changes (responsive)
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(padding, -padding);
        }
    }
}
