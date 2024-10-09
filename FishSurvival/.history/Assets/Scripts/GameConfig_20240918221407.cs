using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public int coinInit = 0;
    public int coinClaimTimes = 10;
    private void Start()
    {
        PlayerPrefs.SetInt("CoinClaimTimes", coinClaimTimes);
    }
}