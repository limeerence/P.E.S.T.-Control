using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oos266_weaponSwitch : MonoBehaviour
{
    public Image weaponImage;
    public Sprite[] weaponSprites;
    [SerializeField] private int curWeapon = 0;

    [SerializeField] GameObject[] weapon;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeGun(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeGun(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeGun(2);
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            changeGun((curWeapon + 1) % 3);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            changeGun(curWeapon == 0 ? 2 : curWeapon - 1);
        }
    }

    private void changeGun(int newWeapon)
    {
        //switch weapon
        weapon[curWeapon].SetActive(false);
        weapon[newWeapon].SetActive(true);

        //switch weapon icon
        weaponImage.sprite = weaponSprites[newWeapon];

        curWeapon = newWeapon;
    }
}
