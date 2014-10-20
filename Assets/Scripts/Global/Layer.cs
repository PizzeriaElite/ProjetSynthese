using UnityEngine;
using System.Collections;

public class Layer : MonoBehaviour
{
	public const int GROUND = 8;
	public const int GROUND_MASK = (1 << 8);
	public const int SLIME = 9;
	public const int SLIME_MASK = (1 << 9);
	public const int LADDER = 10;
	public const int LADDER_MASK = (1 << 10);
	public const int LADDER_TOP = 11;
	public const int LADDER_TOP_MASK = (1 << 11);

	public const int NOT_TRIGGER_MASK = ~(1 << 9);
}
