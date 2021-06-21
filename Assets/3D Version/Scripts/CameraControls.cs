using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private bool holdingQ, holdingE;
    public float rotationSpeed = 10f;
    [SerializeField]
    float turningAngle;
    // Start is called before the first frame update
    void Start()
    {
        holdingQ = false;
        holdingE = false;
        turningAngle = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateKeys();
        turningAngle = GetDirection();
        transform.Rotate(new Vector3(transform.localRotation.x, turningAngle * rotationSpeed * Time.deltaTime, transform.localRotation.z));
    }

    private void UpdateKeys()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            holdingQ = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            holdingQ = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            holdingE = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            holdingE = false;
        }
    }

    private float GetDirection()
    {
        if(holdingQ && holdingE)
        {
            return 0f;
        }
        else
        {
            if(holdingQ)
            {
                return -1f;
            }
            if(holdingE)
            {
                return 1f;
            }
        }

        return 0f;
    }
}
