using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UIElements;

public class FishStatistics : MonoBehaviour
{
    public int hearthValue = 100;
    public float timeoutHiddenMessage = 1f;
    public float timeoutEffectDead = 1f;
    public float rotationSpeed = 360f;
    public GameObject coin;
    public float forceSpamCoin = 2;
    public int rewardCoinWin;
    public TextMeshProUGUI textMessageValue;
    private SpriteRenderer spriteRenderer;
    public int coinClaimTimes = 10;
    private bool isDead = false;
    private Vector3 transformPointDead;
    private void Start()
    {
        coinClaimTimes = PlayerPrefs.GetInt("CoinClaimTimes", defaultValue: 10);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isDead)
        {
            transform.position = transformPointDead;
            spriteRenderer.color = Color.red;
        }
    }

    public void hitDamage(int value)
    {
        if (!isDead)
        {
            spriteRenderer.color = Color.red;
            hearthValue = Mathf.Max(0, hearthValue - value);
            StartCoroutine(hiddenDamage());
            if (hearthValue == 0)
            {
                Dead();
            }
        }
    }
    void Dead()
    {
        transformPointDead = transform.position;
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

            transform.Rotate(0, 0, rotationThisFrame);
            yield return null;
        }

        StartCoroutine(showAwardCoin());

        yield return new WaitForSeconds(timeoutEffectDead);
    }
    void spamRewardCoin()
    {
        textMessageValue.text = "+" + (rewardCoinWin * coinClaimTimes);
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
    private IEnumerator showAwardCoin()
    {
        textMessageValue.text = "+" + (rewardCoinWin * coinClaimTimes);
        yield return new WaitForSeconds(timeoutHiddenMessage);
        spamRewardCoin();
    }
    private IEnumerator hiddenDamage()
    {
        yield return new WaitForSeconds(timeoutHiddenMessage);
        spriteRenderer.color = Color.white;
    }
}