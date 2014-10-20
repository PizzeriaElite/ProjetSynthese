using UnityEngine;
using System;
using System.Collections.Generic;

public delegate bool TransitionConditionCallback();

/*
 Questioning :
 
-Use one script by State or only if needed ?
-Componenent naming : always use a prefix ? (Player, Bird...)
-How to handle transitions that depend on event ?
-Use multiple State Machine or Additive State ?
-State that last only one frame ?
-How to manage components references, and non-machine-state code ?
 
 Todo :
-Make a StateMachineAnimation with the binding with mecanim
-Optimize transition checking with a dictionnary state/transitions
*/

public class StateMachineComponent : MonoBehaviour
{
	[System.Serializable]
	public class Transition
	{
		public Transition(System.Enum i_FromState, System.Enum i_ToState, TransitionConditionCallback i_Condition)
		{
			m_FromState = Convert.ToInt32(i_FromState);
			m_ToState = Convert.ToInt32(i_ToState);
			m_Condition = i_Condition;
		}
		
		public int m_FromState;
		public int m_ToState;
		public TransitionConditionCallback m_Condition;
	}
	
	#region Configuration
	public string m_ScriptPrefix = "Player";
	#endregion
	
	/*
	#region Animator Paramaters & States Binding
	public Animator m_Animator;
	private Dictionary<int, int> m_AnimationParameterId = new Dictionary<int, int>();
	#endregion
	*/
	
	#region Transitions, States, Components
	private List<Transition> m_Transitions = new List<Transition>();
	private List<State> m_StateComponents = new List<State>();
	
	private int m_CurrentStateIndex = int.MaxValue;
	
	protected float m_LastStateChangeTime = Mathf.Infinity;
	
	public float TimeSinceLastStateChange { get {return Time.time - m_LastStateChangeTime; }}
	#endregion
	
	protected virtual void Update()
	{
		UpdateTransitions();
	}

	#region public & protected methods
	public void SetDefaultState(System.Enum i_DefaultState)
	{
		BindComponentToStates(i_DefaultState);
		
		if (m_CurrentStateIndex == int.MaxValue)
		{
			SetState(Convert.ToInt32(i_DefaultState));
		}
	}
	
	public void AddTransition(System.Enum i_FromState, System.Enum i_ToState, TransitionConditionCallback i_Condition)
	{
		m_Transitions.Add(new Transition(i_FromState, i_ToState, i_Condition));
	}
	
	public void AddTransition(System.Enum[] i_FromStates, System.Enum i_ToState, TransitionConditionCallback i_Condition)
	{
		for (int i = 0; i < i_FromStates.Length; i++)
		{
			m_Transitions.Add(new Transition(i_FromStates[i], i_ToState, i_Condition));
		}
	}
	
	/*
	public void BindAnimatorParametersToStates(params System.Enum[] i_States)
	{
		for (int i = 0; i < i_States.Length; i++)
		{
			int stateIndex = System.Convert.ToInt32(i_States[i]);
			m_AnimationParameterId.Add(stateIndex, Animator.StringToHash(i_States[i].ToString()));
		}
	}
	*/
	
	protected virtual void OnStateChange(int i_From, int i_To)
	{
	}
	#endregion
	
	#region Components & States Binding
	private void BindComponentToStates(System.Enum enumItem)
	{
		foreach(System.Enum state in System.Enum.GetValues(enumItem.GetType()))
		{
			BindComponentToState(state, GetComponent(m_ScriptPrefix + state.ToString()) as State);
		}
	}

	private void BindComponentToState(System.Enum i_State, State i_StateComponent)
	{
		int stateIndex = Convert.ToInt32(i_State);
		while (m_StateComponents.Count <= stateIndex)
		{
			m_StateComponents.Add(null);
		}

		m_StateComponents[stateIndex] = i_StateComponent;
		
		if (i_StateComponent)
		{
			i_StateComponent.enabled = false;
		}
	}
	#endregion
	
	#region States & Transitions
	private void UpdateTransitions()
	{
		for(int i = 0; i < m_Transitions.Count; i++)
		{
			if (m_Transitions[i].m_FromState == m_CurrentStateIndex &&
				m_Transitions[i].m_Condition())
			{
				SetState(m_Transitions[i].m_ToState);
				return;
			}
		}
	}
	
	private void SetState(int i_State)
	{
		if (m_CurrentStateIndex < m_StateComponents.Count && m_StateComponents[m_CurrentStateIndex])
		{
			m_StateComponents[m_CurrentStateIndex].Exit();
		}

		if (i_State < m_StateComponents.Count &&m_StateComponents[i_State])
		{
			m_StateComponents[i_State].Enter();
		}
	
		m_LastStateChangeTime = Time.time;
		//UpdateAnimatorParameter(m_CurrentStateIndex, i_State);
		OnStateChange(m_CurrentStateIndex, i_State);
		m_CurrentStateIndex = i_State;
	}
	#endregion
	
	/*
	#region Animator Paramaters & States Binding
	private void UpdateAnimatorParameter(int i_From, int i_To)
	{
		if (m_AnimationParameterId.ContainsKey(i_From))
		{
			m_Animator.SetBool(m_AnimationParameterId[i_From], false);
		}
		
		if (m_AnimationParameterId.ContainsKey(i_To))
		{
			m_Animator.SetBool(m_AnimationParameterId[i_To], true);
		}
	}
	#endregion
	*/
}