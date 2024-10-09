public static class WeaponTypeExtensions
{
    public static string GetFullName(this WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.WeaponLevel1:
                return "Gun 1";
            default:
                return "Unknown";
        }
    }
}