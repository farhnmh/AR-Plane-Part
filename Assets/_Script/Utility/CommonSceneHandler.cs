using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonSceneHandler : MonoBehaviour
{
    public AnimateObject transitionImage;

    // Start is called before the first frame update
    void Start()
    {
        if (transitionImage == null)
            return;

        transitionImage.FadeOut(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneIndex)
    {
        if(transitionImage != null)
            StartCoroutine(LoadSceneDelay(transitionImage.animDuration, sceneIndex));
        else
            SceneManager.LoadScene(sceneIndex);
    }

    private IEnumerator LoadSceneDelay(float delay, string sceneIndex)
    {
        transitionImage.FadeIn(0f);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitApps()
    {
        StartCoroutine(DelayQuit());
    }

    private IEnumerator DelayQuit()
    {
        transitionImage.FadeIn(0f);
        yield return new WaitForSeconds(transitionImage.animDuration);
        Application.Quit();
    }
}
