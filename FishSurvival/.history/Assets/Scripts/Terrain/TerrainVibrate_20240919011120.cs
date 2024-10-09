using UnityEngine;
using System.Collections;

public class TerrainVibrate : MonoBehaviour
{
    public float maxMovingLeft;
    public float maxMovingRight;
    public float stepMoving;
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
            float valueMoving = transform.position.x;
            switch (positionType)
            {
                case PositionVibrateType.Left:
                    valueMoving += stepMoving;
                    if (valueMoving > maxMovingRight)
                    {
                        positionType = PositionVibrateType.Right;
                    }
                    break;
                case PositionVibrateType.Right:
                    valueMoving -= stepMoving;
                    if (valueMoving > maxMovingRight)
                    {
                        positionType = PositionVibrateType.Left;
                    }
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