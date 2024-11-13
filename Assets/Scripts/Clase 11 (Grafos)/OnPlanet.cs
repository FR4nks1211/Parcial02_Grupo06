using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OnPlanet : MonoBehaviour
{
    public string planetName;

    private void OnMouseDown()
    {
        GraphMapManager graphMapManager = FindObjectOfType<GraphMapManager>();
        if (graphMapManager != null)
        {
            graphMapManager.Travel(planetName);
        }
    }
}
