using UnityEngine;

public abstract class BulletRoot : MonoBehaviour
{
    public Sprite spriteAfterTrigger;
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