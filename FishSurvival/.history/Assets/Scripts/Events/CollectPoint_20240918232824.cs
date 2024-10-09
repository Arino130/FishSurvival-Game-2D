using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    public GameObject statisticsPlayerUI;
    private StatisticsPlayer statisticsPlayer;
    public int coinClaimTimes = 10;
    private void Start()
    {
        coinClaimTimes = PlayerPrefs.GetInt("CoinClaimTimes", defaultValue: 10);
        statisticsPlayer = statisticsPlayerUI.GetComponent<StatisticsPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"{coinClaimTimes}");
        switch (other.gameObject.tag)
        {
            case "Coin":
                statisticsPlayer.AddCoin(coinClaimTimes);
                Destroy(other.gameObject);
                break;
        }
    }
}