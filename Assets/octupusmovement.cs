using UnityEngine;

public class octupusmovement : MonoBehaviour
{
    public float speed = 1.5f; // Default speed for Windows
    public float dead = -6f;   // X-coordinate threshold for destruction

    void Start()
    {
        // Platform-specific adjustments
#if UNITY_ANDROID
        speed = 0.8f;
        AdjustScale(new Vector3(0.5532f, 1f, 1f));
        AdjusttopAndbottomPositions(2.72f, -2.42f);
#elif UNITY_STANDALONE_WIN
        speed = 1.5f;
        AdjustScale(new Vector3(0.8f, 1f, 1f));
        AdjusttopAndbottomPositions(2.87f, -2.57f);
#endif
    }

    void Update()
    {
        // Move the octopus left
        transform.position += (Vector3.left * speed) * Time.deltaTime;

        // Destroy the octopus if it moves out of bounds
        if (transform.position.x < dead)
        {
            Debug.Log("Octopus Hand Got Destroyed");
            Destroy(gameObject);
        }
    }

    private void AdjustScale(Vector3 scale)
    {
        // Adjust the scale of the entire prefab
        transform.localScale = scale;
    }

    private void AdjusttopAndbottomPositions(float topY, float bottomY)
    {
        // Find top and bottom child objects and adjust their Y positions individually
        Transform top = transform.Find("top");
        Transform bottom = transform.Find("bottom");

        if (top != null)
        {
            top.localPosition = new Vector3(top.localPosition.x, topY, top.localPosition.z);
        }
        else
        {
            Debug.LogWarning("top child object not found.");
        }

        if (bottom != null)
        {
            bottom.localPosition = new Vector3(bottom.localPosition.x, bottomY, bottom.localPosition.z);
        }
        else
        {
            Debug.LogWarning("bottom child object not found.");
        }
    }
}
