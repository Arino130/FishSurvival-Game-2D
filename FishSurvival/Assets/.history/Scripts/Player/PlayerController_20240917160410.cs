using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        Vector2 direction = (mousePosition - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * (Mathf.Rad2Deg / 5);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}