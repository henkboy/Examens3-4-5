using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {

    public GameObject Player;
    public Player playerscript;

    // Level 1
    public GameObject DoubleJumpPowerup;
    public GameObject BlockadeLvl1;
    public List<GameObject> CoinsLvl1;

    // Level 2
    public GameObject Blockade1Lvl2;
    public GameObject Blockade2Lvl2;
    public List<GameObject> CoinsLvl2;


    void OnTriggerEnter(Collider Col)
    {
        CheckProgression();
    }

    public void CheckProgression()
    {
        if (PlayerPrefs.GetInt("Progress") == 0)
        {
            ResetLvl1();
        }
        else if (PlayerPrefs.GetInt("Progress") == 1)
        {
            ResetLvl2();
        }
        else if (PlayerPrefs.GetInt("Progress") == 2)
        {
            ResetLvl3();
        }
    }

    void ResetLvl1()
    {
        Player.transform.position = new Vector3(0, 30, -6);
        playerscript.rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        playerscript.rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerscript.HasWeapon = false;
        playerscript.DoubleJump = false;
        playerscript.CurrentHealth = playerscript.MaxHealth;
        DoubleJumpPowerup.SetActive(true);
        BlockadeLvl1.SetActive(true);
        playerscript.Collectible = 0;
        playerscript.TimeLeft = 180;

        for (int i = 0; i < CoinsLvl1.Count; i++)
        {
            CoinsLvl1[i].SetActive(true);
        }
    }

    void ResetLvl2()
    {
        Player.transform.position = new Vector3(-41, 25, -60);
        playerscript.rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        playerscript.rb.constraints = RigidbodyConstraints.FreezeRotation;
        playerscript.HasWeapon = false;
        playerscript.DoubleJump = false;
        playerscript.CurrentHealth = playerscript.MaxHealth;
        Blockade1Lvl2.SetActive(true);
        Blockade2Lvl2.SetActive(true);
        playerscript.Collectible = 8;
        playerscript.TimeLeft = 180;

        for (int i = 0; i < CoinsLvl2.Count; i++)
        {
            CoinsLvl2[i].SetActive(true);
        }
    }

    void ResetLvl3()
    {

    }
}
