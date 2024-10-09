using UnityEngine;
using System.Collections;

public class TerrainVibrate : MonoBehaviour
{
    public float maxMovingLeft;
    public float maxMovingRight;
    public float duration;
    public bool isVibrate = true;
    private PositionVibrateType positionType = PositionVibrateType.Right;
    private void Start()
    {
        StartCoroutine(onVibrate());
    }
    private IEnumerator onVibrate()
    {
        while (isVibrate)
        {
            int valueMoving = transform.position.x;
            switch (positionType)
            {
                case PositionVibrateType.Left:
                    break;
                case PositionVibrateType.Right:
                    break;
            }
            yield return new WaitForSeconds(duration);
        }
    }
    public enum PositionVibrateType
    {
        Left,
        Right
    }
}