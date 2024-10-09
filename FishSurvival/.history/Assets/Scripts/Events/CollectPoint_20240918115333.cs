using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    public GameObject statisticsPlayerUI;
    private StatisticsPlayer statisticsPlayer;
    private void Start()
    {
        statisticsPlayer = statisticsPlayerUI.GetComponent<StatisticsPlayer>();
    }
}