using System;

[Serializable]
public class Message
{
  public string Sender;
  public string Content;
  public DateTime SendTime;

  public Message(string sender, string content)
  {
    Sender = sender;
    Content = content;
    SendTime = DateTime.Now;
  }
}