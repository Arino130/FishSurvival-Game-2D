using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position);
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg / 8;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}