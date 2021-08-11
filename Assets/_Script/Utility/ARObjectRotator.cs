using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectRotator : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 2f;
    [SerializeField] private float rotateSpeed = 20f;

    float initDistance;
    float currentDistance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch0 = Input.GetTouch(0);

            if (touch0.phase == TouchPhase.Moved)
            {
                RotatePlane(-touch0.deltaPosition.x);
            }
        }

        if (Input.touchCount >= 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            if (touch0.phase == TouchPhase.Began || touch1.phase == TouchPhase.Began)
            {
                initDistance = Vector2.Distance(touch0.position, touch1.position);
            }

            currentDistance = Vector2.Distance(touch0.position, touch1.position);

            if (initDistance > currentDistance)
                ScaleObject(-1);
            else if (initDistance < currentDistance)
                ScaleObject(1);
        }

    }

    public void ScaleObject(float scaleFactor)
    {
        transform.localScale += new Vector3(scaleFactor * scaleSpeed, scaleFactor * scaleSpeed, scaleFactor * scaleSpeed);
    }

    public void RotatePlane(float deltaPosX)
    {
        Quaternion yRotation = Quaternion.Euler(0f, -deltaPosX * rotateSpeed, 0f);
        transform.rotation *= yRotation;
    }

}
