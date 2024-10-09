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

    public void updateSpamPosition(EnemySpam.SpamPosition value)
    {
        spamPosition = value;
    }
    private void Start()
    {
        damageValueUI.transform.rotation = UnityEngine.Quaternion.Euler(0f, 0f, 0f);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log($"Oke");
        if (LayerMask.LayerToName(other.gameObject.layer) == "GroundMaxium")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        UnityEngine.Debug.Log($"Oke");
    }

    void movingFollowPosition()
    {
        transform.position += vectorPosition * moveSpeed * Time.deltaTime;
    }
}