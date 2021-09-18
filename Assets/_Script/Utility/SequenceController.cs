using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public enum SequenceEnum
{
    NORMAL,
    CAUTION,
    CAUTIONANIMATION,
    ANIMATION,
    NOTE,
    NOTEANIMATION,
    ADDITION
}

[Serializable]
public class SequencesData
{
    public string sequenceTitle;
    public SequenceEnum sequenceType;
    [TextArea(5, 20)] public string sequenceDetails;
    [TextArea(5, 20)] public string additionDetails;
    public GameObject sequenceAnimation;
    public Button thisHyperlink;
    public UnityEvent onClickEvent;
    public UnityEvent onClickObject;
    public bool hyperlink;
    public bool clickedObject;
}

public class SequenceController : MonoBehaviour
{
    public int sequenceNow;
    public SoundHandler soundHandler;
    public SequencesData[] sequencesDatas;
    public GameObject sequenceTextNormal;
    public GameObject sequenceTextCaution;
    public GameObject sequenceTextCautionAnimation;
    public GameObject sequenceTextAnimation;
    public GameObject sequenceTextNote;
    public GameObject sequenceTextNoteAnimation;
    public GameObject sequenceTextAddition;
    public GameObject hyperlinkButton;
    public GameObject hyperlinkOnAnimationButton;
    public GameObject contentContainerParent;
    public GameObject additionContainerParent;
    public GameObject objectSpawnParent;
    public Button button;
    private int sequenceLength;
    
    public GameObject nextButton;
    public GameObject prevButton;

    // Start is called before the first frame update
    void Start()
    {
        sequenceLength = sequencesDatas.Length;
        sequenceNow = 0;

        if (sequencesDatas == null)
            return;

        if (sequenceNow <= 0)
            prevButton.SetActive(false);

        SpawnSequenceData();
    }

    // Update is called once per frame
    void Update()
    {
        if (button != null)
            button.onClick.AddListener(sequencesDatas[sequenceNow].onClickEvent.Invoke);

        if (sequencesDatas[sequenceNow].clickedObject){
            objectSpawnParent.transform.GetChild(0).gameObject.GetComponent<ModelObjectOnclickEventHandler>().onClickEvent =
                sequencesDatas[sequenceNow].onClickObject;
        }
    }

