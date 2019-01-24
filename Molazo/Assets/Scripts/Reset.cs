using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public GameObject Player;
    public Player playerscript;
    // Level 1
    public GameObject DoubleJumpPowerup;
    public GameObject Blockade;

    void OnTriggerEnter(Collider Col)
    {
        if(gameObject.name == "FloorLvl1")
        {
            ResetLvl1();
        }
    }

    void ResetLvl1()
    {
        Player.transform.position = new Vector3(0, 30, -6);
        //Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        //Player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        playerscript.rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        playerscript.rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerscript.HasWeapon = false;
        playerscript.DoubleJump = false;
        playerscript.Health = 100;
        DoubleJumpPowerup.SetActive(true);
        Blockade.SetActive(true);
        
    }
}
