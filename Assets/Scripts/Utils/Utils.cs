using UnityEngine;
using System.Collections;

public class Utils : MonoBehaviour
{

	public static string stripCloneString(string p_sValue)
	{
		if (p_sValue.EndsWith("(Clone)"))
			return p_sValue.Remove(p_sValue.IndexOf("(Clone)"));
		return p_sValue;
	}

	public static bool isPowerOfTwo(int x)
	{
		return (x & (x - 1)) == 0;
	}	
}
