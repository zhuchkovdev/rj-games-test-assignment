using TMPro;
using UnityEngine;

public class MessageSender : MonoBehaviour
{
  public TMP_InputField MessageField;
  public Chat Chat;
  
  public void Send()
  {
    if(string.IsNullOrEmpty(MessageField.text)) 
      return;
    
    var message = new Message(Chat.RandomMember, MessageField.text);
    Chat.ReceiveMessage(message);
    MessageField.text = string.Empty;
  }

  private void Reset() => 
    Chat = FindObjectOfType<Chat>();
}