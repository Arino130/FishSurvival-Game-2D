using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class FishLevel1Moving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public EnemySpam.SpamPosition spamPosition;
    private Vector3 vectorPosition;
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
                    vectorPosition = Vector3.Right;
                    break;
            }
            movingFollowPosition();
        }
    }

    void movingFollowPosition()
    {
        transform.position += vectorPosition * moveSpeed * Time.deltaTime;
    }
}