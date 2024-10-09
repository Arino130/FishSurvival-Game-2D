using System;
using UnityEngine;
using System.Collections;

public class EnemySpam : MonoBehaviour
{
    public GameObject fishLevel1;
    public Transform enemyFolder;
    public int minTimeSpam;
    public int maxTimeSpam = 10; //Mile second

    void Update()
    {
        StartCoroutine(spamObject());
    }
    private IEnumerator spamObject()
    {
        yield return new WaitForSeconds(Random.Range(minTimeSpam, maxTimeSpam));
        Instantiate(fishLevel1, transform.position, transform.rotation, enemyFolder);
    }

}