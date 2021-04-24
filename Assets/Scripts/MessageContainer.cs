using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MessageContainer : MonoBehaviour
{
  public Chat Chat;
  public RectTransform ContainerObject;
  public GameObject MessagePrefab;
  public GameObject ChatOwnerMessagePrefab;

  private readonly List<MessagePresenter> _presenters = new List<MessagePresenter>();

  private void OnDestroy()
  {
    foreach (MessagePresenter presenter in _presenters)
      presenter.OnMessageDelete -= DeleteMessage;
  }

  private void Reset() =>
    Chat = FindObjectOfType<Chat>();

  public void AddMessage(Message message)
  {
    MessagePresenter presenter = InstantiatePresenter(message);
    presenter.OnMessageDelete += DeleteMessage;
  }

  private MessagePresenter InstantiatePresenter(Message message)
  {
    MessagePresenter presenter = message.Sender == Chat.Owner
      ? Instantiate(ChatOwnerMessagePrefab, ContainerObject).GetComponent<MessagePresenter>()
      : Instantiate(MessagePrefab, ContainerObject).GetComponent<MessagePresenter>();

    MessagePresenter lastMessage = _presenters.LastOrDefault();
    if (lastMessage && lastMessage.Message.Sender == message.Sender)
      lastMessage.Redraw(asLast: false);

    presenter.Message = message;
    _presenters.Add(presenter);

    return presenter;
  }

  private void DeleteMessage(Message message)
  {
    MessagePresenter presenter = _presenters.FirstOrDefault(o => o.Message == message);
    if (!presenter)
      return;
    
    RedrawPreviousIfNeeded(presenter);
    DestroyMessagePresenter(presenter);
  }

  private void DestroyMessagePresenter(MessagePresenter presenter)
  {
    presenter.OnMessageDelete -= DeleteMessage;
    _presenters.Remove(presenter);
    Destroy(presenter.gameObject);
  }

  private void RedrawPreviousIfNeeded(MessagePresenter presenter)
  {
    var index = _presenters.IndexOf(presenter);

    MessagePresenter previous = ValidIndex(index - 1) ? _presenters[index - 1] : null;

    MessagePresenter next = ValidIndex(index + 1) ? _presenters[index + 1] : null;

    if (ShouldRedrawPrevious())
      previous.Redraw(asLast: true);

    bool ShouldRedrawPrevious() =>
      previous && (!next || next && next.Message.Sender != presenter.Message.Sender);
  }

  private bool ValidIndex(int index) => 
    index >= 0 && index < _presenters.Count;
}