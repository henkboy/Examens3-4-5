using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private GameObject Player;
    private Player playerscript;
    public int Damage;

    void Start()
    {
        StartCoroutine(Timer());
        playerscript = FindObjectOfType<Player>();
        Player = FindObjectOfType<Player>().gameObject;
    }

    void OnCollisionEnter(Collision Col)
    {
        if (Col.gameObject.name == "Blockade")
        {
            Col.gameObject.GetComponent<WallHealth>().Health--;
        }
        else if (Col.gameObject.name == "Player")
        {
            playerscript.Health(Damage);
            Player.GetComponent<Rigidbody>().AddRelativeForce(0, 0, 1000);

        }
        Destroy(gameObject);
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
