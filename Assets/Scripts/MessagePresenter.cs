using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessagePresenter : MonoBehaviour
{
  public TMP_Text Nickname;
  public TMP_Text Content;
  public TMP_Text SendTime;
  
  public Button DeleteButton;
  public GameObject Tail;
  public GameObject Portrait;
  
  public event Action<Message> OnMessageDelete;

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

  private void Awake()
  {
    if(DeleteButton)
      DeleteButton.onClick.AddListener(OnDeleteButtonClick);
  }

  private void Reset() => 
    DeleteButton = GetComponentInChildren<Button>();

  private void UpdatePresenter()
  {
    Nickname.text = Message.Sender;
    Content.text = Message.Content;
    SendTime.text = Message.SendTime.ToString("HH:mm:ss", new CultureInfo("ru-RU"));
  }

  private void OnDeleteButtonClick()
  {
    OnMessageDelete?.Invoke(_message);
  }

  public void Redraw(bool asLast)
  {
    Tail.SetActive(asLast);
    Portrait.SetActive(asLast);
  }
}