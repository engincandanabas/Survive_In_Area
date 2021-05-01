using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DamagePopUp : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.3f);
    }

}
