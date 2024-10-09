using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    public GameObject statisticsPlayerUI;
    private StatisticsPlayer statisticsPlayer;
    public int coinClaimTimes;
    private void Start()
    {
        coinClaimTimes = PlayerPrefs.GetInt("CoinClaimTimes", defaultValue: 0);
        statisticsPlayer = statisticsPlayerUI.GetComponent<StatisticsPlayer>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                statisticsPlayer.AddCoin(coinClaimTimes);
                Destroy(other.gameObject);
                break;
        }
    }
}