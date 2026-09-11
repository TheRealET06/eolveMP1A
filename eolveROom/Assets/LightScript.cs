using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Light light;
    public InputActionReference action;

    Color lightcolor;
    void Start()
    {
        light = GetComponent<Light>();
		action.action.Enable();
        lightcolor = new Color(1, (float).55, (float).12);
		
		action.action.performed += (ctx) =>
        {
            light.color = lightcolor;
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(action.action.WasPressedThisFrame())
        {
            light.color = lightcolor;
        }
    }
}
