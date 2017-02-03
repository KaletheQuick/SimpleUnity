using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Simple_layout_liniar))]
public class Simple_layout_liniar_Editor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();

		Simple_layout_liniar script = (Simple_layout_liniar)target;
		if (GUILayout.Button ("Layout Objects")) 
		{
			script.Layout ();
		}
	}
}
