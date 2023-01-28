static class Helper
{
	public static string GetUntilOrEmpty(this string text, string stopAt = "-")
	{
		if (!string.IsNullOrWhiteSpace(text))
		{
			int charLocation = text.IndexOf(stopAt, 0);//StringComparison.Ordinal);

			if (charLocation > 0)
			{
				return text.Substring(0, charLocation);
			}
		}

		return string.Empty;
	}
	public static string GetAfterOrAll(this string text, string startAt = "-")
	{
		
		if (!string.IsNullOrWhiteSpace(text))
		{
			int charLocation = text.IndexOf(startAt, 0);//StringComparison.Ordinal);

			if (charLocation > 0)
			{
				return text.Substring(charLocation, text.Length-charLocation);
			}
		}

		return text;
	}
}