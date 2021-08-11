using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wira_TaskCardScene : MonoBehaviour
{
    public ShowContentImages showContent;
    public SpriteArray spriteArray;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(0.5f);
        showContent.SpawnImagePrefab(spriteArray);
    }

}
