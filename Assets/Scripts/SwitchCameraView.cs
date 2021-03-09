using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraView : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //First person view
        if (Input.GetKeyUp(KeyCode.F)) {
            thirdPersonCamera.depth = 0;
            firstPersonCamera.depth = 1; 
        }

        //Third Person view
        if (Input.GetKeyUp(KeyCode.T))
        {
            thirdPersonCamera.depth = 1;
            firstPersonCamera.depth = 0;
        }
    }
}
