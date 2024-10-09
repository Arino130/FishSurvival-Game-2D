using UnityEngine;

public class FishLevel1Moving : MonoBehaviour
{
    public float moveSpeed = 1f;
    public EnemySpam.SpamPosition spamPosition = null;
    private float positionRotation;
    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        spamPosition = value;
    }

    void Update()
    {
        if (spamPosition != null)
        {
            switch (spamPosition)
            {
                case SpamPosition.LeftTop:
                    spamPosition = 90;
                    break;
            }
            movingFollowPosition();
        }
    }

    void movingFollowPosition()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}