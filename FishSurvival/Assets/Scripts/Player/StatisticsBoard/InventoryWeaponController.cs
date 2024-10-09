using UnityEngine;

public class InventoryWeaponController : MonoBehaviour
{
    public InventoryTypeButton inventoryTypeButton = InventoryTypeButton.Previous;
    public GameObject weaponSelect;
    private InventoryWeapon inventoryWeapon;
    private void Start()
    {
        inventoryWeapon = weaponSelect.GetComponent<InventoryWeapon>();
    }
    private void OnMouseDown()
    {
        switch (inventoryTypeButton)
        {
            case InventoryTypeButton.Previous:
                inventoryWeapon.previousWeapon();
                break;
            case InventoryTypeButton.Next:
                inventoryWeapon.nextWeapon();
                break;
        }
    }
    public enum InventoryTypeButton
    {
        Previous,
        Next
    }
}