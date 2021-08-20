using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightedObjectHandler : MonoBehaviour
{
    public GameObject assembledDisassembledObject;
    public GameObject assemblyDisassemblyButton;
    public GameObject backButton;
    public GameObject tempObject;
    public TextMeshPro objectNameText;

    public void HighlightObject(GameObject temp)
    {
        tempObject = temp;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).name == tempObject.name)
            {
                transform.GetChild(i).gameObject.SetActive(true);
                objectNameText.text = tempObject.name;
            }
            else
                transform.GetChild(i).gameObject.SetActive(false);
        }

        backButton.SetActive(true);
        assemblyDisassemblyButton.SetActive(false);
        assembledDisassembledObject.SetActive(false);
    }

    public void DisassemblyObject()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        objectNameText.text = "";
        backButton.SetActive(false);
        assemblyDisassemblyButton.SetActive(true);
        assembledDisassembledObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
