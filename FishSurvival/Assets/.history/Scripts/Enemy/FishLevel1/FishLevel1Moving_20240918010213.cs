using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class FishLevel1Moving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public EnemySpam.SpamPosition spamPosition;
    private GameObject damageValueUI;
    private Vector3 vectorPosition;
    private bool isMoving = true;

    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        spamPosition = value;
    }
    private void Start()
    {
        damageValueUI = fishItem.transform.rotation = UnityEngine.Quaternion.Euler(0f, 0f, 00f);
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
                    break;
                default:

                    break;
            }
        }
    }
}