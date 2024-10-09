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
    public float moveDistance = 0.1f;
    public float fadeDuration = 3f;
    public float moveSpeed = 2f;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Vector3 startPosition;
    private float elapsedTime = 0f;

    private void Start()
    {
        gameConfig = gameConfigObj.GetComponent<GameConfig>();
        if (gameConfig != null)
        {
            totalCoin = gameConfig.coinInit;
        }
        spriteRenderer = textCoinMessageValue.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }
    private void Update()
    {
        textCoinValue.text = $"{totalCoin}";
    }
    public void UsingCoin(int value)
    {
        totalCoin -= value;
    }

    public void AddCoin(int value)
    {
        totalCoin += value;
        showMessageCoin(value);
    }
    void showMessageCoin(int value)
    {
        elapsedTime = 0f;
        GameObject textCoinMessageInit = Instantiate(textCoinMessageValue, textCoinMessagePoint.transform.position, textCoinMessagePoint.transform.rotation, textCoinMessageSpamFolder);
        startPosition = textCoinMessageInit.transform.position;
        textCoinMessageInit.GetComponent<TextMeshProUGUI>().text = "+" + value;
        StartCoroutine(MoveAndFadeCoroutine(textCoinMessageInit));
    }
    private IEnumerator MoveAndFadeCoroutine(GameObject textCoinMessageInit)
    {
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / fadeDuration);
            float newY = Mathf.Lerp(startPosition.y, startPosition.y + moveDistance, progress);
            textCoinMessageInit.transform.position = new Vector3(textCoinMessageInit.transform.position.x, newY, textCoinMessageInit.transform.position.z);
            if (spriteRenderer != null)
            {
                Color newColor = originalColor;
                newColor.a = Mathf.Lerp(1f, 0f, progress);
                spriteRenderer.color = newColor;
            }

            yield return null;
        }
        // Destroy(textCoinMessageInit);
    }
}