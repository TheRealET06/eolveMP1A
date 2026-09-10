using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public InputActionReference action;
    public Transform roomPosition;
    public Transform externalPosition;

    private bool isOutside = false;

    void Update()
    {
        if (action.action.WasPressedThisFrame())
        {
            if (isOutside)
            {
                transform.position = roomPosition.position;
                isOutside = false;
            }
            else
            {
                transform.position = externalPosition.position;
                isOutside = true;
            }
        }
    }
}
