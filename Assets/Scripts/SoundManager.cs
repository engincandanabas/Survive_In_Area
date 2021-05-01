using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource auidosrc;
    public static AudioClip shoot;
    public static AudioClip shoot2;
    void Start()
    {
        auidosrc = GetComponent<AudioSource>();
        shoot = Resources.Load<AudioClip>("shoot_sound");
        shoot2 = Resources.Load<AudioClip>("shoot_sound2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound()
    {
        auidosrc.PlayOneShot(shoot);
    }
    public static void PlaySound2()
    {
        auidosrc.PlayOneShot(shoot2);
    }
}
