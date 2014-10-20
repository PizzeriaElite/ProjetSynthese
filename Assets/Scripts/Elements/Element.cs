using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour 
{
	#region Grid Position
	[System.NonSerialized] public Vector3 gridPositionFloat;
	[System.NonSerialized] public Vector2Int gridPosition = new Vector2Int();
	#endregion
	
	#region Events
	public delegate void PositionChange();
	public event PositionChange onPositionChange;
	#endregion

	protected virtual void Start()
	{

	}

	#region Grid Position
	private void RefreshGridPosition()
	{

	}
	
	private void UpdateGridPosition()
	{

	}
	
	private void OnPositionChange()
	{
		if (onPositionChange != null)
		{
			onPositionChange();
		}
	}
	#endregion
}
