using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LaneManager))]
public class LaneManagerEditor : Editor
{
	public override void OnInspectorGUI()
    {
		// Draw the normal inspector elements first.
		DrawDefaultInspector();

        // Get a reference to the script this class is an editor of.
        LaneManager script = (LaneManager)target;

		// Show a button to regenerate the lanes.
        if (GUILayout.Button("Regenerate lanes"))
        {
			if (Application.isPlaying)
            {
                script.RegenerateLanes();
			}
        }
	}
}
