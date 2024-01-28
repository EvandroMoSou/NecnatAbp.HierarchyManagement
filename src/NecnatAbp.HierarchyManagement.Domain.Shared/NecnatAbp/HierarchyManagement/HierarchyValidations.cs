namespace NecnatAbp.HierarchyManagement
{
    public static class HierarchyValidations
    {
        public static string? ValidateName(string? s)
        {
            var r = NameRequired(s);

            if (r == null)
                r = NameMaxLenght(s);

            return r;
        }

        public static string? NameRequired(string? s)
        {
            return string.IsNullOrWhiteSpace(s) ? $"O campo Nome é obrigatório." : null;
        }

        public static string? NameMaxLenght(string? s)
        {
            return s != null && s.Length > HierarchyConsts.MaxNameLength ? $"O campo Nome deve conter no máximo {HierarchyConsts.MaxNameLength} caracters." : null;
        }
    }
}
