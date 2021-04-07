using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameCommands : MonoBehaviour
{
    public string SceneString = "GregScene2";
    GameControls controls;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new GameControls();
        controls.GameController.Quit.performed += QuitGame;
        controls.GameController.Restart.performed += RestartGame;
    }

    private void RestartGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneString);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
        controls.GameController.Quit.performed -= QuitGame;
    }

    void Update()
    {
        //if(controls.GameController)
        //{
        //    Application.Quit();
        //}
        /*if(Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(SceneString);
        }*/
    }


    private void QuitGame(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Application.Quit();
    }
}
