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
            {
                _elements[e] = new List<int>();
            }
        }

        private void ValidateElement()
        {
            if (!_elements.Any())
                throw new ArgumentException("There are not elements to validate.");
            
        }

        public void Connect(int firstElement, int secondElement)
        {

        }

        public bool Query(int firstQueryElement, int secondQueryElement)
        {
            return true;
        }
    }
}
