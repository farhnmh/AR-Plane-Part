using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideContainer : MonoBehaviour
{
    public void ShowContainer(AnimateObject container)
    {
        container.FadeIn(0f);
    }

    public void HideContainer(AnimateObject container)
    {
        container.FadeOut(0f);
    }
}
