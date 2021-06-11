using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameobjectOnContactWithPlayer : MonoBehaviour
{
    public GameObject gameObj;
    public bool destoryOnContactWithPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player enters the objects trigger, disable the gameObject passed in. 
        if (collision.gameObject.CompareTag("Player"))
        {
            disableDoor();
            if (destoryOnContactWithPlayer)
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void disableDoor()
    {
        gameObj.SetActive(false);
    }
}
