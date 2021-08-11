using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wira_LoadingScene : MonoBehaviour
{
    public AnimateObject transitionImage;
    public string sceneIndex;

    [Header("LoadingAnimation")]
    public TextMeshProUGUI loadingBarText;

    // Start is called before the first frame update
    void Start()
    {
        transitionImage.FadeOut(0f);
        StartCoroutine(LoadAsync(sceneIndex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsync(string sceneToLoad)
    {
        float loading = 0;
        while (true)
        {
            loading += Time.time;

            loadingBarText.text = "Loading... " +  loading.ToString("F0") + "%";
            
            if(loading >= 100f)
            {
                loading = 100;
                break;
            }

            yield return new WaitForSeconds(0.25f);
        }

        transitionImage.FadeIn(0f);
        yield return new WaitForSeconds(transitionImage.animDuration);

        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator LoadingEnumerator(string sceneToLoad, float maxDurationLoad)
    {
        AsyncOperation loadingOps = SceneManager.LoadSceneAsync(sceneToLoad);
        float loadProgress;
        float timeProgress = 0;

        while (timeProgress >= maxDurationLoad)
        {
            loadProgress = loadingOps.progress;
            loadingBarText.text = loadProgress.ToString() + "%";

            float randomWait = Random.Range(0.15f, 1.75f);
            timeProgress += Time.deltaTime;

            yield return new WaitForSeconds(randomWait);
        }

        transitionImage.FadeIn(0f);
    }

}