    void ClearAllContent()
    {
        for (int i = 0; i < objectSpawnParent.transform.childCount; i++)
        {
            Destroy(objectSpawnParent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < contentContainerParent.transform.childCount; i++)
        {
            Destroy(contentContainerParent.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < additionContainerParent.transform.childCount; i++)
        {
            Destroy(additionContainerParent.transform.GetChild(i).gameObject);
        }

        button = null;
    }

    public void ShowNextSequence()
    {
        nextButton.SetActive(true);
        prevButton.SetActive(true);

        ClearAllContent();
        sequenceNow++;

        if (sequenceNow >= sequenceLength - 1) {
            nextButton.SetActive(false);
            sequenceNow = sequenceLength - 1;
        }

        SpawnSequenceData();
    }

    public void ShowPrevSequence()
    {
        nextButton.SetActive(true);
        prevButton.SetActive(true);

        ClearAllContent();
        sequenceNow--;

        if (sequenceNow <= 0)
        {
            prevButton.SetActive(false);
            sequenceNow = 0;
        }

        SpawnSequenceData();
    }

    public void ContinueSequence()
    {
        ClearAllContent();
        SpawnSequenceData();
    }

    void SoundManager()
    {
        soundHandler.StopSound();
        soundHandler.ChangeSound(sequenceNow + 1);
        soundHandler.PlaySound();
    }

    void SpawnSequenceData()
    {
        switch (sequencesDatas[sequenceNow].sequenceType)
        {
            case SequenceEnum.NORMAL:
                TextMeshProUGUI normalText = Instantiate(sequenceTextNormal, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                normalText.text = sequencesDatas[sequenceNow].sequenceDetails;
                SoundManager();

                if (sequencesDatas[sequenceNow].hyperlink)
                {
                    GameObject hyperlinkNormal = Instantiate(hyperlinkButton, contentContainerParent.transform);
                    sequencesDatas[sequenceNow].thisHyperlink = hyperlinkNormal.GetComponent<Button>();

                    hyperlinkNormal.transform.localPosition = new Vector3(0, -50, 0);
                    hyperlinkNormal.transform.localScale = new Vector3(3, 3, 3);

                    button = sequencesDatas[sequenceNow].thisHyperlink;
                }
                break;
            case SequenceEnum.CAUTION:
                TextMeshProUGUI cautionText = Instantiate(sequenceTextCaution, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                cautionText.text = sequencesDatas[sequenceNow].sequenceDetails;
                SoundManager();
                break;
            case SequenceEnum.CAUTIONANIMATION:
                TextMeshProUGUI cautionAnimationText = Instantiate(sequenceTextCautionAnimation, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                cautionAnimationText.text = sequencesDatas[sequenceNow].sequenceDetails;
                Instantiate(sequencesDatas[sequenceNow].sequenceAnimation, objectSpawnParent.transform);
                SoundManager();

                if (sequencesDatas[sequenceNow].hyperlink)
                {
                    GameObject hyperlinkAnimation = Instantiate(hyperlinkOnAnimationButton, contentContainerParent.transform);
                    sequencesDatas[sequenceNow].thisHyperlink = hyperlinkAnimation.GetComponent<Button>();

                    button = sequencesDatas[sequenceNow].thisHyperlink;
                }
                break;
            case SequenceEnum.ANIMATION:
                TextMeshProUGUI animationText = Instantiate(sequenceTextAnimation, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                animationText.text = sequencesDatas[sequenceNow].sequenceDetails;
                Instantiate(sequencesDatas[sequenceNow].sequenceAnimation, objectSpawnParent.transform);
                SoundManager();

                if (sequencesDatas[sequenceNow].hyperlink)
                {
                    GameObject hyperlinkAnimation = Instantiate(hyperlinkOnAnimationButton, contentContainerParent.transform);
                    sequencesDatas[sequenceNow].thisHyperlink = hyperlinkAnimation.GetComponent<Button>();

                    button = sequencesDatas[sequenceNow].thisHyperlink;
                }
                break;
            case SequenceEnum.NOTE:
                TextMeshProUGUI noteText = Instantiate(sequenceTextNote, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                noteText.text = sequencesDatas[sequenceNow].sequenceDetails;
                SoundManager();
                break;
            case SequenceEnum.NOTEANIMATION:
                TextMeshProUGUI noteAnimationText = Instantiate(sequenceTextNoteAnimation, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                noteAnimationText.text = sequencesDatas[sequenceNow].sequenceDetails;
                Instantiate(sequencesDatas[sequenceNow].sequenceAnimation, objectSpawnParent.transform);
                SoundManager();

                if (sequencesDatas[sequenceNow].hyperlink)
                {
                    GameObject hyperlinkAnimation = Instantiate(hyperlinkOnAnimationButton, contentContainerParent.transform);
                    sequencesDatas[sequenceNow].thisHyperlink = hyperlinkAnimation.GetComponent<Button>();

                    button = sequencesDatas[sequenceNow].thisHyperlink;
                }
                break;
            case SequenceEnum.ADDITION:
                TextMeshProUGUI additionText = Instantiate(sequenceTextAnimation, contentContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                additionText.text = sequencesDatas[sequenceNow].sequenceDetails;

                additionText = Instantiate(sequenceTextAddition, additionContainerParent.transform)
                    .GetComponentInChildren<TextMeshProUGUI>();
                additionText.text = sequencesDatas[sequenceNow].additionDetails;
                SoundManager();
                break;
            default:
                break;
        }
    }
}
    