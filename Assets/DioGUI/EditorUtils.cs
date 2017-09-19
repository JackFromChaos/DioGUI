using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public static class EditorUtils  {

	public static void CreateAsset<T>(string name=null) where T : ScriptableObject
	{
		var asset = ScriptableObject.CreateInstance<T>();
		if (string.IsNullOrEmpty(name))
			name = "New " + typeof(T).Name;
		ProjectWindowUtil.CreateAsset(asset, name + ".asset");
	}

	public static void CreateAsset2<T>() where T : ScriptableObject
	{
		T asset = ScriptableObject.CreateInstance<T>();

		string path = AssetDatabase.GetAssetPath(Selection.activeObject);
		if (path == "")
		{
			path = "Assets";
		}
		else if (Path.GetExtension(path) != "")
		{
			path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
		}

		string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");

		AssetDatabase.CreateAsset(asset, assetPathAndName);

		AssetDatabase.SaveAssets();
		AssetDatabase.Refresh();
		EditorUtility.FocusProjectWindow();
		Selection.activeObject = asset;
	}

	static MethodInfo miDisplayCustomMenu;
	public static void DisplayCustomMenu(Rect position, string[] options, int[] selected,
		EditorUtility.SelectMenuItemFunction callback, object userData)
	{
		if (miDisplayCustomMenu == null)
		{
			miDisplayCustomMenu = typeof(EditorUtility).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).Where(i => i.Name == "DisplayCustomMenu" && i.GetParameters().Length == 5).SingleOrDefault();
		}
		miDisplayCustomMenu.Invoke(null, new object[] { position, options, selected, callback, userData });

	}
}
