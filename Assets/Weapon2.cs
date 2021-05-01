using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon2 : MonoBehaviour
{
    public GameObject pickup;
    GameObject weapon1, weapon2;
    public float collectable;
    private Vector3 target;
    private Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < collectable)
        {
            pickup.SetActive(true);
            if (Input.GetKey(KeyCode.T))
            {
                GameManager.weapon2take = true;
                Destroy(gameObject);
                pickup.SetActive(false);
            }

        }
        else
        {
            pickup.SetActive(false);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectable);
    }
}
