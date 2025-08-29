using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] TMPro.TextMeshProUGUI scoreUI;
    [SerializeField] int score;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ScoreUp(int gettingScore)
    {
        score += gettingScore;
    }
    // Update is called once per frame
    void Update()
    {
        scoreUI.text = $"{score}";
    }
}
