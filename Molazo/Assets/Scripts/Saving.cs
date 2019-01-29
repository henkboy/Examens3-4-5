using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour
{
    public GameObject Floor;
    public Player Player;
    AudioSource CoinSound;

    void Start()
    {
        Floor.GetComponent<Reset>().CheckProgression();
        CoinSound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision Col)
    {
        if (gameObject.name == "FinishLvl1" && Player.Collectible == 8)
        {
            PlayerPrefs.SetInt("Progress", 1);
            Floor.GetComponent<Reset>().CheckProgression();
        }
        else if (gameObject.name == "FinishLvl2" && Player.Collectible == 16)
        {
            PlayerPrefs.SetInt("Progress", 2);
            Floor.GetComponent<Reset>().CheckProgression();
        }
    }

    public void CoinSounds()
    {
        CoinSound.Play();
    }
}