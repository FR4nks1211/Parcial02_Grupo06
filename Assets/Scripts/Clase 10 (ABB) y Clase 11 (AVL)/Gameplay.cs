using UnityEngine;
using TMPro;

public class GamePlay : MonoBehaviour
{
    TreeABB tree;
    public int[] ArbolVacio = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

    public ShowNodes showNodes;
    public TextMeshProUGUI profundidadText;
    public TextMeshProUGUI recorridoText;

    public void Start()
    {
        tree = new TreeABB();

        for (int i = 0; i < ArbolVacio.Length; i++)
        {
            tree.Insert(ArbolVacio[i]);
        }

        int profundidad = TreeABB.Altura(tree.root);
        profundidadText.text = "Profundidad máxima: " + profundidad;

        MostrarRecorridos();
        showNodes.ShowOrderNodes(tree.root, new Vector3(0, 0, 0), 4.0f, 2.0f);
    }

    private void MostrarRecorridos()
    {
        string inOrden = tree.RecorridoInOrden(tree.root);
        string preOrden = tree.RecorridoPreOrden(tree.root);
        string postOrden = tree.RecorridoPostOrden(tree.root);

        recorridoText.text = "Recorridos:\nInOrden: " + inOrden + "\nPreOrden: " + preOrden + "\nPostOrden: " + postOrden;
    }
}