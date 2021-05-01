using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public float speed;
    private SpriteRenderer sp;
    public Transform[] weapon;
    private Animator anim;
    private bool flip=false;
    public static bool weaponbool=false;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerHealth.health > 0)
        {
            weapon[0].transform.position = transform.position + new Vector3(0, 0.5f, 0);
            weapon[1].transform.position = transform.position + new Vector3(0, 0.5f, 0);
            if (Input.GetKey(KeyCode.A))
            {
                anim.SetBool("isRun", true);
                pos = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
                float x = Mathf.Clamp(pos.x, -69.8f, 25.6f);
                transform.position = new Vector3(x, pos.y, 0);

                if (!flip)
                {
                    sp.flipX = true;
                    flip = true;
                    weaponbool = true;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {

                anim.SetBool("isRun", true);
                pos = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
                float x = Mathf.Clamp(pos.x, -69.8f, 25.6f);
                transform.position = new Vector3(x, pos.y, 0);
                //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
                if (flip)
                {
                    sp.flipX = false;
                    flip = false;
                    weaponbool = false;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {

                anim.SetBool("isRun", true);
                pos = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
                float y = Mathf.Clamp(pos.y, -15f, 48);
                transform.position = new Vector3(pos.x, y, 0);
                //transform.position += new Vector3(0, speed * Time.deltaTime, 0);

            }
            if (Input.GetKey(KeyCode.S))
            {
                anim.SetBool("isRun", true);
                pos = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
                float y = Mathf.Clamp(pos.y, -15f, 48);
                transform.position = new Vector3(pos.x, y, 0);
                //transform.position += new Vector3(0, -speed * Time.deltaTime, 0);

            }
            if (!Input.anyKey)
            {
                anim.SetBool("isRun", false);
            }
            //anim.SetBool("isRun", false);    


        }


    }
}
