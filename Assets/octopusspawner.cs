using UnityEngine;

public class OctopusSpawner : MonoBehaviour
{
    public GameObject octopus;       // Reference to the prefab
    public float spawnRate = 2f;     // Time between spawns
    private float timer = 0f;        // Timer to control spawning
    public float heightOffset = 5f; // Adjust this to control pipe offset from screen edges

    void Start()
    {
        // Adjust spawnRate based on the platform
#if UNITY_ANDROID
        spawnRate = 2.5f;
#elif UNITY_STANDALONE_WIN
        spawnRate = 2f;
#endif
        SpawnOctopus();
    }

    void Update()
    {
        if (timer > spawnRate)
        {
            SpawnOctopus();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    void SpawnOctopus()
    {
        // Adjusting spawn positions
        float screenHeight = Camera.main.orthographicSize * 2; // Total height of the camera view
        float spawnYMin = transform.position.y - (screenHeight / 2) + heightOffset;
        float spawnYMax = transform.position.y + (screenHeight / 2) - heightOffset;

        // Spawning the octopus within the constrained range
        Instantiate(octopus, 
            new Vector3(transform.position.x, Random.Range(spawnYMin, spawnYMax), 0), 
            transform.rotation);
    }
}
