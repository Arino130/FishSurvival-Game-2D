using UnityEngine;
using TMPro;
public class StatisticsPlayer : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public int totalCoin = 100;
    private void Update()
    {
        textCoinValue.text = $"{totalCoin}";
    }
    public void usingCoin(int value)
    {
        totalCoin -= value;
    }
}