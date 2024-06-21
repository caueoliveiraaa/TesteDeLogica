using System;
using System.Collections.Generic;

namespace TesteDeLogica.Services
{
    public class Network 
    {
        private int _numberOfElements;
        private Dictionary<int, List<int>> _elements; 

        public Network(int numberOfElements)
        {
            if (numberOfElements <= 1)
                throw new ArgumentException("At least two elements are necessary to instantiate an object.");
            
            _numberOfElements = numberOfElements;
            _elements = new Dictionary<int, List<int>>();
            
            AddAllElements();
        }

        private void AddAllElements()
        {
            for (int e = 0; e < _numberOfElements; e++)
                _elements[e + 1] = new List<int>();

            ShowAllElements();
        }

        private void ShowAllElements()
        {
            foreach (var kvp in _elements)
                Console.WriteLine($"Element: {kvp.Key}, connections: {string.Join(", ", kvp.Value)}");
        }

        private void ValidateConnection(int firstElement, int secondElement)
        {
            if (!_elements.ContainsKey(firstElement))
                throw new ArgumentException("Element does not exist in this instance.");

            if (_elements[firstElement].Contains(secondElement))
                throw new ArgumentException($"The connection between {firstElement} and {secondElement} already exists.");
        }

        public void Connect(int firstElement, int secondElement)
        {
            ValidateConnection(firstElement, secondElement);

            _elements[firstElement].Add(secondElement);

            Console.WriteLine($"The connection between {firstElement} and {secondElement} created successfully.");
        }

        public bool Query(int firstElement, int secondElement)
        {
            return true;
        }
    }
}
