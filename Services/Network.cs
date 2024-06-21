using System;
using System.Collections.Generic;

namespace TesteDeLogica.Services
{
    public class Network 
    {
        private int _elementsAmount;
        private Dictionary<int, List<int>> _elements; 

        public Network(int elementsAmount)
        {
            if (elementsAmount <= 1)
                throw new ArgumentException("At least two elements are necessary to make connections.");
            
            _elementsAmount = elementsAmount;
            _elements = new Dictionary<int, List<int>>();
            
            SetUpAllElements();
        }

        private void SetUpAllElements()
        {
            for (int e = 0; e < _elementsAmount; e++)
                _elements[e + 1] = new List<int>();
        }

        private void ValidateElements(List<int> elements)
        {
            foreach(var element in elements)
            {
                if (!_elements.ContainsKey(element))
                    throw new ArgumentException($"Element {element} does not exist.");
            }
        }

        private void ValidateNewConnection(int firstElement, int secondElement)
        {
            ValidateElements( new List<int>() { firstElement, secondElement } );

            if (_elements[firstElement].Contains(secondElement))
                throw new ArgumentException($"The connection between {firstElement} and {secondElement} already exists.");
        }

        private void JoinConnections(int firstElement, int secondElement)
        {
            List<int> firstConnections = _elements[firstElement];
            List<int> secondConnections = _elements[secondElement];
            
            for (int i = 0; i < firstConnections.Count; i++)
            {
                if (!_elements[secondElement].Contains(firstConnections[i]))
                    _elements[secondElement].Add(firstConnections[i]);

                if (!_elements[firstConnections[i]].Contains(secondElement))
                    _elements[firstConnections[i]].Add(secondElement);
            }
            
            for (int i = 0; i < secondConnections.Count; i++)
            {
                if (!_elements[firstElement].Contains(secondConnections[i]))
                    _elements[firstElement].Add(secondConnections[i]);

                if (!_elements[secondConnections[i]].Contains(firstElement))
                    _elements[secondConnections[i]].Add(firstElement);
            }
        }

        public void Connect(int firstElement, int secondElement)
        {
            ValidateNewConnection(firstElement, secondElement);
            JoinConnections(firstElement, secondElement);

            _elements[firstElement].Add(secondElement);
            _elements[secondElement].Add(firstElement);

            Console.WriteLine($"Connect: {firstElement} and {secondElement} = OK.");
        }

        public bool Query(int firstElement, int secondElement)
        {
            ValidateElements( new List<int>() { firstElement, secondElement } );

            bool connectionExists = _elements[firstElement].Contains(secondElement);

            Console.WriteLine($"Query: {firstElement} and {secondElement} = {connectionExists}.");

            return connectionExists;
        }

        public void ShowAllElements()
        {
            foreach (var keyAndValues in _elements)
                Console.WriteLine($"Element: {keyAndValues.Key}, connections made: {string.Join(", ", keyAndValues.Value)}");
        }
    }
}
