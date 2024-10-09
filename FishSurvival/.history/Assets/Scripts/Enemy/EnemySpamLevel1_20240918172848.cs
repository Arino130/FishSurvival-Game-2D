using System.Numerics;
using System;
using UnityEngine;
using System.Collections;

public class EnemySpam : MonoBehaviour
{
    public GameObject fish1;
    public GameObject fish2;
    public GameObject[] enemyAlls;
    public Transform enemyFolder;
    public int minTimeSpam;
    public int maxTimeSpam = 10; //Mile second
    public SpamPosition spamPosition;

    void Start()
    {
        enemyAlls = new GameObject[] {
            fish1,
            fish2
        };
        StartCoroutine(spamObject());
    }
    private IEnumerator spamObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeSpam, maxTimeSpam));

            float minY = transform.position.y;
            float maxY = transform.position.y + transform.localScale.y;
            float randomY = UnityEngine.Random.Range(minY, maxY);

            GameObject fishChoose = enemyAlls[UnityEngine.Random.Range(0, enemyAlls.Length)];
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