using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Avalonia.Terminal.Extras
{
    internal class CircularBuffer<T>(int size) where T: class
    {
        public int Size { get { return size; } }
        private T[] _buffer = new T[size];
        private int _idx = size -1;
        public T Peek() => _buffer[_idx];
        public T Add(T value) => _buffer[_idx = (_idx + 1) % _buffer.Length] = value;
        public T GetNext() => _buffer[_idx = (_idx+1) % _buffer.Length];
        public T GetPrevious() => _buffer[_idx = (_idx - 1 + _buffer.Length) % _buffer.Length];
        public bool HasNext() => _idx < _buffer.Length && _buffer[(_idx + 1) % _buffer.Length] is not null;
    }
}
