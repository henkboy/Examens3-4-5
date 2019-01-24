using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHealth : MonoBehaviour {

    public float Health;

    void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
