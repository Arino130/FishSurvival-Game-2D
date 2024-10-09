using UnityEngine;
using TMPro;
public class StatisticsPlayer : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public GameObject gameConfigObj;
    private GameConfig gameConfig;
    public int totalCoin = 0;

    private void Start()
    {
        gameConfig = gameConfigObj.GetComponent<GameConfig>();
        if (gameConfig != null)
        {
            totalCoin = gameConfig.coinInit;
        }
    }
    private void Update()
    {
        textCoinValue.text = $"{totalCoin}";
    }
    public void UsingCoin(int value)
    {
        totalCoin -= value;
    }

    public void AddCoin(int value)
    {
        totalCoin += value;
    }
}