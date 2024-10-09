using UnityEngine;
using TMPro;
using System.Collections;

public class FishStatistics : MonoBehaviour
{
    public int hearthValue = 100;
    public float timeoutHiddenDamage = 1f;
    public float timeoutEffectDead = 1f;
    public float rotationSpeed = 360f;
    public GameObject coin;
    public float forceSpamCoin = 2;
    public int rewardCoinWin;
    public TextMeshProUGUI textDamageValue;
    private bool isDead = true;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void hitDamage(int value)
    {
        spriteRenderer.color = Color.red;
        hearthValue = Mathf.Max(0, hearthValue - value);
        StartCoroutine(hiddenDamage());
        if (hearthValue == 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        isDead = true;
        StartCoroutine(effectDead());
    }
    private IEnumerator effectDead()
    {
        float rotatedAngle = 0f;

        while (rotatedAngle < 360f)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            rotatedAngle += rotationThisFrame;

            if (rotatedAngle > 360f)
            {
                rotationThisFrame -= (rotatedAngle - 360f);
            }

            yield return null;
        }

        yield return new WaitForSeconds(timeoutEffectDead);

        spamRewardCoin();
    }
    void spamRewardCoin()
    {
        for (int i = 0; i < rewardCoinWin; i++)
        {
            GameObject spawnedHeart = Instantiate(coin, transform.position, Quaternion.identity);
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Rigidbody2D rb = spawnedHeart.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(randomDirection * forceSpamCoin, ForceMode2D.Impulse);
            }
        }
        Destroy(gameObject);
    }
    private IEnumerator hiddenDamage()
    {
        yield return new WaitForSeconds(timeoutHiddenDamage);
        spriteRenderer.color = Color.white;
    }
}