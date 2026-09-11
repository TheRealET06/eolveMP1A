using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
	
	
	
    public GameObject objectPrefab;
	public GameObject objectPrefab2;
    public GameObject particleBurstPrefab;
    public Transform spawnPoint;
    public InputActionReference action;
	public AudioSource audio;
	public AudioSource audio2;
	

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action.action.Enable();
        
		
		action.action.performed += (ctx) =>
        {
			Debug.Log("spawner spawned");
			GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

            Instantiate(particleBurstPrefab, spawnedObject.transform.position, Quaternion.identity);
            audio.Play();
        };
    }

    void Update()
    {
        /**if (spawnButton.action.WasPressedThisFrame())
        {
            GameObject spawnedObject = Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);

            Instantiate(particleBurstPrefab, spawnedObject.transform.position, Quaternion.identity);
            spawnedObject.GetComponent<AudioSource>().Play();
        }
		
		**/
    }
}
