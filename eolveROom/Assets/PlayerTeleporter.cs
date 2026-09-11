using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleporter : MonoBehaviour
{
	
	
	// Update is called once per frame
    public InputActionReference action;
    public Transform roomPosition;
    public Transform externalPosition;
	private bool isOutside = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		
		action.action.Enable();
        
		
		action.action.performed += (ctx) =>
        {
			Debug.Log("teleporting");

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
			Debug.Log(isOutside);
        };
		
        
    }

    

    

    void Update()
    {
		
		
		/**
		
		action.action.Enable();
        
		
		action.action.performed += (ctx) =>
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
        };
		
		
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
		**/
    }
}
