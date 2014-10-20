using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : Element 
{
	[System.NonSerialized] public static List<Character> all        = new List<Character>();
	[System.NonSerialized] public static List<Character> allPlayers = new List<Character>();
	[System.NonSerialized] public static List<Character> allEnemies = new List<Character>();
	
	#region World Position
	[System.NonSerialized] public float direction = 1;
	[System.NonSerialized] public Vector3 previousPosition = Vector3.zero;
	#endregion
	
	#region Capacities
	[System.NonSerialized] public CharacterPhysics physics;
	[System.NonSerialized] public CharacterInput input;
	[System.NonSerialized] public CharacterMove move;
	[System.NonSerialized] public CharacterJump jump;
	[System.NonSerialized] public CharacterGroundDetection groundDetector;
	#endregion

	public Transform visual;

	protected virtual void Awake()
	{
		InitializeLists();
	
		initializeCapacities();
	}
	
	protected virtual void InitializeLists()
	{
		all.Add(this);
	}
	
	protected virtual void initializeCapacities()
	{
		physics = GetComponent<CharacterPhysics>();
		input = GetComponent<CharacterInput>();
		move  = GetComponent<CharacterMove>();
		jump  = GetComponent<CharacterJump>();
		groundDetector  = GetComponent<CharacterGroundDetection>();
	}
	
	protected override  void Start()
	{
		base.Start();
	}
	
	private void LateUpdate()
	{
		previousPosition = transform.position;
		
		ApplyVisualDirection();
	}

	private void ApplyVisualDirection()
	{
		if (input.horizontal != 0)
		{
			direction = Mathf.Sign(input.horizontal);
			visual.rotation = Quaternion.Euler(0, direction > 0 ? 0 : 180, 0);
		}
	}
		
	private void OnDestroy()
	{
		all        = null;
		allPlayers = null;
		allEnemies = null;
	}
}
