using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject backgroundPrefab;  // Prefab for all backgrounds
    public GameObject firstBackground;   // Reference to the first background
    public float scrollSpeed = 2f;       // Speed of scrolling
    private float backgroundWidth;       // Width of a single background

    private GameObject lastBackground;   // The last instantiated background

    void Start()
    {
        // Set platform-specific scroll speeds
        #if UNITY_ANDROID
            scrollSpeed = 0.25f;
        #elif UNITY_STANDALONE_WIN
            scrollSpeed = 0.5f;
        #endif

        // Ensure firstBackground is assigned
        if (firstBackground == null)
        {
            Debug.LogError("First Background is not assigned in the inspector!");
            return;
        }

        // Get the width of the background using the SpriteRenderer bounds
        backgroundWidth = firstBackground.GetComponent<SpriteRenderer>().bounds.size.x;

        // Add scrolling behavior to the first background
        firstBackground.AddComponent<BackgroundLooper>().scrollSpeed = scrollSpeed;

        // Initialize the last background as the first background
        lastBackground = firstBackground;

        // Spawn the second background immediately behind the first one
        SpawnBackground(firstBackground.transform.position.x + backgroundWidth);
    }

    void Update()
    {
        // Check if the last background has reached x = 0.02
        if (lastBackground.transform.position.x <= 0.02f)
        {
            // Spawn the next background immediately behind the last one
            SpawnBackground(lastBackground.transform.position.x + backgroundWidth - 0.02f);
        }

        // Destroy off-screen backgrounds (when they move beyond the left edge)
        if (lastBackground.transform.position.x <= -backgroundWidth)
        {
            Destroy(lastBackground);
        }
    }

    void SpawnBackground(float spawnXPosition)
    {
        // Spawn a new background at the given position
        Vector3 spawnPosition = new Vector3(spawnXPosition, lastBackground.transform.position.y, lastBackground.transform.position.z);
        GameObject newBackground = Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);

        // Add scrolling behavior to the new background
        newBackground.AddComponent<BackgroundLooper>().scrollSpeed = scrollSpeed;

        // Update the reference for the last background
        lastBackground = newBackground;
    }
}
