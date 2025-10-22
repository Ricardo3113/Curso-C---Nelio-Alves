using System;

namespace Generics_exemplo01
{
    class PrintService<T>
    {
        private T[] _values = new T[10];
        private int _count = 0;
        
        //operações 
        public void AddValue(T value) //adiciona um valor int value como argumento no vetor _values 
        {
            if (_count == 10)
            {
                throw new InvalidOperationException("PrintService is full");
            }
            _values[_count] = value; //o vetor _values na posição _count vai receber o valor value...na posição count q começa na primeira posição do vetor q é 0 e recebe o valor informado 
            _count++; //atualização do vetor count
        }

        public T First() 
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("PrintService is empty");
            }
            return _values[0];
        }

        public void Print() 
        {
            Console.Write("[");
            for (int i = 0; i < _count - 1; i++)
            {
                Console.Write(_values[i] + ", ");
            }
            if (_count > 0)
            {
                Console.Write(_values[_count - 1]);
            }
            Console.WriteLine("]");
        }
    }
}
