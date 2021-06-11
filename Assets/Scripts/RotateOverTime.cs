using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    //amount to rotate the object by
    public Vector3 rotation;
    // Update is called once per frame
    void Update()
    {
        //every frame rotate the object, multiplying by time to correct for different framerates
        transform.eulerAngles += rotation * Time.deltaTime;
    }
}
