using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenAdjustment : MonoBehaviour
{
    public Text gameOverText;  // Reference to the Text component
    public Button restartButton; // Reference to the Button component
    public Text buttonText;    // Reference to the Text component of the button

    void Start()
    {
        // Platform-specific adjustments
        if (Application.platform == RuntimePlatform.Android)
        {
            AdjustForAndroid();
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            AdjustForWindows();
        }
    }

    private void AdjustForAndroid()
    {
        // Adjust Game Over Text
        gameOverText.rectTransform.sizeDelta = new Vector2(400f, 200f); // Set size for Android
        gameOverText.fontSize = 100; // Set font size for Android

        // Adjust Restart Button
        restartButton.GetComponent<RectTransform>().sizeDelta = new Vector2(640f, 120f); // Set button size for Android
        restartButton.transform.localScale = new Vector3(0.64f, 1f, 1f); // Set scale for Android
        buttonText.fontSize = 60; // Set button text font size for Android
    }

    private void AdjustForWindows()
    {
        // Adjust Game Over Text
        gameOverText.rectTransform.sizeDelta = new Vector2(240f, 120f); // Set size for Windows
        gameOverText.fontSize = 45; // Set font size for Windows

        // Adjust Restart Button
        restartButton.GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 30f); // Set button size for Windows
        restartButton.transform.localScale = new Vector3(0.64f, 1f, 1f); // Set scale for Windows
        buttonText.fontSize = 20; // Set button text font size for Windows
    }
}
