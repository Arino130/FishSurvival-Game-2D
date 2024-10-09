using UnityEngine;
using TMPro;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public WeaponType weaponType;
    void Update()
    {
        string weaponName = weaponType.GetFullName();
        inventorySelectText.text = $"{weaponName}";
    }
    void previousWeapone()
    {

    }
    void nextWeapone()
    {

    }
    public enum WeaponType
    {
        WeaponLevel1,
        WeaponLevel2
    }
}