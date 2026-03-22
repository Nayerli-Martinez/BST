using System;

class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class ArbolBinarioBusqueda
{
    private Nodo raiz;

    public ArbolBinarioBusqueda()
    {
        raiz = null;
    }

    // Insertar un valor
    public void Insertar(int valor)
    {
        raiz = InsertarRecursivo(raiz, valor);
    }

    private Nodo InsertarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null)
            return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);

        return nodo;
    }

    // Buscar un valor
    public bool Buscar(int valor)
    {
        return BuscarRecursivo(raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return false;
        if (nodo.Valor == valor) return true;

        return valor < nodo.Valor
            ? BuscarRecursivo(nodo.Izquierdo, valor)
            : BuscarRecursivo(nodo.Derecho, valor);
    }

    // Eliminar un valor
    public void Eliminar(int valor)
    {
        raiz = EliminarRecursivo(raiz, valor);
    }

    private Nodo EliminarRecursivo(Nodo nodo, int valor)
    {
        if (nodo == null) return nodo;

        if (valor < nodo.Valor)
            nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
        else
        {
            // Caso 1: sin hijos
            if (nodo.Izquierdo == null && nodo.Derecho == null)
                return null;

            // Caso 2: un hijo
            if (nodo.Izquierdo == null)
                return nodo.Derecho;
            else if (nodo.Derecho == null)
                return nodo.Izquierdo;

            // Caso 3: dos hijos
            nodo.Valor = Minimo(nodo.Derecho);
            nodo.Derecho = EliminarRecursivo(nodo.Derecho, nodo.Valor);
        }
        return nodo;
    }

    // Recorridos
    public void Preorden() => PreordenRecursivo(raiz);
    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            Console.Write(nodo.Valor + " ");
            PreordenRecursivo(nodo.Izquierdo);
            PreordenRecursivo(nodo.Derecho);
        }
    }

    public void Inorden() => InordenRecursivo(raiz);
    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            InordenRecursivo(nodo.Izquierdo);
            Console.Write(nodo.Valor + " ");
            InordenRecursivo(nodo.Derecho);
        }
    }

    public void Postorden() => PostordenRecursivo(raiz);
    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo != null)
        {
            PostordenRecursivo(nodo.Izquierdo);
            PostordenRecursivo(nodo.Derecho);
            Console.Write(nodo.Valor + " ");
        }
    }

    // Mínimo
    public int Minimo()
    {
        return Minimo(raiz);
    }

    private int Minimo(Nodo nodo)
    {
        if (nodo == null) throw new InvalidOperationException("Árbol vacío");
        while (nodo.Izquierdo != null)
            nodo = nodo.Izquierdo;
        return nodo.Valor;
    }

    // Máximo
    public int Maximo()
    {
        if (raiz == null) throw new InvalidOperationException("Árbol vacío");
        Nodo nodo = raiz;
        while (nodo.Derecho != null)
            nodo = nodo.Derecho;
        return nodo.Valor;
    }

    // Altura
    public int Altura()
    {
        return AlturaRecursiva(raiz);
    }

    private int AlturaRecursiva(Nodo nodo)
    {
        if (nodo == null) return 0;
        int izquierda = AlturaRecursiva(nodo.Izquierdo);
        int derecha = AlturaRecursiva(nodo.Derecho);
        return Math.Max(izquierda, derecha) + 1;
    }

    // Limpiar árbol
    public void Limpiar()
    {
        raiz = null;
    }
}

class Program
{
    static void Main()
    {
        ArbolBinarioBusqueda bst = new ArbolBinarioBusqueda();
        int opcion;

        do
        {
            Console.WriteLine("\n--- MENÚ BST ---");
            Console.WriteLine("1. Insertar");
            Console.WriteLine("2. Buscar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar Preorden");
            Console.WriteLine("5. Mostrar Inorden");
            Console.WriteLine("6. Mostrar Postorden");
            Console.WriteLine("7. Mostrar Mínimo");
            Console.WriteLine("8. Mostrar Máximo");
            Console.WriteLine("9. Mostrar Altura");
            Console.WriteLine("10. Limpiar Árbol");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese valor: ");
                    bst.Insertar(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.Write("Ingrese valor a buscar: ");
                    Console.WriteLine(bst.Buscar(int.Parse(Console.ReadLine())) ? "Encontrado" : "No encontrado");
                    break;
                case 3:
                    Console.Write("Ingrese valor a eliminar: ");
                    bst.Eliminar(int.Parse(Console.ReadLine()));
                    break;
                case 4:
                    Console.Write("Preorden: ");
                    bst.Preorden();
                    Console.WriteLine();
                    break;
                case 5:
                    Console.Write("Inorden: ");
                    bst.Inorden();
                    Console.WriteLine();
                    break;
                case 6:
                    Console.Write("Postorden: ");
                    bst.Postorden();
                    Console.WriteLine();
                    break;
                case 7:
                    Console.WriteLine("Mínimo: " + bst.Minimo());
                    break;
                case 8:
                    Console.WriteLine("Máximo: " + bst.Maximo());
                    break;
                case 9:
                    Console.WriteLine("Altura: " + bst.Altura());
                    break;
                case 10:
                    bst.Limpiar();
                    Console.WriteLine("Árbol limpiado.");
                    break;
            }

        } while (opcion != 0);
    }
}
