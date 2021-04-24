using DG.Tweening;
using UnityEngine;

public class DeleteMessageMode : MonoBehaviour
{
  public MessageContainer Container;
  public GameObject DeleteMessageArea;
  public GameObject SendMessageArea;
  public float TransitionTime;

  public void SetActive(bool value)
  {
    var offset = value ? -100.0f : 0.0f;
    Container.ContainerObject.DOAnchorPosX(offset, TransitionTime);
    
    DeleteMessageArea.SetActive(value);
    SendMessageArea.SetActive(!value);
  }

  private void Reset() => 
    Container = FindObjectOfType<MessageContainer>();
}