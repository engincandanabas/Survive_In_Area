using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentBox : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("Bullet_Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
    
}
