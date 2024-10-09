using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        Vector3 MouseWorldPosition = Camera.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        transform.LookAt(MouseWorldPosition);
        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        // Amout to move
        float inputX = Input.GetAxis("Horizontal") * 0.5f *

        Time.deltaTime;
        float inputY = Input.GetAxis("Vertical") * 0.5f * Time.deltaTime;
        // Move the Player
        transform.Translate(Vector3.forward * inputX);
        transform.Translate(Vector3.left * inputY);
    }
}