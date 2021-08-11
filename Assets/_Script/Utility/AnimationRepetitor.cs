using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationRepetitor : MonoBehaviour
{
    public GameObject nextAnim;

    public void NextAnimation()
    {
        var prefabAnim = Instantiate(nextAnim);
        prefabAnim.transform.parent = GameObject.Find("SpawnPos").transform;
        prefabAnim.transform.position = transform.position;
        Destroy(gameObject);
    }
}
