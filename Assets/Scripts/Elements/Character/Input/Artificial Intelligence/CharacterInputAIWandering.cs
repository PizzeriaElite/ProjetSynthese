using UnityEngine;
using System.Collections;

public class CharacterInputAIWandering : CharacterInput
{
	public int ENEMY_SPEED = 10;
	public float MAX_DISTANCE = 5f;
	public float MIN_DISTANCE = 0.5f;

	private void OnEnable()
	{
		this.character.input.horizontal = -1;
	}

	//Code tres rudimentaire a changer
	private void Update ()
	{
		Scene.references.levelAI.platforms.Clear();
		Mesh mesh = GetComponentInChildren<MeshFilter>().mesh;
		RaycastHit hit;
		float dist = 5;
		Vector3 dir = new Vector3(0,-1,0);

		Debug.DrawRay(transform.position + new Vector3(mesh.bounds.size.x/2, 0,0),dir*dist,Color.green);
		Debug.DrawRay(transform.position - new Vector3(mesh.bounds.size.x/2, 0,0),dir*dist,Color.green);
		
		if(Physics.Raycast(transform.position + new Vector3(mesh.bounds.size.x/2, 0,0),dir,dist) && (Physics.Raycast(transform.position - new Vector3(mesh.bounds.size.x/2, 0,0),dir,dist)))
		{

		}
		else
		{
			this.character.input.horizontal = -this.character.input.horizontal;
		}
	}
}
