using System.Numerics;
using System;

namespace BrennanHatton.Math
{
	
	public class MyBigIntegerExtensions { 
		
		const string digits = "0123456789abcdefghijklmnopqrstuvwxyz";
		
		// this have to be used for extend BigInteger
		public static string ToRadixString(BigInteger value, int radix) {
			if (radix <= 1 || radix > 36)
				throw new ArgumentOutOfRangeException(nameof(radix));
			if (value == 0)
				return "0";
	
			bool negative = value < 0;
	      
			if (negative) 
				value = -value;
	
			string sb = "";
	
			for (; value > 0; value /= radix) {
				int d = (int)(value % radix);
	
				sb += ((char)(d < 10 ? '0' + d : 'a' - 10 + d));
			}
	
			string retVal = "";
			for(int i = 0; i < sb.Length; i++)
			{
				retVal += sb[sb.Length-i-1];
			}
			
			return (negative ? "-" : "") + retVal;
		}
		
		public static BigInteger Parse(string value, int radix)//, string digits)
		{
			value = value.ToLower();
			
			if ((radix > digits.Length) || (radix < 2))
				throw new ArgumentOutOfRangeException("radix", radix, 
				string.Format("Radix has to be within range <2, {0}>;", digits.Length));
	 
			if (value == "")
				value = digits.Substring(0,1);
	  
			BigInteger RetValue = 0;
			for (int i = 0; i < value.Length; i++)
			{
				int CharIdx = digits.IndexOf(value[i]);
				if ((CharIdx >= radix) || (CharIdx < 0))
					throw new ArgumentOutOfRangeException("Value", digits[CharIdx], "Invalid character in the input string. " + digits[CharIdx]);
	
				RetValue = RetValue * radix + CharIdx ;
			}
			return RetValue;
		}
	}

}
