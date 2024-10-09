using System.Threading;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunBarrel;
    public float durationBackOffset = 0.005f;
    public float bulletSpeed = 20f;
    public float shootInterval = 0.2f;
    public double shotDelayMillis = 1000d;
    public Transform bulletsFolder;
    private float lastShootTime;
    private Rigidbody2D rb;
    public GameObject weapon;
    private Vector3 originalScale;

    private void Start()
    {
        lastShootTime = -shootInterval;
        rb = GetComponent<Rigidbody2D>();
        originalScale = gunBarrel.transform.localScale;
    }
    void Update()
    {
        if (Time.time - lastShootTime >= shootInterval)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 50f)
            {
                Attack();
                lastShootTime = Time.time;
            }
        }
    }

    void Attack()
    {
        GameObject newBullet = Instantiate(bullet, weapon.transform.position, weapon.transform.rotation, bulletsFolder);
        newBullet.GetComponent<BulletRoot>().updateInfo(weapon, bulletSpeed);
        gunBarrel.transform.localScale = originalScale;
        StartCoroutine(SkewAndRestore());
    }

    private IEnumerator SkewAndRestore()
    {
        Vector3 skewOffset = new Vector3(0f, 0.4f, 0f);
        Vector3 targetScale = new Vector3(originalScale.x, originalScale.y + skewOffset.y, originalScale.z);

        yield return ScaleTo(targetScale, durationBackOffset);
        yield return ScaleTo(originalScale, durationBackOffset);
    }

    private IEnumerator ScaleTo(Vector3 target, float duration)
    {
        Vector3 startScale = gunBarrel.transform.localScale;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            gunBarrel.transform.localScale = Vector3.Lerp(startScale, target, timeElapsed / duration);
            timeElapsed += 0.00001;
            yield return null;
        }

        gunBarrel.transform.localScale = target;
    }
}