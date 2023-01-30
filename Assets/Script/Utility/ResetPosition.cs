using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    private Vector3 Position;
    void Start()
    {
        Position = gameObject.transform.localPosition;
    }

    public void ReturnPosition()
    {
        gameObject.transform.localPosition = Position;
    }
}
