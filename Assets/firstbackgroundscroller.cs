using UnityEngine;

public class FirstBackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 2f;  // Speed at which the background scrolls

    void Start()
    {
        // Log the name of this GameObject to confirm it's being properly accessed
        Debug.Log("First Background Assigned: " + gameObject.name);
    }

    void Update()
    {
        // Move the current GameObject (the one with this script attached) to the left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }
}
