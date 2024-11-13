using System;
using System.Collections.Generic;
using System.Linq;

public class StaticSet<T> : ISetTDA<T>
{
    private T[] elements;
    private int count;
    private int capacity;

    public StaticSet(int capacity)
    {
        this.capacity = capacity;
        elements = new T[capacity];
        count = 0;
    }

    public void Add(T element)
    {
        if (count >= capacity)
        {
            throw new InvalidOperationException("El conjunto est� lleno.");
        }

        if (!Contains(element))
        {
            elements[count++] = element;
        }
    }

    public void Remove(T element)
    {
        int index = Array.IndexOf(elements, element, 0, count);
        if (index >= 0)
        {
            elements[index] = elements[--count];
            elements[count] = default(T);
        }
    }

    public bool Contains(T element)
    {
        return Array.IndexOf(elements, element, 0, count) >= 0;
    }

    public string Show()
    {
        return string.Join(", ", elements.Take(count));
    }

    public int Cardinality()
    {
        return count;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public ISetTDA<T> Union(ISetTDA<T> other)
    {
        StaticSet<T> unionSet = new StaticSet<T>(capacity + other.Cardinality());
        foreach (var element in elements.Take(count))
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
        StaticSet<T> intersectSet = new StaticSet<T>(capacity);
        foreach (var element in elements.Take(count))
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
        StaticSet<T> differenceSet = new StaticSet<T>(capacity);
        foreach (var element in elements.Take(count))
        {
            if (!other.Contains(element))
            {
                differenceSet.Add(element);
            }
        }
        return differenceSet;
    }
}