using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableHealth : MonoBehaviour
{
    public GameObject pickup;
    public float collectable;
    private Vector3 target;
    private Transform player;
    // Start is called before the first frame update
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
            if (Input.GetKey(KeyCode.F))
            {
                GameManager.totalhealth -= 1;
                GameManager.medkitamount += 1;
                print("Medkýt: " + GameManager.medkitamount);
                Destroy(this.gameObject);
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, collectable);
    }
}

