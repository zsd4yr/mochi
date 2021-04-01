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
    public int sceneNum = 2;
    public Image image;
    public float timeToLerp = 2f;

    public FadeImageInOut FadeIO;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
            StartCoroutine(BeginLoad(scene));
    }

    private IEnumerator BeginLoad(string sceneName)
    {
        if (FadeIO != null)
        { FadeIO.FadeIn(); }

        yield return new WaitForSeconds(timeToLerp);
        SceneManager.LoadScene(2);
        yield return new WaitForSeconds(timeToLerp);
        yield return null;
    }

    void FadeToImage()
    {
        Mathf.Lerp(image.color.a, 255f, timeToLerp);
    }

}
