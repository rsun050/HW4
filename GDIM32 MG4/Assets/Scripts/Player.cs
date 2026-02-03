using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float JumpPower;
    [SerializeField] private AudioSource JumpSFX;
    [SerializeField] private Rigidbody2D _rb;

    private bool _canplay;

    // Start is called before the first frame update
    void Start()
    {
        GameController.Instance.GameOverE += HandleGameOver;
        _canplay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_canplay)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _rb.velocity = Vector2.up * JumpPower;
                JumpSFX.Play();
            }            
        }
    }

    public void HandleGameOver()
    {
        _canplay = false;
        transform.localScale = new Vector3(2, -2, 2); // flip player upside down bcuz they dead lol
    }
}
