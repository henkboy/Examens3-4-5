using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Health
    public float CurrentHealth;
    public float MaxHealth;
    public Slider healthSlider;
    public GameObject Restart;

    // Movement
    private float Speed;
    public float WalkSpeed;
    public float SprintSpeed;
    public Rigidbody rb;

    // Jumping
    public float JumpRaycastDistance;
    public bool DoubleJump;
    private bool DoubleJumpUsed = false;
    public float Force;

    // Attacking
    public bool HasWeapon;
    public GameObject Weapon;
    public GameObject Bullet;
    public GameObject SpawnPos;
    private GameObject BulletClone;
    public GameObject EndBoss;

    // Collectibles
    public Text Collectibles;
    private int m_Collectible;
    public int Collectible
    {
        get { return m_Collectible; }
        set
        {
            if (m_Collectible == value)
                return;

            m_Collectible = value;
            Collectibles.text = "Collectibles: " + m_Collectible + "/8" ;
        }
    }

    // Timer
    public Text TimerText;
    public float TimeLeft;
    public GameObject Floor;
    public bool NeedTimer = true;

    private AudioSource JumpSound;
    private Animator Anim;

    void Start()
    {
        CurrentHealth = MaxHealth;
        Anim = GetComponent<Animator>();
        JumpSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        Movement();
        Jump();
        Attack();
        Timer();


    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button8))
        {
            Speed = SprintSpeed;
        }
        else
        {
            Speed = WalkSpeed;
        }

        float translationX = Input.GetAxis("Horizontal") * Speed;
        float translationZ = Input.GetAxis("Vertical") * Speed;

        translationX *= Time.deltaTime;
        translationZ *= Time.deltaTime;

        transform.Translate(translationX, 0, translationZ);



        // Animations
        float MoveVertical = Input.GetAxis("Vertical");
        Anim.SetFloat("Vertical", MoveVertical);
        float MoveHorizontal = Input.GetAxis("Horizontal");
        Anim.SetFloat("Horizontal", MoveHorizontal);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            RaycastHit hit;

            if (Physics.Raycast(this.transform.position, Vector3.down, out hit, JumpRaycastDistance))
            {
                rb.AddRelativeForce(Vector3.up * Force);
                DoubleJumpUsed = false;
                JumpSound.Play();
            }
            else if (DoubleJump == true && DoubleJumpUsed == false)
            {
                rb.AddRelativeForce(Vector3.up * Force);
                DoubleJumpUsed = true;
                JumpSound.Play();
            }
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            if (HasWeapon == true)
            {
                BulletClone = Instantiate(Bullet, SpawnPos.transform.position, SpawnPos.transform.rotation);
                BulletClone.GetComponent<Rigidbody>().AddForce(SpawnPos.transform.forward * 500);
            }
            else
            {
                RaycastHit hit;
                Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward);
                Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name == "EndBoss")
                    {
                        EndBoss.GetComponent<Enemy>().Health(5);
                    }
                }
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

    public void Health(int amount)
    {
        CurrentHealth -= amount;
        healthSlider.value = CurrentHealth;

        if (CurrentHealth <= 0)
        {
            healthSlider.value = MaxHealth;
            Restart.gameObject.GetComponent<Reset>().CheckProgression();
        }
    }

    void Timer()
    {
        if (NeedTimer == true)
        {
            TimeLeft -= Time.deltaTime;
            float Minutes = Mathf.Floor(TimeLeft / 60);
            float Seconds = Mathf.Floor(TimeLeft) % 60;
            string seconds = Seconds.ToString();
            if (Seconds < 10)
            {
                seconds = "0" + Seconds.ToString();
            }
            TimerText.text = "Time: " + Minutes + ":" + seconds;
            if (Minutes == 0 && Seconds == 0)
            {
                Floor.GetComponent<Reset>().CheckProgression();
            }
        }
    }
}