using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public WeaponEquip weaponSelected;
    private WeaponEquip[] weaponEquipAll = new WeaponEquip[]
{
    new WeaponEquip(WeaponType.WeaponLevel1, "Gun 1", 1)
};
    private int weaponSelectIndex = 0;
    private void Start()
    {
        weaponSelected = weaponEquipAll[weaponSelectIndex];
    }
    void Update()
    {
        inventorySelectText.text = $"{weaponSelected.fullName}";
    }
    public void previousWeapon()
    {
        if (weaponSelectIndex > 0)
        {
            weaponSelectIndex -= 1;
            weaponSelected = weaponEquipAll[weaponSelectIndex];
        }
    }
    public void nextWeapon()
    {
        if (weaponSelectIndex < (weaponEquipAll.Length - 1))
        {
            weaponSelectIndex += 1;
            weaponSelected = weaponEquipAll[weaponSelectIndex];
        }
    }
    public class WeaponEquip
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