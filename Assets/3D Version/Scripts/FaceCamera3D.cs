using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera3D : MonoBehaviour
{
    private GameObject mainCam;
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        //Find the main camera
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //If the camera is stationary, then we need not update the localRotation
        if(transform.localRotation != mainCam.transform.rotation)
        {
            transform.localEulerAngles = new Vector3(50f, mainCam.transform.eulerAngles.y, transform.localEulerAngles.z);
        }
        transform.eulerAngles += rotation * Time.deltaTime;
    }
}
