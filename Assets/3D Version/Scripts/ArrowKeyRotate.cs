using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeyRotate : MonoBehaviour
{
    private GameObject camCenter;
    [SerializeField]
    private Vector3 arrowDirection;
    private int quadrant;
    // Start is called before the first frame update
    void Start()
    {
        camCenter = GameObject.FindGameObjectWithTag("CameraCenter");
        quadrant = 1;
        arrowDirection = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuadrant();
        if(quadrant == 1)
        {
            arrowDirection = new Vector3(0f, 0f, 0f);
        }
        else if (quadrant == 2)
        {
            arrowDirection = new Vector3(0f, 270f, 0f);
        }
        else if (quadrant == 3)
        {
            arrowDirection = new Vector3(0f, 180f, 0f);
        }
        else if (quadrant == 4)
        {
            arrowDirection = new Vector3(0f, 90f, 0f);
        }
        transform.eulerAngles = arrowDirection;
    }

    private void UpdateQuadrant()
    {
        float radValue = Mathf.Abs(camCenter.transform.rotation.y);
        //float rotValue = camCenter.transform.rotation.y;
        Vector3 eulerAngle = camCenter.transform.eulerAngles;
        
        if(radValue > 0.9238796f)
        {
            quadrant = 3;
        }
        else if(radValue > 0.3826834f)
        {
            //Debug.Log(eulerAngle);
            //if the value is less than 180, quadrant 4, else quadrant 2
            if (eulerAngle.y < 180)
            {
                quadrant = 4;
            }
            else
            {
                quadrant = 2;
            }
        }
        else
        {
            quadrant = 1;
        }   
    }
    
    public float GetFrontAngle()
    {
        return arrowDirection.y;
    }
}
