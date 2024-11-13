using UnityEngine;

public class AVLGamePlay : MonoBehaviour
{
    TreeAVL tree;
    public int[] ArbolVacio = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

    public ShowNodes showNodes;

    public void Start()
    {
        tree = new TreeAVL();

        for (int i = 0; i < ArbolVacio.Length; i++)
        {
            tree.Insert(ArbolVacio[i]);
        }

        showNodes.ShowOrderNodes(tree.root, new Vector3(0, 0, 0), 4.0f, 2.0f);
    }
}
