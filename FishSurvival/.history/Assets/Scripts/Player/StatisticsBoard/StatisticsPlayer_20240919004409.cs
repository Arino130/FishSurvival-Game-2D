using UnityEngine;
using TMPro;
using System.Collections;
public class StatisticsPlayer : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public GameObject textCoinMessageValue;
    public GameObject textCoinMessagePoint;
    public Transform textCoinMessageSpamFolder;
    public GameObject gameConfigObj;
    private GameConfig gameConfig;
    public int totalCoin = 0;
    public int subCoin = 0;
    public float moveDistance = 0.1f;
    public float fadeDuration = 3f;
    private SpriteRenderer spriteRenderer;
    private Vector3 startPosition;
    private bool isShowMessage = false;
    private GameObject textCoinMessageInit;

    private void Start()
    {
        gameConfig = gameConfigObj.GetComponent<GameConfig>();
        if (gameConfig != null)
        {
            totalCoin = gameConfig.coinInit;
        }
    }
    private void Update()
    {
        textCoinValue.text = $"{totalCoin}";
        if (isShowMessage && textCoinMessageInit != null)
        {
            textCoinMessageInit.GetComponent<TextMeshProUGUI>().text = "+" + subCoin;
        }
    }
    public void UsingCoin(int value)
    {
        totalCoin -= value;
    }

    public void AddCoin(int value)
    {
        totalCoin += value;
        if (!isShowMessage)
        {
            subCoin = value;
            showMessageCoin(value);
        }
        else
        {
            subCoin += value;
        }
    }
    void showMessageCoin(int value)
    {
        isShowMessage = true;
        textCoinMessageInit = Instantiate(textCoinMessageValue, textCoinMessagePoint.transform.position, textCoinMessagePoint.transform.rotation, textCoinMessageSpamFolder);
        TextMeshProUGUI textComponent = textCoinMessageInit.GetComponent<TextMeshProUGUI>();
        startPosition = textCoinMessageInit.transform.position;
        textCoinMessageInit.GetComponent<TextMeshProUGUI>().text = "+" + value;
        StartCoroutine(MoveAndFadeCoroutine(textComponent, startPosition));
    }
    private IEnumerator MoveAndFadeCoroutine(TextMeshProUGUI textComponent, Vector3 startPosition)
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / fadeDuration);
            float newY = Mathf.Lerp(startPosition.y, startPosition.y + moveDistance, progress);
            textComponent.transform.position = new Vector3(textComponent.transform.position.x, newY, textComponent.transform.position.z);

            Color newColor = textComponent.color;
            newColor.a = Mathf.Lerp(1f, 0f, progress);
            textComponent.color = newColor;

            yield return null;
        }

        Destroy(textComponent.gameObject);
        isShowMessage = false;
    }
}