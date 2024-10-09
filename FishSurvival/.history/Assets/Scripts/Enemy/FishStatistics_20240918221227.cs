using UnityEngine;
using TMPro;
using System.Collections;

public class FishStatistics : MonoBehaviour
{
    public int hearthValue = 100;
    public float timeoutHiddenMessage = 1f;
    public float timeoutEffectDead = 1f;
    public float rotationSpeed = 340f;
    public GameObject coin;
    public float forceSpamCoin = 2;
    public int rewardCoinWin;
    public TextMeshProUGUI textMessageValue;
    private bool isDead = true;
    private SpriteRenderer spriteRenderer;
    public int coinClaimTimes = 10;
    private void Start()
    {
        coinClaimTimes = PlayerPrefs.GetInt("CoinClaimTimes");
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

        while (rotatedAngle < 340f)
        {
            float rotationThisFrame = rotationSpeed * Time.deltaTime;
            rotatedAngle += rotationThisFrame;

            if (rotatedAngle > 340f)
            {
                rotationThisFrame -= (rotatedAngle - 340f);
            }

            transform.Rotate(0, 0, rotationThisFrame);

            yield return null;
        }

        spamRewardCoin();

        yield return new WaitForSeconds(timeoutEffectDead);
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
        textMessageValue.text = "+" + (rewardCoinWin * coinClaimTimes);
        Destroy(gameObject);
    }
    private IEnumerator hiddenDamage()
    {
        yield return new WaitForSeconds(timeoutHiddenMessage);
        spriteRenderer.color = Color.white;
    }
}