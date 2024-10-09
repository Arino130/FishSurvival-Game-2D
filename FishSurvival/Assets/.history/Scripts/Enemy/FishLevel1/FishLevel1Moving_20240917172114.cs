using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class FishLevel1Moving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public EnemySpam.SpamPosition spamPosition;
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
                case EnemySpam.SpamPosition.LeftTop:
                    positionRotation = 90f;
                    break;
            }
            movingFollowPosition();
        }
    }

    void movingFollowPosition()
    {
        Vector3 direction = (positionRotation - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}