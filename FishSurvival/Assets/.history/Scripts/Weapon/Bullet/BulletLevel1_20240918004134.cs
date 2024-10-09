using UnityEngine;

public class BulletLevel1 : BulletRoot
{
    public int damageValue = 10;
    override protected void onTrigger(Collider2D other)
    {
        other.GetComponent<FishStatistics>().hitDamage(damageValue);
    }
}