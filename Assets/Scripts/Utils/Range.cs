using UnityEngine;
using System.Collections;

[System.Serializable]
public class Range
{
	public enum Clusivity{Inclusive, Exlusive};
	
	public float minimum;
	public float maximum;
	
	public Range(float minimum, float maximum)
	{
		this.minimum = minimum;
		this.maximum = maximum;
	}
	
	public bool Contains(float value, Clusivity clusivity = Clusivity.Inclusive)
	{
		if (clusivity == Clusivity.Inclusive)
		{
			return value >= minimum && value <= maximum;
		}
		
		return value > minimum && value < maximum;
	}
}
