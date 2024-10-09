using UnityEngine;

public class BulletLevel2 : BulletRoot
{
    public int damageValue = 30;
    override protected void onTrigger(Collider2D other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Enemy" && isDamage)
        {
            other.gameObject.GetComponent<FishStatistics>().hitDamage(damageValue);
        }
    }
}