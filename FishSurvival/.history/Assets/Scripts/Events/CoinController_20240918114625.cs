using System.Collections;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float stopObjAfterTime = 0.1f;
    private float waitObjParking = 0.2f;
    private Rigidbody2D rb;
    private GameObject pointCollect;
    public CircleCollider2D circleCollider2D;
    public float moveSpeed = 1f;

    private void Start()
    {
        StartCoroutine(StopObject());
        pointCollect = GameObject.FindWithTag("CollectPointScore");
    }
    void Update()
    {
        if (pointCollect != null)
        {
            Vector3 direction = (pointCollect.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    private IEnumerator WaitObjParking()
    {
        yield return new WaitForSeconds(waitObjParking);
        circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        if (circleCollider2D != null)
        {
            circleCollider2D.isTrigger = true;
        }
    }
    private IEnumerator StopObject()
    {
        yield return new WaitForSeconds(stopObjAfterTime);
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StartCoroutine(WaitObjParking());
        }
    }
}