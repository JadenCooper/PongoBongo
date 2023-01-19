using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlaySettingData", menuName = "Data/PlaySettings")]
public class PlaySettingsSO : ScriptableObject
{
    // This Data File Holds The Setting For The Play State
    [SerializeField]
    private int[] _playerTypes;

    public int[] PlayerTypes
    {
        get { return _playerTypes;  }
        set { _playerTypes = PlayerTypes; }
    }

    [SerializeField]
    private float[] _otherSettings;

    public float[] OtherSettings
    {
        get { return _otherSettings; }
        set { _otherSettings = OtherSettings; }
    }
}
