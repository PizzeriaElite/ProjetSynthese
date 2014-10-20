using UnityEditor;
using UnityEngine;
using System.Collections;

//This class add menu item to switch the screen resolution (Edit/Projects Settings/Player)

public class ScreenResolutionSwitcher : MonoBehaviour {
	
	private static ScreenOrientation m_oScreenOrientation = ScreenOrientation.Landscape;
	private static int m_iScreenWidth = 480;
	private static int m_iScreenHeight = 320;

	[MenuItem ("ENDI/Screen/Set Screen Resolution to 1024x768 &3")]
	private static void setScreenResolutionTo1024x768(){
		Debug.Log("Editor : Set Screen Resolution to 1024x768");
		setScreenResolutionTo(1024, 768);
	}

	[MenuItem ("ENDI/Screen/Set Screen Resolution to 960x640 &2")]
	private static void setScreenResolutionTo960x640(){
		Debug.Log("Editor : Set Screen Resolution to 960x640");
		setScreenResolutionTo(960, 640);
	}

	[MenuItem ("ENDI/Screen/Set Screen Resolution to 480x320 &1")]
	private static void setScreenResolutionTo480x320(){
		Debug.Log("Editor : Set Screen Resolution to 480x320");
		setScreenResolutionTo(480, 320);
	}

	[MenuItem ("ENDI/Screen/Set Screen Orientation to Portrait &p")]
	private static void setScreenOrientationToPortrait(){
		Debug.Log("Editor : Set Screen Orientation to Portrait");
		setScreenOrientation(ScreenOrientation.Portrait);
	}

	[MenuItem ("ENDI/Screen/Set Screen Orientation to Landscape &l")]
	private static void setScreenOrientationToLandscape(){
		Debug.Log("Editor : Set Screen Orientation to Landscape");
		setScreenOrientation(ScreenOrientation.Landscape);
	}

	private static void setScreenOrientation(ScreenOrientation p_oScreenOrientation){
		m_oScreenOrientation = p_oScreenOrientation;
		if (m_iScreenWidth > m_iScreenHeight && m_oScreenOrientation == ScreenOrientation.Portrait ||
		    m_iScreenWidth < m_iScreenHeight && m_oScreenOrientation == ScreenOrientation.Landscape){
			switchValues(ref m_iScreenWidth, ref m_iScreenHeight);
		}
		updateScreenResolution();
	}

	private static void switchValues(ref int p_iA, ref int p_iB){
		int temp = p_iA;
		p_iA = p_iB;
		p_iB = temp;
	}

	private static void setScreenResolutionTo(int p_iWidth, int p_iHeight){
		m_iScreenWidth  = (m_oScreenOrientation == ScreenOrientation.Landscape ? p_iWidth  : p_iHeight);
		m_iScreenHeight = (m_oScreenOrientation == ScreenOrientation.Landscape ? p_iHeight : p_iWidth); 
		updateScreenResolution();
	}

	private static void updateScreenResolution(){
		PlayerSettings.defaultScreenWidth  = m_iScreenWidth;
		PlayerSettings.defaultScreenHeight = m_iScreenHeight;
		EditorApplication.Beep();
		
	}

}
