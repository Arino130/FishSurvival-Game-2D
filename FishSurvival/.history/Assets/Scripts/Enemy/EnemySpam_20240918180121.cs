using System.Numerics;
using System;
using UnityEngine;
using System.Collections;

public class EnemySpam : MonoBehaviour
{
    public GameObject[] enemyLevel1Alls;
    public GameObject[] enemyLevel5Alls;
    public Transform enemyFolder;
    public int minTimeSpamLevel1;
    public int maxTimeSpamLevel1 = 10;
    public int minTimeSpamLevel5;
    public int maxTimeSpamLevel5 = 10;
    public SpamPosition spamPosition;

    void Start()
    {
        StartCoroutine(spamObject(minTimeSpamLevel1, maxTimeSpamLevel1, 1));
        StartCoroutine(spamObject(minTimeSpamLevel5, maxTimeSpamLevel5, 5));
    }
    private IEnumerator spamObject(int minSecond, int maxSecond, int level)
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSecond, maxSecond));

            float minY = transform.position.y;
            float maxY = transform.position.y + transform.localScale.y;
            float randomY = UnityEngine.Random.Range(minY, maxY);

            GameObject fishChoose;
            switch (level)
            {
                case 1:
                    fishChoose = enemyLevel1Alls[UnityEngine.Random.Range(0, enemyLevel1Alls.Length)];
                    break;
                case 5:
                    fishChoose = enemyLevel5Alls[UnityEngine.Random.Range(0, enemyLevel5Alls.Length)];
                    break;
            }

            GameObject fishItem = Instantiate(fishChoose, new UnityEngine.Vector3(transform.position.x, randomY, -1f), fishChoose.transform.rotation, enemyFolder);

            switch (spamPosition)
            {
                case SpamPosition.Left:
                    fishItem.transform.rotation = UnityEngine.Quaternion.Euler(180f, 0f, 180f);
                    break;
            }

            fishItem.GetComponent<FishLevel1Moving>().updateSpamPosition(spamPosition);
        }
    }
    public enum SpamPosition
    {
        Left,
        Right
    }
}