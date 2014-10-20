using UnityEditor;
using UnityEngine;
using System.Collections;

//This class add menu item to switch the screen resolution (Edit/Projects Settings/Player)

public class TimeScale : MonoBehaviour {
	
	private const float TIME_STEP = 2;
	
	[MenuItem ("ENDI/Time/Increment Time Scale &4")]
	private static void incrementTimeScale(){
		Debug.Log("Editor : Incrementing Time Scale to " + (Time.timeScale * TIME_STEP));
		setTimeScale(Time.timeScale * TIME_STEP);
	}

	[MenuItem ("ENDI/Time/Decrement" +	"Time Scale &5")]
	private static void decrementTimeScale(){
		Debug.Log("Editor : Decrementing Time Scale to " + (Time.timeScale / TIME_STEP));
		setTimeScale(Time.timeScale / TIME_STEP);
	}

	private static void setTimeScale(float p_fNewTimeScale){
		Time.timeScale = p_fNewTimeScale;
	}


}
