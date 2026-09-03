using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Ammo")]
    public int maxAmmo = 10;
    public int currentAmmo = 10;

    [Header("Fire Rate")]
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Shoot();
        }

        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            Reload();
        }

        void Shoot()
        {
            if (currentAmmo <= 0)
            {
                return;
            }

            if (Time.time < nextFireTime)
            {
                return;
            }

            nextFireTime = Time.time + fireRate;

           
            Vector3 mousePosition = Mouse.current.position.ReadValue();

            mousePosition.z = -Camera.main.transform.position.z;

            Vector3 worldMousePosition =
                Camera.main.ScreenToWorldPoint(mousePosition);

           
            Vector2 direction =
                worldMousePosition - firePoint.position;

           
            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.identity
            );

           
            Bullet bulletScript =
                bullet.GetComponent<Bullet>();

            if (bulletScript != null)
            {
                bulletScript.SetDirection(direction);
            }

            currentAmmo--;
        }

        void Reload()
        {
            currentAmmo = maxAmmo;
        }

    }
}
