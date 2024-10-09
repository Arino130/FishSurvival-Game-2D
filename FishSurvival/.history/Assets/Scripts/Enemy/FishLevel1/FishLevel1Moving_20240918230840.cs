using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class FishLevel1Moving : MonoBehaviour
{
    public float moveSpeed = 5f;
    public EnemySpam.SpamPosition spamPosition;
    public GameObject damageValueUI;
    private Vector3 vectorPosition;
    private bool isMoving = true;
    private FishStatistics fishStatistics;

    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        spamPosition = value;
    }
    private void Start()
    {
        damageValueUI.transform.rotation = UnityEngine.Quaternion.Euler(0f, 0f, 0f);
        fishStatistics = gameObject.GetComponent<FishStatistics>();
    }

    void Update()
    {
        if (spamPosition != null && isMoving)
        {
            switch (spamPosition)
            {
                case EnemySpam.SpamPosition.Left:
                    vectorPosition = Vector3.right;
                    break;
                case EnemySpam.SpamPosition.Right:
                    vectorPosition = Vector3.left;
                    break;
            }
            movingFollowPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "GroundMaxium")
        {
            Destroy(gameObject);
        }
    }

    void movingFollowPosition()
    {
        transform.position += vectorPosition * moveSpeed * Time.deltaTime;
    }
}