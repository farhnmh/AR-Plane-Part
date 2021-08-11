using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0));
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(new Vector3(0, -rotateSpeed * Time.deltaTime, 0));
    }
}
