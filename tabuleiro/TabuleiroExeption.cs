using System;

namespace tabuleiro
{
    internal class TabuleiroExeption : Exception
    {
        public TabuleiroExeption(string message) : base(message) { }
    }
}
