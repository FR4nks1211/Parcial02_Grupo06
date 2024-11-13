using System;
using UnityEngine;

public class TreeABB
{
    public Node root;

    public void Insert(int value)
    {
        if (root == null)
        {
            root = new Node(value);
        }
        else
        {
            Insert(value, root);
        }
    }

    private void Insert(int value, Node nodo)
    {
        if (value < nodo.dato)
        {
            if (nodo.izq != null)
            {
                Insert(value, nodo.izq);
            }
            else
            {
                nodo.izq = new Node(value);
            }
        }
        else
        {
            if (nodo.der != null)
            {
                Insert(value, nodo.der);
            }
            else
            {
                nodo.der = new Node(value);
            }
        }
    }

    public static int Altura(Node nodo)
    {
        if (nodo == null)
        {
            return -1;
        }
        else
        {
            return 1 + Math.Max(Altura(nodo.izq), Altura(nodo.der));
        }
    }

    public string RecorridoInOrden(Node nodo)
    {
        if (nodo == null) return "";
        return RecorridoInOrden(nodo.izq) + nodo.dato + " " + RecorridoInOrden(nodo.der);
    }

    public string RecorridoPreOrden(Node nodo)
    {
        if (nodo == null) return "";
        return nodo.dato + " " + RecorridoPreOrden(nodo.izq) + RecorridoPreOrden(nodo.der);
    }

    public string RecorridoPostOrden(Node nodo)
    {
        if (nodo == null) return "";
        return RecorridoPostOrden(nodo.izq) + RecorridoPostOrden(nodo.der) + nodo.dato + " ";
    }
}