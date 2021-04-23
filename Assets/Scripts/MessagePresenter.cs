using System.Globalization;
using TMPro;
using UnityEngine;

public class MessagePresenter : MonoBehaviour
{
  public TMP_Text Nickname;
  public TMP_Text Content;
  public TMP_Text SendTime;

  private Message _message;

  public Message Message
  {
    get => _message;
    set
    {
      _message = value;
      UpdatePresenter();
    }
  }
  
  private void UpdatePresenter()
  {
    Nickname.text = Message.Sender;
    Content.text = Message.Content;
    SendTime.text = Message.SendTime.ToString("HH:mm:ss", new CultureInfo("ru-RU"));
  }
}