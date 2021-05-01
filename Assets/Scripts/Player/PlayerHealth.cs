using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int health;
    public Transform healthbar;
    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.localScale = new Vector3(health / 250f, 0.02f, 1f);
        if(GameManager.medkitamount>0 && Input.GetKeyDown(KeyCode.H))
        {
            print("MEDKIT : " + GameManager.medkitamount);
            health = 100;
            GameManager.medkitamount--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet_Enemy"))
        {
            health -= 15;
            Destroy(collision.gameObject);
        }
    }
}
