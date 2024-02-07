namespace Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class EnumValueAttribute : Attribute
    {
        public string Value { get; }

        public EnumValueAttribute(string value)
        {
            this.Value = value;
        }
    }
}