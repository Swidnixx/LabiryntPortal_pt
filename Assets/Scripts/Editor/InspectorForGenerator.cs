using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Generator))]
public class InspectorForGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Generuj"))
        {
            Generator g = target as Generator;
            g.Generate();
        }
        if (GUILayout.Button("Wyczy��"))
        {
            Generator g = target as Generator;
            g.Clear();
        }
    }
}
