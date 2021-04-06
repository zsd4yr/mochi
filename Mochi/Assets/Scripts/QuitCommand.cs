using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class QuitCommand : MonoBehaviour
{
    public string SceneString = "GregScene2";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(SceneString);
        }
    }
}
