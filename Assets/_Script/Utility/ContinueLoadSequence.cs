using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueLoadSequence : MonoBehaviour
{
    public SequenceController sceneHandler;
    public int resultSequence;
    public int indexProject;

    void Start()
    {
        if (indexProject == 0)
            resultSequence = PlayerPrefs.GetInt("Wira_Sequence");
        else if (indexProject == 1)
            resultSequence = PlayerPrefs.GetInt("Xime_Sequence");

        sceneHandler.sequenceNow = resultSequence;
        sceneHandler.ContinueSequence();
        sceneHandler.nextButton.SetActive(true);
        sceneHandler.prevButton.SetActive(true);

        if (sceneHandler.sequenceNow == 0)
            sceneHandler.prevButton.SetActive(false);
        else if (sceneHandler.sequenceNow == sceneHandler.sequencesDatas.Length - 1)
            sceneHandler.nextButton.SetActive(false);
    }

    public void SaveSequence()
    {
        if (indexProject == 0)
            PlayerPrefs.SetInt("Wira_Sequence", sceneHandler.sequenceNow);
        else if (indexProject == 1)
            PlayerPrefs.SetInt("Xime_Sequence", sceneHandler.sequenceNow);
    }

    public void ResetSequence()
    {
        if (indexProject == 0)
            PlayerPrefs.SetInt("Wira_Sequence", 0);
        else if (indexProject == 1)
            PlayerPrefs.SetInt("Xime_Sequence", 0);
    }
}
