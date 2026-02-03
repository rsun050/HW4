using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    [SerializeField] public static float PipeSpeed { get; private set; } = 3;
    [SerializeField] private GameObject PipePrefab;
    [SerializeField] private TMP_Text ScoreText;

    private float _timer;
    [SerializeField] private float PipeFrequency;

    private bool _gameover;

    public delegate void GameOverD();
    public event GameOverD GameOverE;

    private int _score;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        PointsGiver.Instance.GetPointE += HandleGetPoint;

        _score = 0;
        _timer = 0.0f;
        _gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_gameover)
        {
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        if(_timer <= 0.0f)
        {
            _timer = PipeFrequency;
            Instantiate(PipePrefab, transform);
            // Debug.Log("Spawn a pipe");
        }

        _timer -= Time.deltaTime;   
    }

    public void HandleGameOver()
    {
        _gameover = true;
        GameOverE.Invoke();
    }

    private void HandleGetPoint()
    {
        _score++;
        ScoreText.text = "" + _score;
    }
}
