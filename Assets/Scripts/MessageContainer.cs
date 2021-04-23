using UnityEngine;

public class MessageContainer : MonoBehaviour
{
  public Chat Chat;
  public RectTransform ContainerObject;
  public GameObject MessagePrefab;
  public GameObject ChatOwnerMessagePrefab;

  public void AddMessage(Message message)
  {
    if (message.Sender == Chat.Owner)
    {
      var presenter = Instantiate(ChatOwnerMessagePrefab, ContainerObject).GetComponent<MessagePresenter>();
      presenter.Message = message;
    }
    else
    {
      var presenter = Instantiate(MessagePrefab, ContainerObject).GetComponent<MessagePresenter>();
      presenter.Message = message;
    }
  }

  private void Reset() =>
    Chat = FindObjectOfType<Chat>();
}