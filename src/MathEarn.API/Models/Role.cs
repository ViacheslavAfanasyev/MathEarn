namespace MathEarn.API.Models
{
    public enum Role
    {
        Parent,
        Child
    }

    public static class UserRoleExtensions
    {
        private static readonly Dictionary<Role, string> RoleNames = new()
    {
        { Role.Parent, "Parent" },
        { Role.Child, "Child" },
    };

        public static string ToFriendlyString(this Role role)
        {
            return RoleNames.TryGetValue(role, out var name) ? name : role.ToString();
        }
    }
}
