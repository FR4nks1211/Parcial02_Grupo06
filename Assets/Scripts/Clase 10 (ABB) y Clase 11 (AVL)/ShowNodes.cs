using UnityEngine;
using TMPro;

public class ShowNodes : MonoBehaviour
{
    [SerializeField] private GameObject nodeObject;
    [SerializeField] private Material lineMaterial;




    private void Awake()
    {

    }

    public void ShowOrderNodes(Node nodo, Vector2 position, float offSetX, float offSetY)
    {
    if (nodo != null)
    {

        GameObject newNode = Instantiate(nodeObject, new Vector3(position.x, position.y, 0), Quaternion.identity);

        TextMeshProUGUI nodeValue = newNode.GetComponentInChildren<TextMeshProUGUI>();
        if (nodeValue != null)
        {
            nodeValue.text = nodo.dato.ToString();
        }
        else
        {
            Debug.LogWarning("No se encontró el componente TMP_Text en el prefab nodeObject.");
        }

        if (nodo.izq != null)
        {
            Vector2 leftPosition = position + new Vector2(-offSetX, -offSetY);
            ShowOrderNodes(nodo.izq, leftPosition, offSetX * 0.5f, offSetY);
            DrawLine(new Vector3(position.x, position.y, 0), new Vector3(leftPosition.x, leftPosition.y, 0));
        }

        if (nodo.der != null)
        {
            Vector2 rightPosition = position + new Vector2(offSetX, -offSetY);
            ShowOrderNodes(nodo.der, rightPosition, offSetX * 0.5f, offSetY);
            DrawLine(new Vector3(position.x, position.y, 0), new Vector3(rightPosition.x, rightPosition.y, 0));
        }
    }
}

    private void DrawLine(Vector3 start, Vector3 end)
    {
        GameObject lineObject = new GameObject("Line");
        LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();

        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;

        if (lineMaterial != null)
        {
            lineRenderer.material = lineMaterial;
        }
        else
        {
            Debug.LogWarning("No se asign� un material al LineRenderer, utilizando material predeterminado.");
        }

        start.z = 0;
        end.z = 0;

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}