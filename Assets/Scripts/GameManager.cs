using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject bullet;
    public GameObject bulletweapon2;
    public GameObject health;
    public GameObject gameover;
    public GameObject weapons2prefab;
    public GameObject weapons1, weapons2,info;
    public static int totalbullet,totalbulletweapon2, totalenemy,totalhealth;
    float randomnumberx;
    float randomnumbery;
    float randomspawn;
    public float timer;
    public static int bulletamount,medkitamount,bulletamount2;
    public Text bulletText,medkitText,scoreText,finalscore,weapon2Text;
    public static int score;
    private int weaponscore;
    private bool weapon2=false;
    public static bool weapon2take = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        score = 0;
        totalbullet = 0;
        totalbulletweapon2 = 0;
        totalenemy = 0;
        totalhealth = 0;
        bulletamount = 10;
        bulletamount2 = 5;
        medkitamount = 1;
        timer = 0;
            
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.health <= 0)
        {
            finalscore.text = "SCORE :" + score.ToString();
            gameover.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            scoreText.text = score.ToString();
            medkitText.text = medkitamount.ToString();
            bulletText.text = bulletamount.ToString();
            weapon2Text.text = bulletamount2.ToString();
            timer += 1 * Time.deltaTime;
            if (timer > 5f)
            {
                if (weapon2take == true)
                {
                    SpawnBullet2();
                }
                SpawnEnemy();
                SpawnBullet();
                SpawnMedkit();
                timer = 0;
            }
            if (score > 5 && weapon2 == false)
            {
                randomnumberx = Random.Range(-69.8f, 25.6f);
                randomnumbery = Random.Range(-15f, 48);
                Instantiate(weapons2prefab, new Vector3(randomnumberx, randomnumbery, 0), Quaternion.identity);
                weapon2 = true;
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                weapons1.SetActive(true);
                weapons2.SetActive(false);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {
                if (weapon2take == true)
                {
                    weapons2.SetActive(true);
                    weapons1.SetActive(false);
                }
            }
            if (Input.GetKey(KeyCode.F1))
            {
                info.SetActive(false);
            }
        }
        
        }
    private void SpawnEnemy()
    {

        print("Total Enemy :" + totalenemy.ToString());
        if (totalenemy < 50)
        {

            randomnumberx = Random.Range(-69.8f, 25.6f);
            randomnumbery = Random.Range(-15f, 48);
            totalenemy += 1;
            Instantiate(enemy, new Vector3(randomnumberx, randomnumbery, 0), Quaternion.identity);
            if (score > 50)
            {
                int r = Random.Range(5, 10);
                randomnumberx = Random.Range(-69.8f, 25.6f);
                randomnumbery = Random.Range(-15f, 48);
                for(int i = 0; i < r; i++)
                {
                    Instantiate(enemy, new Vector3(randomnumberx, randomnumbery, 0), Quaternion.identity);
                    randomnumberx = Random.Range(-69.8f, 25.6f);
                    randomnumbery = Random.Range(-15f, 48);
                }
            }
        }
    }

    
    void SpawnBullet()
    {
        print("Total Bullet :" + totalbullet.ToString());
        if (totalbullet < 15)
        {

            randomnumberx = Random.Range(-69.8f, 25.6f);
            randomnumbery = Random.Range(-15f, 48);
            totalbullet += 1;
            Instantiate(bullet, new Vector3(randomnumberx, randomnumbery, 0), Quaternion.identity);
            
        }

    }
    void SpawnBullet2()
    {
        print("Total Bullet Weapon 2 :" + totalbulletweapon2.ToString());
        if (totalbulletweapon2 < 10)
        {

            randomnumberx = Random.Range(-69.8f, 25.6f);
            randomnumbery = Random.Range(-15f, 48);
            totalbulletweapon2 += 1;
            Instantiate(bulletweapon2, new Vector3(randomnumberx, randomnumbery, 0), Quaternion.identity);

        }

    }
    void SpawnMedkit()
    {
        print("Total Health :" + totalhealth.ToString());
        if (totalhealth < 5)
        {

            print("Total Health :" + totalhealth.ToString());
            randomnumberx = Random.Range(-69.8f, 25.6f);
            randomnumbery = Random.Range(-15f, 48);
            totalhealth += 1;
            Instantiate(health, new Vector3(randomnumberx, randomnumbery, 0), Quaternion.identity);

        }

    }
    public void ReplayGame()
    {
        SceneManager.LoadScene("Game");
    }

}
    
    

