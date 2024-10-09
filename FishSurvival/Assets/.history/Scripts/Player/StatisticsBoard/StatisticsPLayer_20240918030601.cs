using UnityEngine;
using TMPro;
public class StatisticsPlayer : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public GameObject player;
    public int totalCoin = 100;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (player != null)
        {
            textCoinValue.text = $"{totalCoin}";
        }
    }
}