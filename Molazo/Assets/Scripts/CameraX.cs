using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraX : MonoBehaviour {

    private float XRotation;

    void Update()
    {
        XRotation += 2 * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(0.0f, XRotation, 0.0f);
    }
}
