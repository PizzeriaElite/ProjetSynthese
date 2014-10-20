using UnityEngine;
using System.Collections;
using UnityEditor;

/*This don't work : ExportPackage don't work with multiple assets*/

public class PackageExporter : MonoBehaviour 
{
	/*
	private const string PACKAGE_FOLDER = "Assets/Packages/";
	private static string PACKAGE_SUFFIXE = " " + System.DateTime.Now.ToString("yyyy-MM-dd") + ".unitypackage";
	
	[MenuItem ("ENDI/Packages/Export Credits")]
	private static void ExportCredits()
	{
		string[] assets = new string[] {"Assets/Credits", "Resources/Credits", "Resources/Credits/Section"};
		string packageFileName = PACKAGE_FOLDER + "CreditsPackage" + PACKAGE_SUFFIXE;
		AssetDatabase.ExportPackage(assets, packageFileName, ExportPackageOptions.Recurse | ExportPackageOptions.IncludeDependencies);

	}
	*/
}
