using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TrackLevelProgress : MonoBehaviour
{
    //Variable for all batteries remaining in the level
    private int batteriesInLevel;

    public void Start()
    {
        //Find all batteries in the level and store the amount in batteriesInLevel variable
        GameObject[] batteries = GameObject.FindGameObjectsWithTag("Battery");
        batteriesInLevel = batteries.Length;
    }

    public void Update()
    {
        //If "r" is ever pressed, reset the level
        if (Input.GetKeyDown("r"))
        {
            reloadLevel();
        }
    }

    public void collectBattery()
    {
        //Subtract a battery from batteriesInLevel, since the player has collected one
        batteriesInLevel--;
        //Now check if the player has collected enough batteries to move on to the next level by testing if the batteries in the level is 0 or less--if so, load the next level
        if(batteriesInLevel <= 0)
        {
            loadNextLevel();
        }
    }

    public void loadNextLevel()
    {
        //Retrieve the currentScene, then load the scene one build index above that (the next scene in the build settings)
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(currentScene.buildIndex + 1, LoadSceneMode.Single);
    }

    public void reloadLevel()
    {
        //Retrieve the currentScene, then load that scene again
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(currentScene.buildIndex, LoadSceneMode.Single);
    }

    

    


}
