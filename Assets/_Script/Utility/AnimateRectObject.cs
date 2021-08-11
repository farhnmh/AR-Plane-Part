using System;
using UnityEngine;
using UnityEngine.UI;

public class AnimateRectObject : MonoBehaviour
{
    public RectTransform objectRectTransform;
    public Vector3 moveFrom;
    public Vector3 moveTo;
    public float animDuration;
    public LeanTweenType animEasing;

    public void FadeIn(float delayAnim)
    {
        CanvasGroup objectCanvasGroup = objectRectTransform.GetComponent<CanvasGroup>();

        objectCanvasGroup.alpha = 0;

        LeanTween.alphaCanvas(objectCanvasGroup, 1f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing);
    }

    public void FadeIn(float delayAnim, string audioToPlay)
    {
        CanvasGroup objectCanvasGroup = objectRectTransform.GetComponent<CanvasGroup>();

        objectCanvasGroup.alpha = 0;

        LeanTween.alphaCanvas(objectCanvasGroup, 1f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing);

        if (string.IsNullOrEmpty(audioToPlay))
            return;

        AudioController.Play(audioToPlay);
    }

    public void FadeOut(float delayAnim)
    {
        CanvasGroup objectCanvasGroup = objectRectTransform.GetComponent<CanvasGroup>();

        objectCanvasGroup.alpha = 1;

        LeanTween.alphaCanvas(objectCanvasGroup, 0f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing);
    }

    public void FadeOut(float delayAnim, string audioToPlay)
    {
        CanvasGroup objectCanvasGroup = objectRectTransform.GetComponent<CanvasGroup>();

        objectCanvasGroup.alpha = 1;

        LeanTween.alphaCanvas(objectCanvasGroup, 0f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing);

        if (string.IsNullOrEmpty(audioToPlay))
            return;

        AudioController.Play(audioToPlay);
    }

    public void MoveFromOriginalPosition(float animDelay)
    {
        objectRectTransform.LeanMoveLocal(moveTo, animDuration)
            .setDelay(animDelay)
            .setEase(animEasing);
    }

    public void MoveFromCustomPosition(float animDelay)
    {
        objectRectTransform.localPosition = moveFrom;

        objectRectTransform.LeanMoveLocal(moveTo, animDuration)
            .setDelay(animDelay)
            .setEase(animEasing);
    }

}