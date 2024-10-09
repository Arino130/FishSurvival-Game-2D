using UnityEngine;

public abstract class BulletRoot : MonoBehaviour
{
    public Sprite spriteAfterTrigger;
    private float bulletSpeed = 20f;
    private bool isMoving = true;
    private GameObject weapon;
    public void updateInfo(GameObject weapon, float bulletSpeed)
    {
        this.weapon = weapon;
        this.bulletSpeed = bulletSpeed;
    }
    private void Update()
    {
        if (isMoving && weapon != null && bulletSpeed != null)
        {
            Rigidbody2D bulletRigidbody = gameObject.GetComponent<Rigidbody2D>();
            Vector2 bulletDirection = weapon.transform.up;
            bulletRigidbody.linearVelocity = bulletDirection * bulletSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = spriteAfterTrigger;
        }
        onTrigger(other);
    }

    protected abstract void onTrigger(Collider2D other);
}