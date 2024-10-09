using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class FishLevel1Moving : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float duration = 2f;
    private Vector3 initialScale;
    public float moveSpeed = 5f;
    public EnemySpam.SpamPosition spamPosition;
    private Vector3 vectorPosition;
    private bool isMoving = true;

    private void Start()
    {
        initialScale = transform.localScale;
    }
    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        spamPosition = value;
    }

    void Update()
    {
        if (spamPosition != null && isMoving)
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
        if (LayerMask.LayerToName(other.gameObject.layer) == "Bullet")
        {
            switch (other.gameObject.tag)
            {
                case "BulletLevel1":
                    isMoving = false;
                    break;
                default:

                    break;
            }
        }
    }
}