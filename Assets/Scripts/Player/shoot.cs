using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    Vector3 cameraInitialPosition;
    public float shakeMagnetude = 0.05f, shakeTime = 0.5f;
    private Camera mainCamera;
    public Transform firePoint;
    public GameObject bulletprefab,bulletprefab2,player;
    private Animator anim;
    private Camera cam;
    Vector3 target;
    private Rigidbody2D rb;
    public float bulletforce = 20f;
    public GameObject weapon1, weapon2;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera=Camera.main;
        cam = Camera.main;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        target = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Input.GetButtonDown("Fire1"))
        {
            if (GameManager.bulletamount > 0 )
            {
                StartCoroutine(ShootingWeapon1());
                
            }
            if (GameManager.bulletamount2 > 0)
            {
                StartCoroutine(ShootingWeapon2());

            }
        }

    }
    IEnumerator ShootingWeapon1()
    {
        if (weapon1.activeInHierarchy == true)
        {
            SoundManager.PlaySound();
            GameManager.bulletamount -= 1;
            anim.SetBool("Shoot", true);
            StartCoroutine(WaitAnimation());
            GameObject bullet = Instantiate(bulletprefab, firePoint.position, Quaternion.Euler(0, 0, -90));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletforce, ForceMode2D.Impulse);
            ShakeIt();
            yield return new WaitForSeconds(3);
            Destroy(bullet);
        }
    }
    IEnumerator ShootingWeapon2()
    {
        
        if (weapon2.activeInHierarchy == true)
        {
            SoundManager.PlaySound2();
            GameManager.bulletamount2 -= 1;
            anim.SetBool("Shoot", true);
            StartCoroutine(WaitAnimation());
            GameObject bullet2 = Instantiate(bulletprefab2, firePoint.position, Quaternion.Euler(0, 0, -90));
            Rigidbody2D rb = bullet2.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletforce, ForceMode2D.Impulse);
            ShakeIt();
            yield return new WaitForSeconds(3);
            Destroy(bullet2);
        }

    }
    IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(0.3f);
        anim.SetBool("Shoot",false);
    }
    
    public void ShakeIt()
    {
        cameraInitialPosition = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        float cameraShakingOffsetY = Random.value * shakeMagnetude * 2 - shakeMagnetude;
        Vector3 cameraIntermadiatePosition = mainCamera.transform.position;
        cameraIntermadiatePosition.x += cameraShakingOffsetX;
        cameraIntermadiatePosition.y += cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermadiatePosition;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPosition;
    }
    
}
