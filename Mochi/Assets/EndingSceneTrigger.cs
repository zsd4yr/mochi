using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingSceneTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    AsyncOperation operation;
    public string scene;
    public Image image;
    public float timeToLerp = 2f;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            StartCoroutine(BeginLoad(scene));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        yield return new WaitForSeconds(timeToLerp);
        FadeToImage();
        yield return new WaitForSeconds(timeToLerp);
        operation = SceneManager.LoadSceneAsync(sceneName);
        yield return null;
    }

    void FadeToImage()
    {
        Mathf.Lerp(image.color.a, 255f, timeToLerp);
    }

}
