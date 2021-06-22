using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public Button button2D;
    public Button button3D;
    // Start is called before the first frame update
    void Start()
    {
        button2D.onClick.AddListener(button2DPressed);
        button3D.onClick.AddListener(button3DPressed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void button2DPressed()
    {
        //Debug.Log("2D");
        SceneManager.LoadSceneAsync("Level1", LoadSceneMode.Single);
    }

    private void button3DPressed()
    {
        //Debug.Log("3D");
        SceneManager.LoadSceneAsync("3DLevel1", LoadSceneMode.Single);
    }
}
