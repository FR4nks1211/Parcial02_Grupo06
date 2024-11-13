using UnityEngine;
public class Node
{
    public int dato;
    public Node izq;
    public Node der;
    public GameObject GameObject { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }

    public Node(int dato)
    {
        this.dato = dato;
        this.izq = null;
        this.der = null;

        GameObject = new GameObject();
        SpriteRenderer = GameObject.AddComponent<SpriteRenderer>();
        SpriteRenderer.sprite = GameManager.Instance.defaultSprite;
        GameObject.name = "Nodo: " + dato;

        GameObject.transform.position = new Vector3(GameObject.transform.position.x, GameObject.transform.position.y, 0);
    }
}