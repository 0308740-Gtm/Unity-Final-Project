using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{

    public PlayerShooting playerShooting;
    public TextMeshProUGUI ammoText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text =
            "AMMO: " +
            playerShooting.currentAmmo +
            " / " +
            playerShooting.maxAmmo;

    }
}
