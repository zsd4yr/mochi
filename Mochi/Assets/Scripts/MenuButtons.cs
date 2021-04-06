using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour {
    public string sceneToLoad;
    public FadeImageInOut canvasFader;

    public GameObject Menu;
    bool Pause = false;
    // Use this for initialization
    void Start () {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
        Pause = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Menu != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                //print("MenuCalled");
                if (Pause == false)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Menu.SetActive(true);
                    Pause = true;
                    Time.timeScale = 0;
                }
                else
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                    Menu.SetActive(false);
                    Pause = false;
                    Time.timeScale = 1;
                }
            }
        }
		
	}

    IEnumerator FirstLevelStarts()
    {
        canvasFader.FadeIn();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToLoad);
        yield return null;
    }

    IEnumerator EnterCredits()
    {
        canvasFader.FadeIn();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Credits");
        yield return null;
    }
    IEnumerator EntermainMenu()
    {
        canvasFader.FadeIn();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("StartTemp");
        yield return null;
    }
    IEnumerator RestartLevel()
    {
        canvasFader.FadeIn();
        string LevelName = SceneManager.GetActiveScene().name;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(LevelName);
        yield return null;
    }

    public void FirstLevels()
    {
        if (Menu != null)
        {
            Menu.SetActive(false);
        }

        Time.timeScale = 1;

        StartCoroutine(FirstLevelStarts());
    }
    public void Retry()
    {
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
        Time.timeScale = 1;

        StartCoroutine(RestartLevel());

    }

    public void Credits()
    {
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
        Time.timeScale = 1;

        StartCoroutine(EnterCredits());
    }
    public void mainMenu()
    {
        if (Menu != null)
        {
            Menu.SetActive(false);
        }
        Time.timeScale = 1;

        StartCoroutine(EntermainMenu());
    }
    public void CloseGame()
    {

        Time.timeScale = 1;

        Application.Quit();
    }
    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.None;
        Menu.SetActive(false);
        Pause = false;
        Time.timeScale = 1;
    }
}
