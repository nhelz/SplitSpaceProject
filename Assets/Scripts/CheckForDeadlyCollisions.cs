using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForDeadlyCollisions : MonoBehaviour
{
    //This is a variable to store the levelTracker in the level--there should only be one of these objects in the scene
    //Also, the name of the variable must be "LevelTracker" because that's how this script finds a reference to it
    private TrackLevelProgress levelTracker;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("LevelTracker").TryGetComponent(out levelTracker);
    }
    //If this object enters a trigger with the tag "Deadly", it tells the LevelTracker to restart the level. This is so that every laser or any other deadly obstacle doesn't have to have a reference to TrackLevelProgress. Instead, just set the tag to "Deadly" for any deadly obstacles.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly"))
        {
            levelTracker.reloadLevel();
        }
    }
}
