using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

    public float WeaponTime;

    void OnTriggerEnter(Collider Col)
    {
        if (gameObject.name == "DoubleJumpPowerup")
        {
            Col.GetComponent<Player>().DoubleJump = true;
            gameObject.SetActive(false);
        }

        if(gameObject.name == "WeaponPowerup")
        {
            StartCoroutine(Col.GetComponent<Player>().WeaponTimer(WeaponTime:WeaponTime));
        }
    }
}
