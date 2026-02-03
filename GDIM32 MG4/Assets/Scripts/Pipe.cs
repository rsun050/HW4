using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private bool move;
    [SerializeField] private AudioSource GameOverSFX;

    void Start()
    {
        GameController.Instance.GameOverE += HandleGameOver;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            transform.Translate(Vector2.left * GameController.PipeSpeed * Time.deltaTime);                
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            GameOverSFX.Play();
            Debug.Log("gameover");
            GameController.Instance.HandleGameOver();
        }
    }

    public void HandleGameOver()
    {
        move = false;
    }
}
