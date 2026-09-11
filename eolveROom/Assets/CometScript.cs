using UnityEngine;

public class CometScript : MonoBehaviour
{
    public Vector3 velocity;

    const float gravity = 0.2f;

    public Transform planet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = transform.position - planet.position;

        float distance = offset.magnitude;

        float ax = -gravity * offset.x / Mathf.Pow(distance, 3);
        float ay = -gravity * offset.y / Mathf.Pow(distance, 3);
        float az = -gravity * offset.z / Mathf.Pow(distance, 3);

        velocity.x = velocity.x + ax * Time.deltaTime;
        velocity.y = velocity.y + ay * Time.deltaTime;
        velocity.z = velocity.z + az * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }
}
