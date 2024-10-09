using UnityEngine;
using TMPro;
using System.Collections;

public class FishStatistics : MonoBehaviour
{
    public int hearthValue = 100;
    public float timeoutHiddenDamage = 1f;
    public GameObject coin;
    public float forceSpamCoin = 2;
    public int rewardCoinWin;
    public TextMeshProUGUI textDamageValue;
    private bool isShowDamage = false;
    private bool isDead = true;

    public void hitDamage(int value)
    {
        textDamageValue.text = isShowDamage ? "" : $"-{value}";
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
        textDamageValue.text = "";
    }
}