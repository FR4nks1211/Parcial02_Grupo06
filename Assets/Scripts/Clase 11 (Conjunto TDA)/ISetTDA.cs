using System;
using System.Collections.Generic;

public interface ISetTDA<T>
{
    void Add(T element);
    void Remove(T element);
    bool Contains(T element);
    string Show();
    int Cardinality();
    bool IsEmpty();
    ISetTDA<T> Union(ISetTDA<T> other);
    ISetTDA<T> Intersect(ISetTDA<T> other);
    ISetTDA<T> Difference(ISetTDA<T> other);
}

