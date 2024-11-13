using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ShowNodes Mostrar;
    public Sprite defaultSprite;
    private Vector2 start;

    private void Awake()
    {
        start = new Vector2 (0, 0);
        Instance = this;
        Mostrar = FindObjectOfType<ShowNodes>();
    }

    private void Start()
    {
        //TreeABB.root
        //Mostrar.ShowOrderNodes(nodo, position, offSetX, offSetY);
    }
}