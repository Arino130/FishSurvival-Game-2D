using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class InventoryWeapon : MonoBehaviour
{
    public TextMeshProUGUI inventorySelectText;
    public List<WeaponType> weaponTypeAll;
    public WeaponType weaponType;
    void Update()
    {
        string weaponName = weaponType.GetFullName();
        inventorySelectText.text = $"{weaponName}";
    }
    void previousWeapone()
    {
        (ChestsEvent[])System.Enum.GetValues(typeof(ChestsEvent));
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