using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TextMeshProUGUI pointsText;
    public void IncreaseScore()
    {
        score = score + 1;
        pointsText.text = "Points:" + score;
    }
     
}
