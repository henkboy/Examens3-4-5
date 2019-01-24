using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    void Start()
    {
        StartCoroutine(Timer());
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.name == "Blockade")
        {
            Col.gameObject.GetComponent<WallHealth>().Health--;
        }
        Destroy(gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
