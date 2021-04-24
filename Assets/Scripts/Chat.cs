using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
  [HideInInspector] public string Owner;
  public List<string> Members = new List<string>();
  public MessageContainer Container;
  
  public string RandomMember => Members[Random.Range(0, Members.Count)];

  public void ReceiveMessage(Message message) => 
    Container.AddMessage(message);

  private void Reset() => 
    Container =  FindObjectOfType<MessageContainer>();
}