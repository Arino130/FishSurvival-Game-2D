using UnityEngine;

public class FishLevel1Moving : MonoBehaviour
{
    public EnemySpam.SpamPosition spamPosition = null;
    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        spamPosition = value;
    }

    void Update()
    {
        if (spamPosition != null)
        {
            movingFollowPosition();
        }
    }

    void movingFollowPosition()
    {

    }
}