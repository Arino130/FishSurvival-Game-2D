using UnityEngine;

public class InventoryWeaponController : MonoBehaviour
{
    public InventoryTypeButton inventoryTypeButton = InventoryTypeButton.Previous;
    private void OnMouseDown()
    {

    }
    public enum InventoryTypeButton
    {
        Previous,
        Next
    }
}