using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed = 2f;

    void Update()
    {
        // Move the background to the left at the given scroll speed
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }
}
