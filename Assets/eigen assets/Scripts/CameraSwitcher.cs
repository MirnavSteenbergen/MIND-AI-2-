using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera testingCamera;
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        testingCamera.enabled = false;
        mainCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            testingCamera.enabled = !testingCamera.enabled;
            mainCamera.enabled = !mainCamera.enabled;
        }
    }
}
