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
        if (isShowDamage)
        {
            textDamageValue.text = "";
        }
        textDamageValue.text = $"{value}";
        if ((hearthValue - value) < 0)
        {
            hearthValue = 0;
        }
        else
        {
            hearthValue -= value;
        }
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