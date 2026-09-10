using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public GameObject objectPrefab;
    public GameObject particleBurstPrefab;
    public Transform spawnPoint;
    public InputActionProperty spawnButton;

    void Update()
    {
        if (spawnButton.action.WasPressedThisFrame())
        {
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

            Instantiate(particleBurstPrefab, spawnedObject.transform.position, Quaternion.identity);
            spawnedObject.GetComponent<AudioSource>().Play();
        }
    }
}
