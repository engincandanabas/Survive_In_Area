using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class enemyai : MonoBehaviour
{
    private Animator anim;
    private float speed;
    public float lineOfSite;
    public float fireRate=1f;
    private float nextfiretime;
    public float shootingRange;
    private Transform player;
    private int can = 100;
    private bool flip = false;
    private SpriteRenderer sp;
    public Transform health,weapon;
    private Vector3 target;
    public GameObject bulletprefab;
    public Transform firePoint;
    public GameObject blood,damagepopup;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        speed = Random.Range(2.4f, 2.8f);
        sp = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 difference = target - weapon.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        weapon.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        health.localScale = new Vector3(can/250f, 0.02f,1f);
        if (can <= 0)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.totalenemy -= 1;
            GameManager.score += 3;
        }
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if (transform.position.x-player.position.x < 0)
        {
            if (flip)
            {
                sp.flipX = false;
                flip = false;
            }
        }
        else
        {
            if (!flip)
            {
                sp.flipX = true;
                flip = true;
            }
        }
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer>shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            anim.SetBool("isRun", true);
        }
        else if (distanceFromPlayer<=shootingRange && nextfiretime<Time.time)
        {
            GameObject bullet = Instantiate(bulletprefab, firePoint.position, Quaternion.Euler(0, 0, -90));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * 20, ForceMode2D.Impulse);
            nextfiretime = Time.time + fireRate;
        }
        else
        {
            anim.SetBool("isRun", false);
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            int r = Random.Range(17, 25);
            can -= r;
            GameObject points=Instantiate(damagepopup, transform.position+new Vector3(0,3f,0), Quaternion.identity);
            points.transform.GetChild(0).GetComponent<TextMeshPro>().text = r.ToString();

            GameManager.score += 1;
        }
        if (collision.gameObject.CompareTag("Bullet_Weapon2"))
        {
            Destroy(collision.gameObject);
            int r = Random.Range(80, 100);
            can -= r;
            GameObject points = Instantiate(damagepopup, transform.position + new Vector3(0, 3f, 0), Quaternion.identity);
            points.transform.GetChild(0).GetComponent<TextMeshPro>().text = r.ToString();

            GameManager.score += 1;
        }
    }
    
}
