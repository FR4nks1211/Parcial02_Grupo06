using System;
using System.Collections.Generic;
using System.Linq;

public class DynamicSet<T> : ISetTDA<T>
{
    private List<T> elements;

    public DynamicSet()
    {
        elements = new List<T>();
    }

    public void Add(T element)
    {
        if (!elements.Contains(element))
        {
            elements.Add(element);
        }
    }

    public void Remove(T element)
    {
        elements.Remove(element);
    }

    public bool Contains(T element)
    {
        return elements.Contains(element);
    }

    public string Show()
    {
        return string.Join(", ", elements);
    }

    public int Cardinality()
    {
        return elements.Count;
    }

    public bool IsEmpty()
    {
        return elements.Count == 0;
    }

    public ISetTDA<T> Union(ISetTDA<T> other)
    {
        DynamicSet<T> unionSet = new DynamicSet<T>();
        foreach (var element in elements)
        {
            unionSet.Add(element);
        }
        foreach (var element in other.Show().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(e => (T)Convert.ChangeType(e, typeof(T))))
        {
            unionSet.Add(element);
        }
        return unionSet;
    }

    public ISetTDA<T> Intersect(ISetTDA<T> other)
    {
        DynamicSet<T> intersectSet = new DynamicSet<T>();
        foreach (var element in elements)
        {
            if (other.Contains(element))
            {
                intersectSet.Add(element);
            }
        }
        return intersectSet;
    }

    public ISetTDA<T> Difference(ISetTDA<T> other)
    {
        DynamicSet<T> differenceSet = new DynamicSet<T>();
        foreach (var element in elements)
        {
            if (!other.Contains(element))
            {
                differenceSet.Add(element);
            }
        }
        return differenceSet;
    }
}
