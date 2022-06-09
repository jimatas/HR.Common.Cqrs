using System;

namespace HR.Common.Cqrs.Infrastructure
{
    internal static class TypeExtensions
    {
        public static bool IsConcrete(this Type type) => !(type.IsInterface || type.IsAbstract);

        public static Type[] GetImplementedGenericInterfaces(this Type type, Type genericTypeDefinition)
            => type.FindInterfaces((candidate, criteria) => candidate.IsGenericType && candidate.GetGenericTypeDefinition().Equals(criteria), genericTypeDefinition);
    }
}
