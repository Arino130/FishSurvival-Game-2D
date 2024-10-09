using UnityEngine;

public class FishLevel1Moving : MonoBehaviour
{
    public EnemySpam.SpamPosition spamPosition;
    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        Debug.Log($"oke");
        spamPosition = value;
    }
}