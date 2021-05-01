using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void SetVolume(float volume) {
        Debug.Log(volume);
        audioMixer.SetFloat("volume",volume);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
