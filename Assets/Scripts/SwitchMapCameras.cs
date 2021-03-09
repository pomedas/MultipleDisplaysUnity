using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMapCameras : MonoBehaviour
{
    //The camera objects, must be assigned from the inspector
    public Camera cameraField;
    public Camera cameraMap;

    //The Rect objects of the cameras that we are going to use to switch values
    Rect rectCameraMap;
    Rect rectCameraField;

    // Initializes the Rect values for the field and map cameras
    void Start()
    {
        //The rect values for filed view
        rectCameraField.x = 0;
        rectCameraField.y = 0;
        rectCameraField.width = 1;
        rectCameraField.height = 1;

        //The rect values for the top view
        rectCameraMap.x = 0.66f;
        rectCameraMap.y = 0.66f;
        rectCameraMap.width = 0.3f;
        rectCameraMap.height = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        //Switch the camera values using keys
        //asisgns the react values and change the depth camera to set the render priority

        //Set the top camera full screen
        if (Input.GetKeyUp(KeyCode.T)) {
            cameraField.rect = rectCameraMap;
            cameraField.depth = 1;

            cameraMap.rect = rectCameraField;
            cameraMap.depth = 0; 
        }

        //Set the field view full screen
        if (Input.GetKeyUp(KeyCode.F))
        {
            cameraField.rect = rectCameraField;
            cameraField.depth = 0;

            cameraMap.rect = rectCameraMap;
            cameraMap.depth = 1;
        }
    }
}
