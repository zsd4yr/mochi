using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressSceneLoader : MonoBehaviour
{
    public Text progressText;
    public Slider slider;
    AsyncOperation operation;
    public Canvas canvas;
    public string scene;

    private void Awake()
    {
        
        DontDestroyOnLoad(gameObject);
        LoadScene(scene);
    }

    public void LoadScene(string sceneName)
    {
        UpdateProgressUI(0);
        canvas.gameObject.SetActive(true);
        StartCoroutine(BeginLoad(sceneName));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone)
        {
            UpdateProgressUI(operation.progress);
            yield return new WaitForSeconds(2);
        }

        //load finished
        UpdateProgressUI(operation.progress);
        yield return new WaitForSeconds(2);
        operation = null;
        canvas.gameObject.SetActive(false);

    }

    private void UpdateProgressUI(float progress)
    {
        slider.value = progress;
        progressText.text = (int)(progress * 100f) + "%";
    }
}
