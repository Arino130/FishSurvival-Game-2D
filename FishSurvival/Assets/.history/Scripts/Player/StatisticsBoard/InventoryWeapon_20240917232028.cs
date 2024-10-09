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
        weaponEquipAll = (WeaponType[])System.Enum.GetValues(typeof(WeaponType));
        weaponSelected = weaponEquipAll[weaponSelectIndex];
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
            weaponSelectIndex -= 1;
            weaponSelected = weaponEquipAll[weaponSelectIndex];
        }
    }
    public void nextWeapon()
    {
        if (weaponTypeIndex < (weaponEquipAll.Length - 1))
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