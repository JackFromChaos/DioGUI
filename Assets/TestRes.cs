using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TestRes   : ScriptableObject, ISerializationCallbackReceiver
{

	public string jsonModel;
	[System.NonSerialized]
	public TestResModel model = new TestResModel();
	public void OnBeforeSerialize()
	{
		jsonModel = JsonConvert.SerializeObject(model);
		//jsonModel = JsonUtility.ToJson(model);
		//Debug.Log("OnBeforeSerialize");
	}
	public void OnAfterDeserialize()
	{
		model = JsonConvert.DeserializeObject<TestResModel>(jsonModel);
		//model = JsonUtility.FromJson<TestResModel>(jsonModel);
		//Debug.Log("OnAfterDeserialize");
	}

}

[System.Serializable]
public class TestResModel
{
	public string name;
	public int id;
	public Color color;
}

[CustomEditor(typeof(TestRes))]
public class TestResEditor : Editor
{
	[MenuItem("Assets/Create/TestRes")]
	public static void CreateYourScriptableObject()
	{
		EditorUtils.CreateAsset2<TestRes>();
	}
	public override void OnInspectorGUI()
	{
		//base.OnInspectorGUI();
		TestResModel model = (target as TestRes).model;
		//bool curChanged = GUI.changed;
		//GUI.changed = false;
		EditorGUI.BeginChangeCheck();
		//Undo.RecordObject(target, "Change test changed");
		model.name = EditorGUILayout.TextField("Name", model.name);
		model.id = EditorGUILayout.IntField("Id", model.id);
		model.color = EditorGUILayout.ColorField(model.color);
		EditorGUILayout.TextArea((target as TestRes).jsonModel);

		if (EditorGUI.EndChangeCheck())
		{
			//Debug.Log("Changed!!!");
			//Undo.ClearUndo();
		}
		//GUI.changed = curChanged;
	}
}