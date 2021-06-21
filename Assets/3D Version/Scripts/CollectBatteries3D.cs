using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBatteries3D : MonoBehaviour
{
    //This is a variable to store the levelTracker in the level--there should only be one of these objects in the scene
    //Also, the name of the variable must be "LevelTracker" because that's how this script finds a reference to it
    //The LevelTracker's job is to track how many batteries are remaining in the level to be collected, and once enough are collected, it loads the next scene in the build settings.
    private TrackLevelProgress levelTracker;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("LevelTracker").TryGetComponent(out levelTracker);
    }

    //If the player collides with an object with the Battery tag, call the collectBattery method on levelTracker (which decrements the battereisInLevel variable and then checks if battereisInLevel is 0 or less, loading the next scene if it is)
    //Additionally, the battery is destroyed

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Battery"))
        {
            levelTracker.collectBattery();
            Destroy(other.gameObject);
        }
    }
}
