using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Simple_layout_random))]
public class Simple_layout_random_Editor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		Simple_layout_random script = (Simple_layout_random)target;
		if (GUILayout.Button ("Layout Objects")) 
		{
			script.LayoutObjects ();
		}
	}
}
