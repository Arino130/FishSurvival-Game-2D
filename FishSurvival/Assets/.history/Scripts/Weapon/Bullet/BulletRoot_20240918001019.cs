using UnityEngine;

public class BulletRoot : MonoBehaviour
{
    public Sprite spriteAfterOpen;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
        onTrigger();
    }

    abstract void onTrigger()
}