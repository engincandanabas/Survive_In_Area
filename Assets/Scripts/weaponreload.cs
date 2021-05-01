using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class weaponreload : MonoBehaviour
{
    public Text bulletText;

    private int maxbullet, currentammo,defaultammo=10;
    private bool reload;
    // Start is called before the first frame update
    void Start()
    {
        currentammo = defaultammo;
        maxbullet = GameManager.bulletamount;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (currentammo < 0)
        {
            reload = true;
        }
    }
    public void shoot()
    {
        currentammo--;
        bulletText.text = currentammo + "/" + (maxbullet - 10);
    }
    public  void reloadgun()
    {
        Debug.Log("Reload");
        currentammo = defaultammo;
        
    }
}
