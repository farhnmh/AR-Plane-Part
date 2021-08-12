using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDisassemblyObject : MonoBehaviour
{
    [Header("General Attribute")]
    public GameObject assemblyButton;
    public GameObject disassemblyButton;
    public GameObject seriesButton;
    public bool isAssembly = true;
    public bool onDetect;

    [Header("Object Attribute")]
    public GameObject assemblyObject;
    public GameObject disassemblyObject;
    public GameObject firstConfObject;
    public GameObject secondConfObject;
    public GameObject thirdConfObject;

    [Header("Series Attribute")]
    public bool seriesClicked;
    public bool AssembledChosen;
    public bool ABSeriesChosen;
    public bool LSeriesChosen;

    private void Update()
    {
        if (onDetect)
        {
            switch (PlayerPrefs.GetInt("isAssembly"))
            {
                case 0:
                    assemblyButton.SetActive(false);
                    disassemblyButton.SetActive(true);

                    if (ABSeriesChosen)
                    {
                        assemblyObject.SetActive(false);
                        firstConfObject.SetActive(true);
                        secondConfObject.SetActive(false);
                        thirdConfObject.SetActive(false);
                    }
                    else if (LSeriesChosen)
                    {
                        assemblyObject.SetActive(false);
                        firstConfObject.SetActive(false);
                        secondConfObject.SetActive(true);
                        thirdConfObject.SetActive(true);
                    }
                    else if (AssembledChosen)
                    {
                        assemblyObject.SetActive(true);
                        firstConfObject.SetActive(false);
                        secondConfObject.SetActive(false);
                        thirdConfObject.SetActive(false);
                    }

                    disassemblyObject.SetActive(false);
                    isAssembly = true;
                    break;
                case 1:
                    assemblyButton.SetActive(true);
                    disassemblyButton.SetActive(false);

                    assemblyObject.SetActive(false);
                    firstConfObject.SetActive(false);
                    secondConfObject.SetActive(false);
                    thirdConfObject.SetActive(false);
                    disassemblyObject.SetActive(true);
                    isAssembly = false;
                    break;
            }
        }
    }

    public void OnDetection()
    {
        onDetect = true;
    }

    public void ResetCondition()
    {
        onDetect = false;

        assemblyButton.SetActive(false);
        disassemblyButton.SetActive(false);

        assemblyObject.SetActive(false);
        disassemblyObject.SetActive(false);
    }

    public void OpenSeries(int index)
    {
        switch (index)
        {
            // Series Button Parent
            case 0:
                if (!seriesClicked) 
                {
                    seriesButton.SetActive(true);
                    seriesClicked = true;    
                }
                else
                {
                    seriesButton.SetActive(false);
                    seriesClicked = false;
                }
                break;

            // AB Series Button
            case 1:
                if (!ABSeriesChosen)
                {
                    AssembledChosen = false;
                    ABSeriesChosen = true;
                    LSeriesChosen = false;
                }
                else
                {
                    AssembledChosen = true;
                    ABSeriesChosen = false;
                    LSeriesChosen = false;
                }
                break;

            // L Series Button
            case 2:
                if (!LSeriesChosen)
                {
                    AssembledChosen = false;
                    ABSeriesChosen = false;
                    LSeriesChosen = true;
                }
                else
                {
                    AssembledChosen = true;
                    ABSeriesChosen = false;
                    LSeriesChosen = false;
                }
                break;
        }
    }

    public void AssemblyObject()
    {
        PlayerPrefs.SetInt("isAssembly", 0);
        isAssembly = true;
    }

    public void DisassemblyObject()
    {
        PlayerPrefs.SetInt("isAssembly", 1);
        isAssembly = false;
    }
}
