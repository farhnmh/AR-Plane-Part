using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowContentImages : MonoBehaviour
{
    public GameObject contentContainer;
    public GameObject imagePrefabs;
    public bool isInitClass = true;

    private List<ImageUICanvasObjectScaler> spriteImageArray;

    // Start is called before the first frame update
    void Start()
    {
        if(isInitClass)
            InitClass();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearContentContainer()
    {
        if(spriteImageArray != null)
            spriteImageArray.Clear();

        for (int i = 0; i < contentContainer.transform.childCount; i++)
        {
            Transform children = contentContainer.transform.GetChild(i);
            Destroy(children.gameObject);
        }
    }

    public void SpawnImagePrefabNormal(Sprite imageSprite)
    {
        Image spawnedImage = Instantiate(imagePrefabs, contentContainer.transform).GetComponent<Image>();
        spawnedImage.sprite = imageSprite;

        spriteImageArray.Add(spawnedImage.GetComponent<ImageUICanvasObjectScaler>());
    }

    public void SpawnImagePrefab(Sprite imageSprite)
    {
        ClearContentContainer();
        Image spawnedImage = Instantiate(imagePrefabs, contentContainer.transform).GetComponent<Image>();
        spawnedImage.sprite = imageSprite;

        spriteImageArray.Add(spawnedImage.GetComponent<ImageUICanvasObjectScaler>());
    }

    public void SpawnImagePrefab(SpriteArray imageSprite)
    {
        ClearContentContainer();
        for (int i = 0; i < imageSprite.spriteImageToSpawn.Length; i++)
        {
            SpawnImagePrefabNormal(imageSprite.spriteImageToSpawn[i]);
        }
    }

    public void ScaleUpSprites()
    {
        foreach (ImageUICanvasObjectScaler sprite in spriteImageArray)
        {
            sprite.ScaleUp();
        }
    }

    public void ScaleDownSprites()
    {
        foreach (ImageUICanvasObjectScaler sprite in spriteImageArray)
        {
            sprite.ScaleDown();
        }
    }

    public void ScaleUpSpritesContainer()
    {
        ImageUICanvasObjectScaler[] contentChild = contentContainer.
            GetComponentsInChildren<ImageUICanvasObjectScaler>();

        foreach (ImageUICanvasObjectScaler sprite in contentChild)
        {
            sprite.ScaleUp();
        }
    }

    public void ScaleDownSpritesContainer()
    {
        ImageUICanvasObjectScaler[] contentChild = contentContainer.
            GetComponentsInChildren<ImageUICanvasObjectScaler>();

        foreach (ImageUICanvasObjectScaler sprite in contentChild)
        {
            sprite.ScaleDown();
        }
    }

    public void ScaleUpSprites(ImageUICanvasObjectScaler sprite)
    {
        sprite.ScaleUp();
    }

    public void ScaleDownSprites(ImageUICanvasObjectScaler sprite)
    {
        sprite.ScaleDown();
    }

    public void InitClass()
    {
        spriteImageArray = new List<ImageUICanvasObjectScaler>();
        ClearContentContainer();
    }

}
