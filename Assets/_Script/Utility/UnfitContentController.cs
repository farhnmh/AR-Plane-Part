using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnfitContentController : MonoBehaviour
{
    public AnimateObject[] contentsToShow;
    public GameObject prevButton;
    public GameObject nextButton;

    private int contentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        prevButton.SetActive(false);
        nextButton.SetActive(true);

        contentsToShow[contentIndex].canvasGroup.alpha = 1;
        contentsToShow[contentIndex].canvasGroup.interactable = true;
        contentsToShow[contentIndex].canvasGroup.blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowNextContentContainer()
    {
        prevButton.SetActive(true);
        int tempContentIndex = contentIndex;
        contentIndex++;

        if (contentIndex >= contentsToShow.Length - 1)
            nextButton.SetActive(false);

        contentsToShow[tempContentIndex].FadeOut(0f);
        contentsToShow[tempContentIndex].MoveToCustomPosition(0f, new Vector2(100f, 0f));
        contentsToShow[contentIndex].FadeIn(0f);
        contentsToShow[contentIndex].MoveFromCustomPosition(0f, new Vector2(-100f, 0f), new Vector2(0f, 0f));
    }

    public void ShowPrevContentContainer()
    {
        nextButton.SetActive(true);
        int tempContentIndex = contentIndex;
        contentIndex--;

        if (contentIndex <= 0)
            prevButton.SetActive(false);

        contentsToShow[tempContentIndex].FadeOut(0f);
        contentsToShow[tempContentIndex].MoveToCustomPosition(0f, new Vector2(-100f, 0f));
        contentsToShow[contentIndex].FadeIn(0f);
        contentsToShow[contentIndex].MoveFromCustomPosition(0f, new Vector2(100f, 0f), new Vector2(0f, 0f));
    }

    public void ResetIndex()
    {
        contentIndex = 0;
        nextButton.SetActive(true);
        prevButton.SetActive(false);
    }

}
