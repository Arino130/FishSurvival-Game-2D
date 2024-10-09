using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class FishLevel1Moving : MonoBehaviour
{
    public float zoomWhenHit = 2f;
    public float duration = 2f;
    private Vector3 initialScale;
    public float moveSpeed = 5f;
    public EnemySpam.SpamPosition spamPosition;
    private Vector3 vectorPosition;
    private bool isMoving = true;
    private Vector3 targetScale;

    private void Start()
    {
        initialScale = transform.localScale;
        targetScale = new Vector3(transform.localScale.x * zoom, transform.localScale.y * zoom, transform.localScale.z);
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
            StartCoroutine(ScaleOverTime(targetScale));
        }
    }
    public void ScaleDown()
    {
        StartCoroutine(ScaleOverTime(initialScale));
        isMoving = true;
    }
    private IEnumerator ScaleOverTime(Vector3 target)
    {
        Vector3 currentScale = transform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(currentScale, target, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = target;
    }
}