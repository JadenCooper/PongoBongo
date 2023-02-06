using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPartyColors", menuName = "Data/PartyColors")]
public class PartyColors : ScriptableObject
{
    public List<Color> ColorList = new List<Color>();
}
