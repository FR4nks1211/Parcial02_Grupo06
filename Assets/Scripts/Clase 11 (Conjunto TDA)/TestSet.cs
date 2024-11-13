using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSet
{
    public static void Main()
    {
        ISetTDA<int> dynamicSet = new DynamicSet<int>();
        ISetTDA<int> staticSet = new StaticSet<int>(10);

        dynamicSet.Add(1);
        dynamicSet.Add(2);
        dynamicSet.Add(3);

        staticSet.Add(2);
        staticSet.Add(3);
        staticSet.Add(4);

        Console.WriteLine("DynamicSet: " + dynamicSet.Show());
        Console.WriteLine("StaticSet: " + staticSet.Show());

        var unionSet = dynamicSet.Union(staticSet);
        Console.WriteLine("Union: " + unionSet.Show());

        var intersectSet = dynamicSet.Intersect(staticSet);
        Console.WriteLine("Intersect: " + intersectSet.Show());

        var differenceSet = dynamicSet.Difference(staticSet);
        Console.WriteLine("Difference: " + differenceSet.Show());
    }
}