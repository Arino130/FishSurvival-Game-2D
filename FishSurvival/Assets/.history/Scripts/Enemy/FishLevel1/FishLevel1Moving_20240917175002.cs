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
                    vectorPosition = Vector3.right;
                    break;
            }
            movingFollowPosition();
        }
    }

    void movingFollowPosition()
    {
        transform.position += vectorPosition * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log($"2");
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        UnityEngine.Debug.Log($"3");
    }
}