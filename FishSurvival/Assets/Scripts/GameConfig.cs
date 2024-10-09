using UnityEngine;

public class GameConfig : MonoBehaviour
{
    public int coinInit = 0;
    public int coinClaimTimes;
    private void Start()
    {
        PlayerPrefs.SetInt("CoinClaimTimes", coinClaimTimes);
        PlayerPrefs.Save();
    }
}