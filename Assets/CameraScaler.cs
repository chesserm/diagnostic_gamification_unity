using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScaler : MonoBehaviour
{
    // Reference resolutions
    private int referenceWidth = 720;
    private int referenceHeight = 1080;

    // This is the default camera size that fits the 
    // 720 x 1080 reference screen
    // https://docs.unity3d.com/ScriptReference/Camera-orthographicSize.html
    private float referenceCameraSize = 540;


    // Function that actually does the Scaling of the Camera
    private void ScaleCameraWithScreen()
    {
        // Get camera game object and component
        GameObject mainCamera = GameObject.Find("Main Camera");
        Camera cameraComponent = mainCamera.GetComponent<Camera>();

        // Calculate new camera size
        // https://docs.unity3d.com/ScriptReference/Camera-orthographicSize.html
        float newScreenHeight = 0.5f * (float)Screen.height;
        
        // Set the camera to be the new size
        cameraComponent.orthographicSize = newScreenHeight;
        
        return;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ScaleCameraWithScreen();
    }

    // Update is called once per frame
    void Update()
    {
        ScaleCameraWithScreen();
    }
}
