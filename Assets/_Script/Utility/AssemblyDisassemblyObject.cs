using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblyDisassemblyObject : MonoBehaviour
{
    public GameObject assemblyObject;
    public GameObject disassemblyObject;
    public GameObject assemblyButton;
    public GameObject disassemblyButton;
    public bool isAssembly = true;
    public bool onDetect;

    private void Update()
    {
        if (onDetect)
        {
            switch (PlayerPrefs.GetInt("isAssembly"))
            {
                case 0:
                    assemblyButton.SetActive(false);
                    disassemblyButton.SetActive(true);

                    assemblyObject.SetActive(true);
                    disassemblyObject.SetActive(false);
                    isAssembly = true;
                    break;
                case 1:
                    assemblyButton.SetActive(true);
                    disassemblyButton.SetActive(false);

                    assemblyObject.SetActive(false);
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
