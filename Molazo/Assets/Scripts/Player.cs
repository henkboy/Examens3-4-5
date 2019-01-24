using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Health = 100;

    public float Speed;
    public float MaxWalkSpeed;
    public float MaxSprintSpeed;
    public Rigidbody rb;
    private Vector3 velocityClamped;
    private Vector3 sprintVelocity;

    public float JumpRaycastDistance;
    public bool DoubleJump;
    private bool DoubleJumpUsed = false;
    public float Force;

    public bool HasWeapon;
    public GameObject Weapon;
    public GameObject Bullet;
    public GameObject SpawnPos;
    private GameObject BulletClone;

    void Update()
    {
        Movement();
        Jump();
        Attack();
    }

    void Movement()
    {
        float horInput = Input.GetAxis("Horizontal") * Speed;
        float verInput = Input.GetAxis("Vertical") * Speed;

        Vector3 forceVector = new Vector3(horInput, 0.0f, verInput).normalized * Speed;
        velocityClamped = new Vector3(Mathf.Clamp(rb.velocity.x, -MaxWalkSpeed, MaxWalkSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -MaxWalkSpeed, MaxWalkSpeed));
        sprintVelocity = new Vector3(Mathf.Clamp(rb.velocity.x, -MaxSprintSpeed, MaxSprintSpeed), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -MaxSprintSpeed, MaxSprintSpeed));

        rb.AddRelativeForce(forceVector);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = sprintVelocity;
        }
        else
        {
            rb.velocity = velocityClamped;
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, JumpRaycastDistance))
            {
                rb.AddRelativeForce(Vector3.up * Force);
                DoubleJumpUsed = false;
            }
            else if (DoubleJump == true && DoubleJumpUsed == false)
            {
                rb.AddRelativeForce(Vector3.up * Force);
                DoubleJumpUsed = true;
            }
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (HasWeapon == true)
            {
                BulletClone = Instantiate(Bullet, SpawnPos.transform.position, SpawnPos.transform.rotation);
                BulletClone.GetComponent<Rigidbody>().AddForce(SpawnPos.transform.forward * 500);
            }
        }
    }

    public IEnumerator WeaponTimer(float WeaponTime)
    {
        HasWeapon = true;
        Weapon.SetActive(true);
        yield return new WaitForSeconds(WeaponTime);
        Weapon.SetActive(false);
        HasWeapon = false;
    }
}