using UnityEngine;
using UnityEditor;
using RV.Map;

#if false
[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var lg = target as MapGenerator;
        if (GUILayout.Button("Generate Level"))
        {
            lg.instantiate();
        }

        if (lg.WorldSize.magnitude > 0 && lg.Map != null && GUILayout.Button("Delete Level"))
        {
            lg.Clear();
        }
    }

}
#endif