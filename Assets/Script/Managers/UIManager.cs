using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public List<TMP_Text> PlayerScoreTexts = new List<TMP_Text>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScores(Vector2 PlayerScores)
    {
        PlayerScoreTexts[0].text = PlayerScores.x.ToString();
        PlayerScoreTexts[1].text = PlayerScores.y.ToString();
    }
}
