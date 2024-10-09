using UnityEngine;
using System.Collections;

public class TerrainVibrate : MonoBehaviour
{
    public float maxMovingLeft;
    public float maxMovingRight;
    public float duration;
    private void Start()
    {
        StartCoroutine(onVibrate());
    }
    private IEnumerator onVibrate()
    {
        yield return new WaitForSeconds(duration);
    }
}