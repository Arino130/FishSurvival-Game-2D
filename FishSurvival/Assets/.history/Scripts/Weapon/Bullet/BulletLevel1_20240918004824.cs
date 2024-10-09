using UnityEngine;

public class BulletLevel1 : BulletRoot
{
    public int damageValue = 10;
    override protected void onTrigger(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy")
        {
            Debug.Log($"oke");
            other.gameObject.GetComponent<FishStatistics>().hitDamage(damageValue);
        }
    }
}