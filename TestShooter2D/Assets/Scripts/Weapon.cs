using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPref;
    [SerializeField] FixedJoystick fixedJoystick;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform bulletTransform;
    [SerializeField] GameObject weapon;
    public int maxAmmoCount = 50;
    public int minAmmoCount = 0;
    public int currentAmmo;
    float rotateZ;
    public bool canShoot;

    [Header("UI")]
    public Text ammoCountText;

    private void Start() 
    {
        currentAmmo = maxAmmoCount;
        ammoCountText.text = currentAmmo.ToString();    
    }
    
    private void Update() 
    {
        WeaponRotation(fixedJoystick);
    }

    public void WeaponRotation(FixedJoystick fixedJoystick)
    {
        rotateZ = Mathf.Atan2(fixedJoystick.Vertical, fixedJoystick.Horizontal) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ);
        if(fixedJoystick.Horizontal < 0)
        {
            rotation = Quaternion.Euler(180f, 0f, -rotateZ);
        }
        if(rotateZ != 0)
        {
            transform.rotation = rotation;
        }
    }

    public void Shoot()
    {
        if(currentAmmo > minAmmoCount && weapon.activeSelf)
        {
            Instantiate(bulletPref, bulletTransform.position, transform.rotation);
            currentAmmo--;
            ammoCountText.text = currentAmmo.ToString(); 
        }
    }

}
