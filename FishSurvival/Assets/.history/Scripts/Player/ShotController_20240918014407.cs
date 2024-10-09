using System.Threading;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotController : MonoBehaviour
{
    public GameObject bullet;
    public GameObject gunBarrel;
    public Vector3 moveBackOffset;
    public float durationBackOffset = 0.5f;
    public float bulletSpeed = 20f;
    public float shootInterval = 0.2f;
    public double shotDelayMillis = 1000d;
    public Transform bulletsFolder;
    private float lastShootTime;
    private Rigidbody2D rb;
    public GameObject weapon;
    private Vector3 originalPosition;

    private void Start()
    {
        lastShootTime = -shootInterval;
        rb = GetComponent<Rigidbody2D>();
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
        StartCoroutine(MoveBackAndForth());
    }

    private IEnumerator MoveBackAndForth()
    {
        moveBackOffset = new Vector3(0f, 1f, 0f);
        Vector3 targetPosition = originalPosition + gunBarrel.transform.position;
        yield return MoveToPosition(targetPosition, durationBackOffset);
        yield return MoveToPosition(originalPosition, durationBackOffset);
    }

    private IEnumerator MoveToPosition(Vector3 target, float duration)
    {
        Vector3 startPosition = gunBarrel.transform.position;
        float timeElapsed = 0;

        while (timeElapsed < duration)
        {
            gunBarrel.transform.position = Vector3.Lerp(startPosition, target, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        gunBarrel.transform.position = target;
    }
}