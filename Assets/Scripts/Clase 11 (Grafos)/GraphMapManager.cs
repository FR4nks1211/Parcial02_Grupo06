using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphMapManager : MonoBehaviour
{
    private Graph graph;

    public string currentPlanet;
    public TextMeshProUGUI travelCostText;
    public TextMeshProUGUI statusText;
    public int currentPoints = 100;
    public TextMeshProUGUI pointsText;

    void Start()
    {
        graph = new Graph();
        graph.AddNode("Venus");
        graph.AddNode("Earth");
        graph.AddNode("Mars");
        graph.AddNode("Jupiter");

        graph.AddConnection("Venus", "Earth", 10);
        graph.AddConnection("Venus", "Mars", 50);
        graph.AddConnection("Venus", "Jupiter", 20);
        graph.AddConnection("Earth", "Mars", 35);
        graph.AddConnection("Earth", "Jupiter", 90);

        currentPlanet = "Earth";

        ShowTravelCostsFromEarth();
        pointsText.text = $"Puntos Restante: {currentPoints}";
    }

    private void ShowTravelCostsFromEarth()
    {
        string travelCosts = "Costos de viaje desde la Tierra:\n";

        foreach (var connection in graph.nodes["Earth"])
        {
            travelCosts += $"a {connection.Destination}: {connection.Cost}\n";
        }
        travelCostText.text = travelCosts;
    }

    public void Travel(string destination)
    {
        if (graph.nodes.ContainsKey(currentPlanet) && graph.nodes.ContainsKey(destination))
        {
            foreach (var connection in graph.nodes[currentPlanet])
            {
                if (connection.Destination == destination)
                {
                    if (currentPoints >= connection.Cost)
                {
                    currentPoints -= connection.Cost;

                    statusText.text = $"Viajando de {currentPlanet} a {destination}. Costo: {connection.Cost}";

                    currentPlanet = destination;

                    pointsText.text = $"Puntos Restantes: {currentPoints}";

                    ShowTravelCostsFromEarth();
                }
                else
                {
                    statusText.text = "No tienes suficientes puntos para viajar.";
                }
                return;
                }
            }
            statusText.text = "Ruta no disponible.";
        }
        else
        {
            statusText.text = "Destino no válido.";
        }
    }
}
