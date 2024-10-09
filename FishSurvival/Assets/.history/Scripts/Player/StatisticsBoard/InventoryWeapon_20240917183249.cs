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
    public enum WeaponType
    {
        WeaponLevel1
    }
}