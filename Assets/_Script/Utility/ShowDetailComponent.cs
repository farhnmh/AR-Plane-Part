using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDetailComponent : MonoBehaviour
{
    public string componentName;
    public GameObject spawnPoint;

    public void ChangeDetail(string index)
    {
        for (int i = 0; i < spawnPoint.transform.childCount; i++)
        {
            if (spawnPoint.transform.GetChild(i).name == $"{index}_{componentName}")
                spawnPoint.transform.GetChild(i).gameObject.SetActive(true);
            else
                spawnPoint.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
