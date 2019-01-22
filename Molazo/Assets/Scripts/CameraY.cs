using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraY : MonoBehaviour {

    public float AngleMinMax;
    private float YRotation;

    void Update()
    {
        YRotation -=  Input.GetAxis("Mouse Y");

        if (YRotation >= AngleMinMax)
        {
            YRotation = AngleMinMax;
        }

        if (YRotation <= -AngleMinMax)
        {
            YRotation = -AngleMinMax;
        }

        transform.localEulerAngles = new Vector3(YRotation, 0.0f, 0.0f);
    }
}
