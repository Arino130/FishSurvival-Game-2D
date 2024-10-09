using UnityEngine;
using TMPro;
using System.Collections;

public class FishStatistics : MonoBehaviour
{
    public int hearthValue = 100;
    public float timeoutHiddenDamage = 1f;
    public TextMeshProUGUI textDamageValue;
    private bool isShowDamage = false;

    public void hitDamage(int value)
    {
        textDamageValue.text = isShowDamage ? "" : $"{value}";
        hearthValue = Mathf.Max(0, hearthValue - value);
        StartCoroutine(hiddenDamage());
    }
    private IEnumerator hiddenDamage()
    {
        yield return new WaitForSeconds(timeoutHiddenDamage);
        if (isShowDamage)
        {
            textDamageValue.text = "";
        }
    }
}