using UnityEngine;

public class ShotController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log($"Oke");
        }
    }
}