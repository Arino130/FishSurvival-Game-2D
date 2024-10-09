using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Debug.Log($"{Input.mousePosition.y}");
        Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(MouseWorldPosition);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.y - 180f));
    }
}