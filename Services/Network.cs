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
                throw new ArgumentException("At least two elements are necessary to make connections.");
            
            _numberOfElements = numberOfElements;
            _elements = new Dictionary<int, List<int>>();
            
            AddAllElements();
        }

        private void AddAllElements()
        {
            for (int e = 0; e < _numberOfElements; e++)
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

        private void VerifyIfConnectionExists(int firstElement, int secondElement)
        {
            ValidateElements( new List<int>() { firstElement, secondElement } );

            if (_elements[firstElement].Contains(secondElement))
                throw new ArgumentException($"The connection between {firstElement} and {secondElement} already exists.");
        }

        private void BridgeConnections(int firstElement, int secondElement)
        {
            List<int> firstElementConnections = _elements[firstElement];
            
            for (int i = 0; i < firstElementConnections.Count; i++)
            {
                if (!_elements[secondElement].Contains(firstElementConnections[i]))
                    _elements[secondElement].Add(firstElementConnections[i]);

                if (!_elements[firstElementConnections[i]].Contains(secondElement))
                    _elements[firstElementConnections[i]].Add(secondElement);
            }

            List<int> secondElementConnections = _elements[secondElement];
            
            for (int i = 0; i < secondElementConnections.Count; i++)
            {
                if (!_elements[firstElement].Contains(secondElementConnections[i]))
                    _elements[firstElement].Add(secondElementConnections[i]);

                if (!_elements[secondElementConnections[i]].Contains(firstElement))
                    _elements[secondElementConnections[i]].Add(firstElement);
            }
        }

        public void Connect(int firstElement, int secondElement)
        {
            VerifyIfConnectionExists(firstElement, secondElement);
            BridgeConnections(firstElement, secondElement);

            _elements[firstElement].Add(secondElement);
            _elements[secondElement].Add(firstElement);

            Console.WriteLine($"Connect: {firstElement} and {secondElement} = successfully.");
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
            Console.WriteLine($"\nAll connections of current instance:");

            foreach (var keyAndValues in _elements)
                Console.WriteLine($"Element: {keyAndValues.Key}, connections made: {string.Join(", ", keyAndValues.Value)}");
        }
    }
}
