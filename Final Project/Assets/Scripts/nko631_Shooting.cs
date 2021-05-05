using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nko631_Shooting : MonoBehaviour
{
        public GameObject[] weapons;
        public int currentWeapon = 0;
        private int nrWeapons;

        void Start()
        {
            nrWeapons = weapons.Length;
            SwitchWeapon(currentWeapon); // Set default gun
        }

        void Update()
        {
            for (int i = 1; i <= nrWeapons; i++)
            {
                if (Input.GetKeyDown("" + i))
                {
                    currentWeapon = i - 1;

                    SwitchWeapon(currentWeapon);

                }
            }

        }

        void SwitchWeapon(int index)
        {

            for (int i = 0; i < nrWeapons; i++)
            {
                if (i == index)
                {
                    weapons[i].gameObject.SetActive(true);
                }
                else
                {
                    weapons[i].gameObject.SetActive(false);
                }
            }
        }

    

}
