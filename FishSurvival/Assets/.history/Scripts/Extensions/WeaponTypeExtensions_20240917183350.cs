public static class WeaponTypeExtensions
{
    public static string GetFullName(this InventoryWeapon.WeaponType weaponType)
    {
        switch (weaponType)
        {
            case InventoryWeapon.WeaponType.WeaponLevel1:
                return "Gun 1";
            case InventoryWeapon.WeaponType.WeaponLevel1:
                return "Gun 1";
            default:
                return "Unknown";
        }
    }
}