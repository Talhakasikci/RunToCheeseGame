using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentMove : MonoBehaviour
{
    private float xRotation;
    private float mouseSensivity = 100f;

    public GameObject oyuncu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * Time.smoothDeltaTime * mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.smoothDeltaTime * mouseSensivity;

        xRotation += mouseX;
        transform.localRotation = Quaternion.Euler(0, xRotation, 0);
        oyuncu.transform.Rotate(Vector3.up * mouseX);

    }
}
