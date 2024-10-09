using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public GameObject[] bullet;
    public WeaponEquip weaponSelected;
    private WeaponEquip[] weaponEquipAll;
    public WeaponType weaponType;
    private int weaponSelectIndex = 0;
    private void Start()
    {
        weaponEquipAll = new WeaponEquip[]
        {
            new WeaponEquip(WeaponType.WeaponLevel1, "Gun 1", bullet[0].GetComponent<BulletLevel1>().damageValue, bullet[0]),
            new WeaponEquip(WeaponType.WeaponLevel2, "Gun 2", bullet[1].GetComponent<BulletLevel2>().damageValue, bullet[1])
        };
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
        public GameObject bullet;
        public Sprite weaponSkin;
        public Sprite weaponBarrelSkin;
        public WeaponEquip(WeaponType weaponType, string fullName, int lossAmount, GameObject bullet)
        {
            this.weaponType = weaponType;
            this.fullName = fullName;
            this.lossAmount = lossAmount;
            this.bullet = bullet;
        }
    }
    public enum WeaponType
    {
        WeaponLevel1,
        WeaponLevel2
    }
}