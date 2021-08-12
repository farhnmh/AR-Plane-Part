using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssemblyInspection : MonoBehaviour
{
    [Header("Menu Attribute")]
    public GameObject welcomeMenu;
    public GameObject chooseSeriesMenu;
    public GameObject ABSeriesMenu;
    public GameObject LSeriesMenu;
    public int menuIndex;

    [Header("Event Attribute")]
    public UnityEvent[] objectEvent;

    void Start()
    {
        menuIndex = PlayerPrefs.GetInt("AssemblyMenu");
    }

    void Update()
    {
        UpdateMenuIndex();
    }

    public void SetMenuIndex(int index)
    {
        menuIndex = index;
        PlayerPrefs.SetInt("AssemblyMenu", menuIndex);
    }

    public void UpdateMenuIndex()
    {
        switch (menuIndex)
        {
            case 0:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(true);
                chooseSeriesMenu.SetActive(false);
                ABSeriesMenu.SetActive(false);
                LSeriesMenu.SetActive(false);
                break;

            case 1:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(false);
                chooseSeriesMenu.SetActive(true);
                ABSeriesMenu.SetActive(false);
                LSeriesMenu.SetActive(false);
                break;

            case 2:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(false);
                chooseSeriesMenu.SetActive(false);
                ABSeriesMenu.SetActive(true);
                LSeriesMenu.SetActive(false);
                break;

            case 3:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(false);
                chooseSeriesMenu.SetActive(false);
                ABSeriesMenu.SetActive(false);
                LSeriesMenu.SetActive(true);
                break;

            case 4:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(false);
                chooseSeriesMenu.SetActive(false);
                ABSeriesMenu.SetActive(true);
                LSeriesMenu.SetActive(false);
                break;

            case 5:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(false);
                chooseSeriesMenu.SetActive(false);
                ABSeriesMenu.SetActive(false);
                LSeriesMenu.SetActive(true);
                break;

            case 6:
                objectEvent[menuIndex].Invoke();
                welcomeMenu.SetActive(false);
                chooseSeriesMenu.SetActive(false);
                ABSeriesMenu.SetActive(false);
                LSeriesMenu.SetActive(true);
                break;
        }
    }
}
