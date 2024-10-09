using UnityEngine;
using TMPro;
public class StatisticsPlayer : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public int totalCoin = 100;
    private void Update()
    {
        if (player != null)
        {
            textCoinValue.text = $"{totalCoin}";
        }
    }
}