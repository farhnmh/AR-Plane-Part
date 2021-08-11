﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ModelObjectOnclickEventHandler : MonoBehaviour
{
    public UnityEvent onClickEvent;

    private void OnMouseDown()
    {
        onClickEvent.Invoke();
    }

}
