using UnityEngine;
using System.Collections;

public interface ICalculator<T, U>
{
    T Calculate(U u);
}
