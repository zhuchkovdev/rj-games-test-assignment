using UnityEditor;

namespace Editor
{
  [CustomEditor(typeof(Chat))]
  public class ChatEditor : UnityEditor.Editor
  {
    private const string ChatOwnerLabel = "Chat owner";
    private int _choiceIndex;
    private readonly string[] _defaultOptions = {"None"};
 
    public override void OnInspectorGUI ()
    {
      DrawDefaultInspector();
      
      if (target is Chat chat && chat.Members.Count > 0)
      {
        if (chat.Members.Count < _choiceIndex)
          _choiceIndex = 0;

        _choiceIndex = EditorGUILayout.Popup(ChatOwnerLabel, _choiceIndex, chat.Members.ToArray());
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