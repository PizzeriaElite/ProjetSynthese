using UnityEngine;
using System.Collections;
using System;

public enum BetweenOption {InclusiveInclusive, InclusiveExclusive, ExclusiveExclusive, ExclusiveInclusive};

public static class Extensions
{

	public static bool Between<T>(this T value, T minimum, T maximum, BetweenOption betweenOption = BetweenOption.InclusiveInclusive) where T : IComparable
	{
		switch(betweenOption)
		{
			case BetweenOption.InclusiveInclusive: return (minimum.CompareTo(value) <= 0) && (value.CompareTo(maximum) <= 0);
			case BetweenOption.InclusiveExclusive: return (minimum.CompareTo(value) <= 0) && (value.CompareTo(maximum) < 0);
			case BetweenOption.ExclusiveInclusive: return (minimum.CompareTo(value) < 0) && (value.CompareTo(maximum) <= 0);
			case BetweenOption.ExclusiveExclusive: return (minimum.CompareTo(value) < 0) && (value.CompareTo(maximum) < 0);
		}

		Debug.LogWarning("An error occured with IsBetween");

		return false;
	}
}