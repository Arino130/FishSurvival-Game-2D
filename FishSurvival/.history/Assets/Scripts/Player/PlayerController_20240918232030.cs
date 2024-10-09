using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private InventoryWeapon inventoryWeapon;
    void Update()
    {
        Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(MouseWorldPosition);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.y - 180f));
        onPressKey();
    }
    void onPressKey()
    {
        if (Input.GetKey(KeyCode.A))
        {
            inventoryWeapon.previousWeapon();
        }
        if (Input.GetKey(KeyCode.S))
        {
            inventoryWeapon.nextWeapon();
        }
    }
}