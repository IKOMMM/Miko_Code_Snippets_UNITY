//Needs UnityEngine.InputSystem

using UnityEngine;
using UnityEngine.InputSystem;

public class Read2DTouchInputScreenSpace : MonoBehaviour
{
    //Reads Coordinates Over Screen While Touch    
    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            return;
        }

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Debug.Log(touchPosition);
    }
}

public class Read2DTouchInputWorldSpace : MonoBehaviour
{
    //Uses Camera Tag To Read Touch Coordinates In World Space
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            return;
        }

        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(touchPosition);

        Debug.Log(worldPosition);
    }
}