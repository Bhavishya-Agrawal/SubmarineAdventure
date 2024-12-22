using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed = 2f;         // Speed of background movement
    public float destroyPositionX = -17.28f; // X position to destroy off-screen backgrounds

    void Update()
    {
        // Move the background to the left
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Destroy the background when it moves out of frame
        if (transform.position.x <= destroyPositionX)
        {
            Destroy(gameObject);
        }
    }
}
