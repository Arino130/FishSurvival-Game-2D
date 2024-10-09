using UnityEngine;
using System.Collections;

public abstract class BulletRoot : MonoBehaviour
{
    public Sprite spriteAfterTrigger;
    public float timeoutHiddenNet = 2f;
    private float bulletSpeed = 20f;
    private GameObject weapon;
    private Vector2 bulletDirection;
    private Rigidbody2D bulletRigidbody;
    public bool isDamage = true;
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
            if (other.gameObject.GetComponent<FishStatistics>()?.isDead == false)
            {
                StartCoroutine(hiddenNet());
            }
            onTrigger(other);
            isDamage = false;
        }
        else if (LayerMask.LayerToName(other.gameObject.layer) == "Ground")
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator hiddenNet()
    {
        yield return new WaitForSeconds(timeoutHiddenNet);
        Destroy(gameObject);
    }

    protected abstract void onTrigger(Collider2D other);
}