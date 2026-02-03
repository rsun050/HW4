using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsGiver : MonoBehaviour
{
    public static PointsGiver Instance { get; private set; }
    public delegate void GetPointD();
    public event GetPointD GetPointE;
    [SerializeField] private AudioSource PointSFX;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Pipe"))
        {
            PointSFX.Play();
            GetPointE.Invoke();        
        }
    }
}