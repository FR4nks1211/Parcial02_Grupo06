using System;
using UnityEngine;

public class TreeAVL : TreeABB
{

    public new void Insert(int value)
    {
        root = Insert(value, root);
    }


    private Node Insert(int value, Node node)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (value < node.dato)
        {
            node.izq = Insert(value, node.izq);
        }
        
        else 
        {
            node.der = Insert(value, node.der);
        }

        node.GameObject.transform.position = new Vector3(0,0,0);

        return Balance(node);
    }

    // Balancear nodo actual
    private Node Balance(Node node)
    {
        int balanceFactor = GetBalanceFactor(node);

        if (balanceFactor > 1)
        {
            if (GetBalanceFactor(node.izq) < 0)
            {
                node.izq = RotateLeft(node.izq);
            }

            return RotateRight(node);
        }

        if (balanceFactor < -1)
        {
            if (GetBalanceFactor(node.der) > 0)
            {
                node.der = RotateRight(node.der);
            }

            return RotateLeft(node);
        }

        return node; 
    }

    private int GetBalanceFactor(Node node)
    {
        if (node == null)
        {
            return 0;
        }
        return Altura(node.izq) - Altura(node.der);
    }

    private Node RotateRight(Node y)
    {
        Node x = y.izq;
        Node temporalTree = x.der;

        x.der = y;
        y.izq = temporalTree;

        return x;
    }

    private Node RotateLeft(Node x)
    {
        Node y = x.der;
        Node temporalTree = y.izq;

        y.izq = x;
        x.der = temporalTree;

        return y;
    }
}