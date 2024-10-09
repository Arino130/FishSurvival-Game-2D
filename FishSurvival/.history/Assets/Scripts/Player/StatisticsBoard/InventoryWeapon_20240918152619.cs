using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public GameObject[] bullets;
    public GameObject heavyHull;
    public GameObject barrel;
    public Sprite[] weaponSkins;
    public Sprite[] weaponBarrelSkins;
    public WeaponEquip weaponSelected;
    private WeaponEquip[] weaponEquipAll;
    private int weaponSelectIndex = 0;
    private void Start()
    {
        weaponEquipAll = new WeaponEquip[]
        {
            new WeaponEquip(WeaponType.WeaponLevel1, "Gun 1", bullets[0].GetComponent<BulletLevel1>().damageValue, bullets[0], weaponSkins[0], weaponBarrelSkins[0]),
            new WeaponEquip(WeaponType.WeaponLevel2, "Gun 2", bullets[1].GetComponent<BulletLevel2>().damageValue, bullets[1], weaponSkins[1], weaponBarrelSkins[1])
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
    void updateSkinWeapon()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = spriteAfterTrigger;
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
        public WeaponEquip(WeaponType weaponType, string fullName, int lossAmount, GameObject bullet, Sprite weaponSkin, Sprite weaponBarrelSkin)
        {
            this.weaponType = weaponType;
            this.fullName = fullName;
            this.lossAmount = lossAmount;
            this.bullet = bullet;
            this.weaponSkin = weaponSkin;
            this.weaponBarrelSkin = weaponBarrelSkin;
        }
    }
    public enum WeaponType
    {
        WeaponLevel1,
        WeaponLevel2
    }
}