using UnityEngine;

public abstract class BulletRoot : MonoBehaviour
{
    public Sprite spriteAfterTrigger;
    private float bulletSpeed = 20f;
    private GameObject weapon;
    private Vector2 bulletDirection;
    private Rigidbody2D bulletRigidbody;
    public void updateInfo(GameObject weapon, float bulletSpeed)
    {
        this.weapon = weapon;
        this.bulletSpeed = bulletSpeed;
        bulletRigidbody = gameObject.GetComponent<Rigidbody2D>();
        bulletDirection = weapon.transform.up;
    }
    private void Update()
    {
        if (weapon != null && bulletSpeed != null)
        {
            bulletRigidbody.linearVelocity = bulletDirection * bulletSpeed;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy")
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = spriteAfterTrigger;
            }
            bulletSpeed = 0;
        }
        else if (if (LayerMask.LayerToName(other.gameObject.layer) == "Ground"))
        {
            Destroy(gameObject);
        }
        onTrigger(other);
    }

    protected abstract void onTrigger(Collider2D other);
}