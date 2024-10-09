using System.Threading;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunBarrel;
    public float durationBackOffset = 1f;
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
        SkewAndRestore();
    }

    private void SkewAndRestore()
    {
        Vector3 skewOffset = new Vector3(0f, 0.4f, 0f);
        Vector3 targetScale = new Vector3(originalScale.x, originalScale.y + skewOffset.y, originalScale.z);

        gunBarrel.transform.localScale = targetScale;
        StartCoroutine(ScaleTo(originalScale, durationBackOffset));
    }

    private IEnumerator ScaleTo(Vector3 target, float duration)
    {
        yield return new WaitForSeconds(duration);
        gunBarrel.transform.localScale = target;
    }
}