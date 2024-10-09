using UnityEngine;
using TMPro;
using System.Collections;
public class StatisticsPlayer : MonoBehaviour
{
    public TextMeshProUGUI textCoinValue;
    public TextMeshProUGUI textCoinMessageValue;
    public GameObject gameConfigObj;
    private GameConfig gameConfig;
    public int totalCoin = 0;
    public float moveDistance = 5f;
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

    void showMessageCoin(int value)
    {
        textCoinMessageValue.text = "+" + value;
        startPosition = textCoinMessageValue.transform.position;
        StartCoroutine(MoveAndFadeCoroutine());
    }

    private IEnumerator MoveAndFadeCoroutine()
    {
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / fadeDuration);
            float newY = Mathf.Lerp(startPosition.y, startPosition.y + moveDistance, progress);
            textCoinMessageValue.transform.position = new Vector3(startPosition.x, newY, startPosition.z);

            if (spriteRenderer != null)
            {
                Color newColor = originalColor;
                newColor.a = Mathf.Lerp(1f, 0f, progress);
                spriteRenderer.color = newColor;
            }

            yield return null;
        }

        textCoinMessageValue.transform.position = startPosition;
        if (spriteRenderer != null)
        {
            Color finalColor = originalColor;
            finalColor.a = 0f;
            spriteRenderer.color = finalColor;
        }

        elapsedTime = 0f;
    }
}