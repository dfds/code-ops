using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CloudEngineering.CodeOps.Abstractions.Entities
{
	public abstract class EntityEnumeration : IComparable
	{
		public string Name { get; private set; }

		public int Id { get; private set; }

		protected EntityEnumeration()
		{ }

		protected EntityEnumeration(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public override string ToString() => Name;

		public static IEnumerable<T> GetAll<T>() where T : EntityEnumeration
		{
			var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			return fields.Select(f => f.GetValue(null)).Cast<T>();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is EntityEnumeration otherValue))
			{
				return false;
			}

			var typeMatches = GetType().Equals(obj.GetType());
			var valueMatches = Id.Equals(otherValue.Id);

			return typeMatches && valueMatches;
		}

		public override int GetHashCode() => Id.GetHashCode();

		public static int AbsoluteDifference(EntityEnumeration firstValue, EntityEnumeration secondValue)
		{
			var absoluteDifference = Math.Abs(firstValue.Id - secondValue.Id);
			return absoluteDifference;
		}

		public static T FromValue<T>(int value) where T : EntityEnumeration
		{
			var matchingItem = Parse<T, int>(value, "value", item => item.Id == value);
			return matchingItem;
		}

		public static T FromDisplayName<T>(string displayName) where T : EntityEnumeration
		{
			var matchingItem = Parse<T, string>(displayName, "display name", item => item.Name == displayName);
			return matchingItem;
		}

		private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : EntityEnumeration
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if (matchingItem == null)
			{
				throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
			}

			return matchingItem;
		}

		public int CompareTo(object other) => Id.CompareTo(((EntityEnumeration)other).Id);
	}
}
