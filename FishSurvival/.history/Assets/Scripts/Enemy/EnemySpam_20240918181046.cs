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
                    GameObject fishLevel1 = enemyLevel1Alls[UnityEngine.Random.Range(0, enemyLevel1Alls.Length)];
                    fishChoose = Instantiate(fishLevel1, new UnityEngine.Vector3(transform.position.x, randomY, -1f), fishLevel5.transform.rotation, enemyFolder);
                    fishChoose.GetComponent<FishLevel5Moving>().updateSpamPosition(spamPosition);
                    break;
                case 5:
                    GameObject fishLevel5 = enemyLevel5Alls[UnityEngine.Random.Range(0, enemyLevel5Alls.Length)];
                    fishChoose = Instantiate(fishLevel5, new UnityEngine.Vector3(transform.position.x, randomY, -1f), fishLevel5.transform.rotation, enemyFolder);
                    fishChoose.GetComponent<FishLevel5Moving>().updateSpamPosition(spamPosition);
                    break;
            }

            switch (spamPosition)
            {
                case SpamPosition.Left:
                    fishChoose.transform.rotation = UnityEngine.Quaternion.Euler(180f, 0f, 180f);
                    break;
            }

        }
    }
    public enum SpamPosition
    {
        Left,
        Right
    }
}