using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public Sprite[] bullet;
    public WeaponEquip weaponSelected;
    private WeaponEquip[] weaponEquipAll = new WeaponEquip[]
    {
        new WeaponEquip(WeaponType.WeaponLevel1, "Gun 1", 10, bullet[0]),
        new WeaponEquip(WeaponType.WeaponLevel2, "Gun 2", 50, bullet[1])
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
        public WeaponType weaponType;
        public string fullName;
        public int lossAmount;
        public Sprite bullet;
        public WeaponEquip(WeaponType weaponType, string fullName, int lossAmount, Sprite bullet)
        {
            this.weaponType = weaponType;
            this.fullName = fullName;
            this.lossAmount = lossAmount;
            this.bullet = bullet
;
        }
    }
    public enum WeaponType
    {
        WeaponLevel1,
        WeaponLevel2
    }
}