using System.IO;
using UnityEditor;
using UnityEngine;

namespace Extensions.ScriptableObjects
{
    
    public static class ScriptableObjectAssetCreator
    {
        [MenuItem("Extensions/Create ScriptableObject")]
        public static void Create()
        {
            var script = Selection.activeObject as MonoScript;
            var type = script.GetClass();
            var scriptableObject = ScriptableObject.CreateInstance(type);
            var path = Path.GetDirectoryName(AssetDatabase.GetAssetPath(script));
            AssetDatabase.CreateAsset(scriptableObject, $"{path}/{Selection.activeObject.name}.asset");
        }

        [MenuItem("Extensions/Create ScriptableObject Validated", true)]
        public static bool ValidateCreate()
        {
            var script = Selection.activeObject as MonoScript;
            return script != null && script.GetClass().IsSubclassOf(typeof(ScriptableObject));
        }
    }
}