using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Looking at player
    public Transform Players;
    private Vector3 LookPos;
    private Quaternion Rotation;
    private int Speed = 10;

    // shooting
    public int Bullets;
    public GameObject Bullet;
    public GameObject SpawnPos;
    private GameObject BulletClone;

    // Health
    public float CurrentHealth;
    public float MaxHealth;
    public Slider healthSlider;
    public GameObject BossUI;

    public GameObject Weapon;
    public GameObject Story3;

    void Start()
    {
        StartCoroutine(Shooting());
    }

    void Update()
    {
        LookPos = Players.position - transform.position;
        LookPos.y = 0;
        Rotation = Quaternion.LookRotation(LookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, Rotation, Time.deltaTime * Speed);

        Weapon.transform.LookAt(Players);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            for (int i = 0; i < Bullets; i++)
            {
                yield return new WaitForSeconds(1.5f);
                BulletClone = Instantiate(Bullet, SpawnPos.transform.position, SpawnPos.transform.rotation);
                BulletClone.GetComponent<Rigidbody>().AddForce(SpawnPos.transform.forward * 500);
            }
            yield return new WaitForSeconds(5);
        }
    }

    public void Health(int amount)
    {
        CurrentHealth -= amount;
        healthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            BossUI.SetActive(false);
            Story3.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameObject.SetActive(false);
        }
    }
}