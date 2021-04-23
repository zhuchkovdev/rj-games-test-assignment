using TMPro;
using UnityEngine;

public class MessageSender : MonoBehaviour
{
  public TMP_Text MessageField;
  public Chat Chat;
  
  public void Send()
  {
    if(string.IsNullOrEmpty(MessageField.text)) 
      return;
    
    var message = new Message(Chat.Owner, MessageField.text);
    Chat.ReceiveMessage(message);
  }

  private void Reset() => 
    Chat = FindObjectOfType<Chat>();
}