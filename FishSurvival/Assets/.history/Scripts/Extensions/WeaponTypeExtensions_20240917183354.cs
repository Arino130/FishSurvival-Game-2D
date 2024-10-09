public static class WeaponTypeExtensions
{
    public static string GetFullName(this InventoryWeapon.WeaponType weaponType)
    {
        switch (weaponType)
        {
            case InventoryWeapon.WeaponType.WeaponLevel1:
                return "Gun 1";
            case InventoryWeapon.WeaponType.WeaponLevel2:
                return "Gun 2";
            default:
                return "Unknown";
        }
    }
}