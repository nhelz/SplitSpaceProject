using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameobjectOnContactWithPlayer3D : MonoBehaviour
{
    public GameObject gameObj;
    public bool destoryOnContactWithPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            disableDoor();
            if (destoryOnContactWithPlayer)
            {
                Destroy(gameObject);
            }
        }
    }

    void disableDoor()
    {
        gameObj.SetActive(false);
    }
}
