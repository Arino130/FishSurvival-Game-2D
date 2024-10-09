using UnityEngine;
using TMPro;
public class TotalCoin : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (player != null)
        {
            textCoinValue.text =
        }
    }
}