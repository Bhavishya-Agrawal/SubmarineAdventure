using UnityEngine;
using UnityEngine.UI;

public class PlatformSpecificCanvasScaler : MonoBehaviour
{
    public CanvasScaler canvasScaler; // Reference to the CanvasScaler component
    public Text gameOverText;  // Reference to the Game Over text component
    public Button retryButton;  // Reference to the retry button
    public Text buttonText;  // Reference to the retry button text

    void Start()
    {
        // Adjust CanvasScaler based on the platform
        if (Application.platform == RuntimePlatform.Android)
        {
            // Set CanvasScaler to Scale With Screen Size for Android
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080); // Set reference resolution for Android

            // Adjust the font size and scale for Android
            gameOverText.fontSize = 100;  // Set font size for Android
            retryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 60);  // Set button size
            retryButton.transform.localScale = new Vector3(0.64f, 1f, 1f);  // Set button scale
            buttonText.fontSize = 30;  // Set button text font size
        }
        else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            // Set CanvasScaler to Constant Pixel Size for Windows
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;

            // Adjust the font size and scale for Windows
            gameOverText.fontSize = 50;  // Set font size for Windows
            retryButton.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);  // Set button size
            retryButton.transform.localScale = new Vector3(0.64f, 1f, 1f);  // Set button scale
            buttonText.fontSize = 20;  // Set button text font size
        }
    }
}
