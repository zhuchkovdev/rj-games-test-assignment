using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MessageSender : MonoBehaviour
{
  public InputAction SendMessageAction;
  public TMP_InputField MessageField;
  public Chat Chat;

  private void OnEnable() => 
    SendMessageAction.Enable();

  private void OnDisable() => 
    SendMessageAction.Disable();

  private void Awake() => 
    SendMessageAction.performed += OnSendMessageAction;

  public void Send()
  {
    if(string.IsNullOrEmpty(MessageField.text)) 
      return;
    
    var message = new Message(Chat.RandomMember, MessageField.text);
    Chat.ReceiveMessage(message);
    MessageField.text = string.Empty;
  }

  private void OnSendMessageAction(InputAction.CallbackContext ctx)
  {
    if(MessageField.isFocused) 
      Send();
  }

  private void Reset() => 
    Chat = FindObjectOfType<Chat>();
}