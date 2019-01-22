using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float MoveSpeed;
    public float MoveSpeedMinMax;
    public float SprintSpeedMinMax;
    public Rigidbody rb;
    private Vector3 velocityClamped;
    private Vector3 sprintVelocity;

    public float JumpRaycastDistance;
    public bool DoubleJump = true;
    private bool DoubleJumpUsed = false;
    public float Force;

    public bool HasWeapon = false;
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
        float horInput = Input.GetAxis("Horizontal") * MoveSpeed;
        float verInput = Input.GetAxis("Vertical") * MoveSpeed;

        Vector3 forceVector = new Vector3(horInput, 0.0f, verInput).normalized * MoveSpeed;
        velocityClamped = new Vector3(Mathf.Clamp(rb.velocity.x, -MoveSpeedMinMax, MoveSpeedMinMax), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -MoveSpeedMinMax, MoveSpeedMinMax));
        sprintVelocity = new Vector3(Mathf.Clamp(rb.velocity.x, -SprintSpeedMinMax, SprintSpeedMinMax), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -SprintSpeedMinMax, SprintSpeedMinMax));

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
                Weapon.SetActive(true);
                BulletClone = Instantiate(Bullet, SpawnPos.transform.position, SpawnPos.transform.rotation);
                BulletClone.GetComponent<Rigidbody>().AddForce(SpawnPos.transform.forward * 500);
            }
            else
            {
                Weapon.SetActive(false);
            }
        }
    }
}