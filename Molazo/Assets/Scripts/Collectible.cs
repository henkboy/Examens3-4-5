using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject Player;
    public GameObject LvlManager;

    void Start()
    {
        Player = FindObjectOfType<Player>().gameObject;
        LvlManager = FindObjectOfType<Saving>().gameObject;
    }

    void OnTriggerEnter(Collider Col)
    {
        Player.GetComponent<Player>().Collectible++;
        LvlManager.gameObject.GetComponent<Saving>().CoinSounds();
        gameObject.SetActive(false);
    }
}
