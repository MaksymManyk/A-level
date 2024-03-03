using Enums;

namespace  Extensions
{
    public static class ExtensionMethod
    {
        public static string GetSection<T>(this T value)
            where T : Enum
        {
            var enumAttribute = typeof(T).GetField(value.ToString())
                           .GetCustomAttributes(typeof(EnumValueAttribute), false)[0]
                           as EnumValueAttribute;

            return enumAttribute.Value;
        }
    }
}
