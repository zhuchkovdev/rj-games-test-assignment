using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PortraitProvider
{
  private const string DefaultPortrait = "Default";
  private static readonly Dictionary<string, Sprite> Portraits;

  static PortraitProvider()
  {
    Portraits = Resources.LoadAll<Sprite>("Portraits")
      .ToDictionary(x => x.name, x => x);
  }

  public static Sprite ForMember(string memberName) => 
    Portraits.TryGetValue(memberName.Replace(" ", "_"), out Sprite portrait) 
      ? portrait 
      : Portraits[DefaultPortrait];
}