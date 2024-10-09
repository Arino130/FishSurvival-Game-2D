using UnityEngine;
using TMPro;
using System.Collections;

public class FishStatistics : MonoBehaviour
{
    public int hearthValue = 100;
    public float timeoutHiddenDamage = 1f;
    public GameObject coin;
    public GameObject pointCollect;
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
        Destroy(gameObject);
    }
    void spamRewardCoin()
    {
        for (int i = 0; i < UnityEngine.Random.Range(1, 4); i++)
        {
            GameObject spawnedHeart = Instantiate(heartItem, transform.position, Quaternion.identity, itemsEventFolder);
            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Rigidbody2D rb = spawnedHeart.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.AddForce(randomDirection * forceSpamCoin, ForceMode2D.Impulse);
            }
        }
    }
    private IEnumerator hiddenDamage()
    {
        yield return new WaitForSeconds(timeoutHiddenDamage);
        textDamageValue.text = "";
    }
}