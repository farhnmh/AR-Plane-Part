using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xime_CustomCROStart : MonoBehaviour
{
    public ShowContentImages sceneHandler;
    public SpriteArray spriteToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        sceneHandler.SpawnImagePrefab(spriteToSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
