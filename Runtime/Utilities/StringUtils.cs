using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EqualReality.Utilities
{
	public static class StringUtils
	{
		public static string CamelToSpaced(this string camelCase)
		{
			var charList = new List<char>(camelCase);
			for (var i = 0; i < charList.Count; ++i)
			{
				if (char.IsUpper(charList[i]))
				{
					charList.Insert(i, ' ');
					i++;
				}
			}

			return string.Concat(charList).Trim();
		}
    
		public static string WithoutEnd(this string input, string end)
		{
			if (input.EndsWith(end))
			{
				return input.Substring(0, input.Length - end.Length);
			}

			return input;
		}
    
		public static string GetUntil(this string text, string stopAt = "-")
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

				if (charLocation > 0)
				{
					return text.Substring(0, charLocation);
				}
			}

			return text;
		}
    
		public static string GetUntilOrEmpty(this string text, string stopAt = "-")
		{
			if (!string.IsNullOrWhiteSpace(text))
			{
				var charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

				if (charLocation > 0)
				{
					return text.Substring(0, charLocation);
				}
			}

			return String.Empty;
		}
	}
}