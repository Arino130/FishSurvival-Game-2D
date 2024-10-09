using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public WeaponType weaponType;
    private WeaponType[] weaponTypeAll;
    private int weaponTypeIndex = 0;
    private void Start()
    {
        weaponTypeAll = (WeaponType[])System.Enum.GetValues(typeof(WeaponType));
        weaponType = weaponTypeAll[weaponTypeIndex];
    }
    void Update()
    {
        string weaponName = weaponType.GetFullName();
        inventorySelectText.text = $"{weaponName}";
    }
    public void previousWeapon()
    {
        if (weaponTypeIndex > 0)
        {
            weaponTypeIndex -= 1;
            weaponType = weaponTypeAll[weaponTypeIndex];
        }
    }
    public void nextWeapon()
    {
        if (weaponTypeIndex < (weaponTypeAll.Length - 1))
        {
            weaponTypeIndex += 1;
            weaponType = weaponTypeAll[weaponTypeIndex];
        }
    }
    public class WeaponChoose
    {
        WeaponType weaponType;
        string fullName;
        int lossAmount;
    }
    public enum WeaponType
    {
        WeaponLevel1,
        WeaponLevel2
    }
}