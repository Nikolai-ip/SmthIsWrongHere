using _Game.Scripts.Features.MiniGames.Common;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObjectsRandomizePlacer))]
[CanEditMultipleObjects]   
public class ObjectsRandomizePlacerEditor: Editor
{
    public override void OnInspectorGUI()
    {
        var objectRandomizePlacer = (ObjectsRandomizePlacer)target;
        DrawDefaultInspector();
        if (GUILayout.Button(new GUIContent("PlaceObjects")))
        {
            objectRandomizePlacer.PlaceObjects();
        }
    }
}