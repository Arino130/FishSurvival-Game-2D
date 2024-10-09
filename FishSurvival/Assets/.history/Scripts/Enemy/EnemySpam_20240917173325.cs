using System.Numerics;
using System;
using UnityEngine;
using System.Collections;

public class EnemySpam : MonoBehaviour
{
    public GameObject fishLevel1;
    public Transform enemyFolder;
    public int minTimeSpam;
    public int maxTimeSpam = 10; //Mile second
    public SpamPosition spamPosition;

    void Start()
    {
        StartCoroutine(spamObject());
    }
    private IEnumerator spamObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minTimeSpam, maxTimeSpam));
            GameObject fishItem = Instantiate(fishLevel1, new UnityEngine.Vector3(transform.position.x, transform.position.y, -1f), fishLevel1.transform.rotation, enemyFolder);
            switch (spamPosition)
            {
                case SpamPosition.LeftTop:
                    fishItem.transform.rotation = UnityEngine.Quaternion.Euler(0f, 90f, 0f);
                    break;
            }
            fishItem.GetComponent<FishLevel1Moving>().updateSpamPosition(spamPosition);
        }
    }
    public enum SpamPosition
    {
        LeftTop,
        LeftDown,
        RightTop,
        RightDown,
        TopLeft,
        TopRight
    }

}