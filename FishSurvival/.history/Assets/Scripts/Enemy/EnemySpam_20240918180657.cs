using System.Numerics;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemySpam : MonoBehaviour
{
    public GameObject[] enemyLevel1Alls;
    public GameObject[] enemyLevel5Alls;
    public Transform enemyFolder;
    public int[] timeSpamLevel1;
    public int[] timeSpamLevel5;
    public SpamPosition spamPosition;
    private GameObject fishChoose;

    void Start()
    {
        StartCoroutine(spamObject(timeSpamLevel1.First(), timeSpamLevel1.Last(), 1));
        StartCoroutine(spamObject(timeSpamLevel5.First(), timeSpamLevel5.Last(), 5));
    }
    private IEnumerator spamObject(int minSecond, int maxSecond, int level)
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSecond, maxSecond));

            float minY = transform.position.y;
            float maxY = transform.position.y + transform.localScale.y;
            float randomY = UnityEngine.Random.Range(minY, maxY);
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