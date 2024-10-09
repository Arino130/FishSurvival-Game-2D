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
            float valueMovingX = transform.position.x;
            switch (positionType)
            {
                case PositionVibrateType.Left:
                    valueMovingX += stepMoving;
                    if (valueMovingX > maxMovingRight)
                    {
                        positionType = PositionVibrateType.Right;
                    }
                    break;
                case PositionVibrateType.Right:
                    valueMovingX -= stepMoving;
                    if (valueMovingX > maxMovingRight)
                    {
                        positionType = PositionVibrateType.Left;
                    }
                    break;
            }
            transform.position = new Vector3(valueMovingX, transform.position.y, transform.position.z)
            yield return new WaitForSeconds(duration);
        }
    }
    public enum PositionVibrateType
    {
        Left,
        Right
    }
}