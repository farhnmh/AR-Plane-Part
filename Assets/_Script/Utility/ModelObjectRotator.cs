using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelObjectRotator : MonoBehaviour
{
    public float rotationRate = 0.65f;
    public float scaleRate = 0.0015f;

    float h, v;
    float currentDistance, initDistance;

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            transform.Rotate(v * rotationRate, -h * rotationRate, 0, Space.World);
        }

        if (Input.touchCount == 1) {

            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Moved)
            {
                transform.Rotate(touch.deltaPosition.y * rotationRate,
                                 -touch.deltaPosition.x * rotationRate, 0, Space.World);
            }
        }

        if (Input.touchCount == 2) {

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


        //foreach (Touch touch in Input.touches)
        //{

        //    if (touch.phase == TouchPhase.Began)
        //    {

        //    }
        //    else if (touch.phase == TouchPhase.Moved)
        //    {
        //        transform.Rotate(touch.deltaPosition.y * rotationRate,
        //                         -touch.deltaPosition.x * rotationRate, 0, Space.World);
        //    }
        //    else if (touch.phase == TouchPhase.Ended)
        //    {

        //    }
        //}
    }

    public void ScaleObject(float scaleFactor)
    {
        //transform.localScale += new Vector3(scaleFactor * scaleRate, scaleFactor * scaleRate, scaleFactor * scaleRate);
        Vector3 targetScale = transform.localScale + new Vector3(scaleFactor * scaleRate, scaleFactor * scaleRate, scaleFactor * scaleRate);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.25f);
    }
}