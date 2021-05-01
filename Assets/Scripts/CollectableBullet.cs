using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableBullet : MonoBehaviour
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
                GameManager.bulletamount += 15;
                GameManager.totalbullet -= 1;
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
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collectable);
    }
}
