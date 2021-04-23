using System;
using System.Globalization;
using TMPro;
using UnityEngine;

public class MessagePresenter : MonoBehaviour
{
  public Message Message;
  public TMP_Text Nickname;
  public TMP_Text Content;
  public TMP_Text SendTime;

  private void Awake()
  {
    Nickname.text = Message.Sender;
    Content.text = Message.Content;
    SendTime.text = DateTime.Now.ToString("HH:mm:ss", new CultureInfo("ru-RU"));
  }
}