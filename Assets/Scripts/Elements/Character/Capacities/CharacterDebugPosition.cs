using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterDebugPosition : CharacterCapacity
{
	private const float VISITED_POSITION_SPHERE_RADIUS = 0.1f;
	private const float TRACE_LINE_DURATION = 10;
	
	public Color visitedPositionColor = new Color(1, 0, 0, 0.5f);
	public Color lineColor = new Color(1, 0, 0, 0.5f);
	
	private List<Vector3> visitedPositions = new List<Vector3>();
	
	void Update () 
	{
		Debug.DrawLine(transform.position, character.previousPosition, lineColor, TRACE_LINE_DURATION);
	}
	
	private void OnPositionChange()
	{
		if (!visitedPositions.Contains(character.gridPositionFloat))
		{
			visitedPositions.Add(character.gridPositionFloat);
		}
	}
	
	private void OnDrawGizmos()
	{
		Gizmos.color = visitedPositionColor;
		
		foreach(Vector3 position in visitedPositions)
		{
			Gizmos.DrawSphere(new Vector3(position.x, position.y + Tile.HALF_SIZE, 0), VISITED_POSITION_SPHERE_RADIUS);
		}
	}
	
	private void OnEnable()
	{
		character.onPositionChange += OnPositionChange;
	}
	
	private void OnDisable()
	{
		character.onPositionChange -= OnPositionChange;
	}
}
