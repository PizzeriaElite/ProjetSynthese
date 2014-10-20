using UnityEngine;
using System.Collections;

public class CharacterInputAIFollow : CharacterInput
{
	public const int ENEMY_SPEED = 10;
	public const float MIN_DISTANCE = 5;

	/// <summary>
	/// Update the enemy instance.
	/// </summary>
	void Update () 
	{
		FollowPlayerByDirection();
	}

	/// <summary>
	/// Finds the player position x.
	/// </summary>
	/// <returns>The player position x.</returns>
	float FindPlayerPositionX()
	{
		return GameObject.FindWithTag("Player").transform.position.x;
	}

	/// <summary>
	/// Finds the player position y.
	/// </summary>
	/// <returns>The player position y.</returns>
	float FindPlayerPositionY()
	{
		return GameObject.FindWithTag("Player").transform.position.y;
	}

	/// <summary>
	/// Finds the player's direction from the current enemy.
	/// </summary>
	/// <returns>A vector3 representing the player's direction from the enemy.</returns>
	Vector3 FindPlayerDirectionFromEnemy()
	{
		Vector3 direction = GameObject.FindWithTag("Player").transform.position - this.gameObject.transform.position;
		direction.Normalize();
		return direction;
	}

	/// <summary>
	/// Finds the player's distance from the current enemy.
	/// </summary>
	float FindPlayerDistanceFromEnemy()
	{
		float distance = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, this.gameObject.transform.position);
		return distance;
	}
	
	/// <summary>
	/// Identifies if the player is above the current enemy.
	/// </summary>
	/// <returns><c>true</c>, if player is above the current enemy, <c>false</c> otherwise.</returns>
	bool isPlayerAbove()
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
	bool isPlayerUnder()
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
	bool isPlayerLeft()
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
	bool isPlayerRight()
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

	/// <summary>
	/// Follows the player with its direction.
	/// </summary>
	void FollowPlayerByDirection()
	{
		Debug.Log (FindPlayerDirectionFromEnemy().ToString());
		if (this.FindPlayerDistanceFromEnemy() <= MIN_DISTANCE)
		{
			this.gameObject.rigidbody.AddForce(new Vector3(FindPlayerDirectionFromEnemy().x,0,0) * ENEMY_SPEED);
		}
		else
		{
			this.gameObject.rigidbody.velocity = new Vector3(0,this.rigidbody.velocity.y);
		}
	}
}
