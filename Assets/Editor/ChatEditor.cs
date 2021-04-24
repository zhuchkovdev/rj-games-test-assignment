using UnityEditor;

namespace Editor
{
  [CustomEditor(typeof(Chat))]
  public class ChatEditor : UnityEditor.Editor
  {
    private const string ChatOwnerLabel = "Chat owner";
    private const string ChatOwnerIndex = "ChatOwnerIndex";
    private static int _choiceIndex;
    private readonly string[] _defaultOptions = {"None"};

    private void OnEnable()
    {
      _choiceIndex = EditorPrefs.GetInt(ChatOwnerIndex);
    }

    private void OnDisable()
    {
      EditorPrefs.SetInt(ChatOwnerIndex, _choiceIndex);
    }

    public override void OnInspectorGUI ()
    {
      DrawDefaultInspector();
      
      if (target is Chat chat && chat.Members.Count > 0)
      {
        var previousOwner = chat.Owner;
        
        if (_choiceIndex >= chat.Members.Count)
          _choiceIndex = 0;

        _choiceIndex = EditorGUILayout.Popup(ChatOwnerLabel, _choiceIndex, chat.Members.ToArray());

        if (previousOwner == chat.Members[_choiceIndex])
          return;
        
        chat.Owner = chat.Members[_choiceIndex];
        EditorUtility.SetDirty(target);
      }
      else
      {
        EditorGUILayout.Popup(ChatOwnerLabel, 0, _defaultOptions);
      }
    }
  }
}