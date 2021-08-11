using System;
using UnityEngine;
using UnityEngine.UI;

public class AnimateObject : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Vector3 moveFrom;
    public Vector3 moveTo;
    public float animDuration;
    public LeanTweenType animEasing;

    public void FadeIn(float delayAnim)
    {
        canvasGroup.alpha = 0;

        LeanTween.alphaCanvas(canvasGroup, 1f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing)
            .setOnComplete(() => SetInteractables(true));
    }

    public void FadeIn(float delayAnim, string audioToPlay)
    {
        canvasGroup.alpha = 0;

        LeanTween.alphaCanvas(canvasGroup, 1f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing)
            .setOnComplete(() => SetInteractables(true));

        if (string.IsNullOrEmpty(audioToPlay))
            return;

        AudioController.Play(audioToPlay);
    }

    public void FadeOut(float delayAnim)
    {
        canvasGroup.alpha = 1f;

        LeanTween.alphaCanvas(canvasGroup, 0f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing)
            .setOnComplete(() => SetInteractables(false));
    }

    public void FadeOut(float delayAnim, string audioToPlay)
    {
        canvasGroup.alpha = 1f;

        LeanTween.alphaCanvas(canvasGroup, 0f, animDuration)
            .setDelay(delayAnim)
            .setEase(animEasing)
            .setOnComplete(()=> SetInteractables(false));

        if (string.IsNullOrEmpty(audioToPlay))
            return;

        AudioController.Play(audioToPlay);
    }

    public void MoveFromOriginalPosition(float animDelay)
    {
        LeanTween.moveLocal(canvasGroup.gameObject, moveTo, animDuration)
            .setDelay(animDelay)
            .setEase(animEasing);
    }

    public void MoveFromCustomPosition(float animDelay)
    {
        canvasGroup.transform.localPosition = moveFrom;

        LeanTween.moveLocal(canvasGroup.gameObject, moveTo, animDuration)
            .setDelay(animDelay)
            .setEase(animEasing);
    }

    public void MoveToCustomPosition(float animDelay, Vector2 direction)
    {
        Vector2 tempLocalPos = canvasGroup.transform.localPosition;

        LeanTween.moveLocal(canvasGroup.gameObject, direction, animDuration)
            .setDelay(animDelay)
            .setEase(animEasing)
            .setOnComplete(() => canvasGroup.transform.localPosition = tempLocalPos);
    }

    public void MoveFromCustomPosition(float animDelay, Vector2 customStartPos, Vector2 customEndPos)
    {
        canvasGroup.transform.localPosition = customStartPos;

        LeanTween.moveLocal(canvasGroup.gameObject, customEndPos, animDuration)
            .setDelay(animDelay)
            .setEase(animEasing);
    }

    public void SetInteractables(bool isTrue)
    {
        canvasGroup.interactable = isTrue;
        canvasGroup.blocksRaycasts = isTrue;
    }

}
