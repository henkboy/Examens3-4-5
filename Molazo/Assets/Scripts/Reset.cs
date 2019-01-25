using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public GameObject Player;
    public Player playerscript;

    // Level 1
    public GameObject DoubleJumpPowerup;
    public GameObject BlockadeLvl1;

    // Level 2
    public GameObject Blockade1Lvl2;
    public GameObject Blockade2Lvl2;


    void OnTriggerEnter(Collider Col)
    {
        if(0 == 0)
        {
            ResetLvl1();
        }
    }

    void ResetLvl1()
    {
        Player.transform.position = new Vector3(0, 30, -6);
        playerscript.rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        playerscript.rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerscript.HasWeapon = false;
        playerscript.DoubleJump = false;
        playerscript.Health = 100;
        DoubleJumpPowerup.SetActive(true);
        BlockadeLvl1.SetActive(true); 
    }

    void ResetLvl2()
    {
        Player.transform.position = new Vector3(-41, 25, -60);
        playerscript.rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        playerscript.rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerscript.HasWeapon = false;
        playerscript.DoubleJump = false;
        playerscript.Health = 100;
        Blockade1Lvl2.SetActive(true);
        Blockade2Lvl2.SetActive(true);
    }
}
