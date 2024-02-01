using System.Text;

internal class Vault<T>
    where T : struct
{
    /// <summary>
    /// Agrega elementos al final de la lista
    /// </summary>
    /// <param name="value"></param>
    public void Add(T value)
    {
        _Values.Add(value);
        _IsChange = true;
    }
    /// <summary>
    /// Indexer del vault para tratar los elementos
    /// </summary>
    /// <param name="i">índice del elemento</param>
    /// <returns>Retorna el elemento en ele índice dato</returns>
    public T this[int i]
    {
        get
        {
            return _Values[i];
        }
        set
        {
            _Values[i] = value;
        }
    }
    /// <summary>
    /// Elimina un elemento especifico de la lista
    /// </summary>
    /// <param name="value"></param>
    public void Remove(T value)
    {
        _Values.Remove(value);
        _IsChange = true;
    }
    /// <summary>
    /// Elimina un rango determinado de elementos
    /// </summary>
    /// <param name="value"></param>
    public void RemoveRange(int index, int count)
    {
        _Values.RemoveRange(index, count);
        _IsChange = true;
    }
    /// <summary>
    /// Retorna el elemento que haga match con la expresión dada
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public T? First(Func<T, bool> expression)
    {
        foreach (var item in _Values)
        {
            if (expression(item)) return item;
        }

        return default!;
    }
    /// <summary>
    /// Retorna en base a 0 la posición del elemento en no ser encontrado retorna -1
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int IndexOf(T value) => _Values.IndexOf(value);
    /// <summary>
    /// Retorna en base a 0 la posición del elemento en no ser encontrado retorna -1
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public int IndexOfAlter(T value)
    {
        for (int i = 0; i < _Count; i++)
        {
            if (_Values[i].Equals(value)) return i;
        }

        return -1;
    }
    /// <summary>
    /// Ordena los elementos con extensiones de linq
    /// </summary>
    public void OrderValuesLinq()
    {
        _Values = [.. _Values.Order()];
        _IsChange = true;
    }
    /// <summary>
    /// Ordena los elementos con el comparador predeterminado 
    /// </summary>
    public void OrderValuesSort()
    {
        _Values.Sort();
        _IsChange = true;
    }
    /// <summary>
    /// Reordena de manera contraria los elementos del vault
    /// </summary>
    public void Reverse()
    {
        _Values = OrderDescending().ToList();
        _IsChange = true;
    }
    /// <summary>
    /// Retorna la lista de valores de manera inversa
    /// </summary>
    /// <returns></returns>
    private IEnumerable<T> OrderDescending()
    {
        //Reorganizamos los elementos de maneta inversa
        for (int i = _Values.Count - 1; i > 0; i--)
        {
            yield return _Values[i];
        }
    }
    public override string ToString()
    {
        //Miramos si hubo algun cambio en la vida util del vault
        if (_IsChange == false)
        {
            return _DataSource;
        }

        _IsChange = false;
        var result = new StringBuilder();
        for (int i = 0; i < _Count; i++)
        {
            result.Append(_Values[i].ToString());
        }

        _DataSource = result.ToString();
        return _DataSource;
    }
    public int _Count { get { return _Values.Count; } }
    private bool _IsChange = false;
    private string _DataSource { get; set; } = string.Empty;
    private List<T> _Values = [];
}