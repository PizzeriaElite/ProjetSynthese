using UnityEngine;
using System.Collections;

public class CharacterInputAIEscape : CharacterInput
{
	public int ENEMY_SPEED = 10;
	public float MAX_DISTANCE = 5f;
	public float MIN_DISTANCE = 0.5f;
	
	private void Update () 
	{
		this.EscapePlayerByDirection();
	}
	
	/// <summary>
	/// Finds the player position x.
	/// </summary>
	/// <returns>The player position x.</returns>
	private float FindPlayerPositionX()
	{
		return GameObject.FindWithTag("Player").transform.position.x;
	}
	
	/// <summary>
	/// Finds the player position y.
	/// </summary>
	/// <returns>The player position y.</returns>
	private float FindPlayerPositionY()
	{
		return GameObject.FindWithTag("Player").transform.position.y;
	}
	
	/// <summary>
	/// Finds the player's direction from the current enemy.
	/// </summary>
	/// <returns>A vector3 representing the player's direction from the enemy.</returns>
	private Vector3 FindPlayerDirectionFromEnemy()
	{
		Vector3 direction = GameObject.FindWithTag("Player").transform.position - this.transform.position;
		direction.Normalize();
		return direction;
	}
	
	/// <summary>
	/// Finds the player's distance from the current enemy.
	/// </summary>
	private float FindPlayerDistanceFromEnemy()
	{
		float distance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, this.transform.position);
		return distance;
	}
	
	/// <summary>
	/// Identifies if the player is above the current enemy.
	/// </summary>
	/// <returns><c>true</c>, if player is above the current enemy, <c>false</c> otherwise.</returns>
	private bool isPlayerAbove()
	{
		float playerPositionY = this.FindPlayerPositionY();
		float enemyPositionY = this.transform.position.y;
		
		if(playerPositionY > enemyPositionY)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	/// <summary>
	/// Identifies if the player is under the current enemy.
	/// </summary>
	/// <returns><c>true</c>, if player is under the current enemy, <c>false</c> otherwise.</returns>
	private bool isPlayerUnder()
	{
		float playerPositionY = this.FindPlayerPositionY();
		float enemyPositionY = this.transform.position.y;
		
		if(playerPositionY < enemyPositionY)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	/// <summary>
	/// Identifies if the player is to the left of the current enemy.
	/// </summary>
	/// <returns><c>true</c>, if player is to the left of the current enemy, <c>false</c> otherwise.</returns>
	private bool isPlayerLeft()
	{
		float playerPositionX = this.FindPlayerPositionX();
		float enemyPositionX = this.transform.position.x;
		
		if(playerPositionX < enemyPositionX)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	/// <summary>
	/// Identifies if the player is to the right of the current enemy.
	/// </summary>
	/// <returns><c>true</c>, if player is to the right of the current enemy, <c>false</c> otherwise.</returns>
	private bool isPlayerRight()
	{
		float playerPositionX = this.FindPlayerPositionX();
		float enemyPositionX = this.transform.position.x;
		
		if(playerPositionX > enemyPositionX)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	public void EscapePlayerByDirection()
	{
		float currentDistance = this.FindPlayerDistanceFromEnemy();
		float currentDistanceX = Mathf.Abs(this.FindPlayerPositionX() - this.transform.position.x);

		if(this.isPlayerLeft())
		{
			this.character.input.horizontal = 1;
		}
		else if(this.isPlayerRight())
		{
			this.character.input.horizontal = -1;
		}
	}
	
	
}
