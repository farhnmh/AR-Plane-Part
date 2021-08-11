using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObjectSpawner : MonoBehaviour
{
    public Transform spawnPos;

    private GameObject spawnedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToSelection()
    {
        Destroy(spawnedObject);
    }

    public void SpawnObject(GameObject modelToSpawn)
    {
        spawnedObject = Instantiate(modelToSpawn);
        spawnedObject.transform.position = Vector3.zero;
    }

    public void SpawnObjectToSpawnPos(GameObject modelToSpawn)
    {
        spawnedObject = Instantiate(modelToSpawn);
        spawnedObject.transform.position = spawnPos.position;
        spawnedObject.transform.parent = spawnPos;
    }

}
