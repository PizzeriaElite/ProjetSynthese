#define DEBUG
using UnityEngine;
using System.Collections;

public class EnemyBehaviour : StateMachineComponentEnemy
{
	private enum State
	{
		AIIdle,
		AIWandering,
		AIAgressive,
		AIEscape
	}

	#region States component
	private AIEscape escape;
	private AIAgressive agressive;
	private AIIdle idle;
	private AIWandering wandering;
	#endregion
	
	private void Start()
	{
		InitializeComponents();
		SetDefaultState(State.AIIdle);
		InitializeTransitions();
	}

	private void InitializeComponents()
	{
		escape = GetComponent<AIEscape>();
		wandering = GetComponent<AIWandering>();
		agressive = GetComponent<AIAgressive>();
		idle = GetComponent<AIIdle>();
	}
	
	private void InitializeTransitions()
	{
		#if DEBUG

		#endif
	}

	private void DynamicTransitions(State oldState, State newState)
	{
		AddTransition(oldState, newState, 
		              () => { return Input.GetKeyDown("1"); });
	}

	protected override void OnStateChange(int from, int to)
	{
		#if DEBUG
		Debug.Log (name + " > " + "OnStateChange" + " > " + (State)from + " to " + (State)to);
		if (to + 1 < System.Enum.GetNames(typeof(State)).Length)
		{
			DynamicTransitions ((State)(to), (State)(to + 1));
		}
		else
		{
			DynamicTransitions ((State)(to), (State)(0));
		}
		#endif
		
		name = ((State)to).ToString();
	}
}
