namespace TesteDeLogica.Services
{
    public class Network 
    {
        private int NumberOfElement;

        public Network(int numberOfElement)  
        {
            if (numberOfElement <= 0)
                throw new ArgumentException("Please inform a valid number!");
            
            NumberOfElement = numberOfElement;
        }

        public void Connect()
        {

        }

        public bool Query()
        {
            return true;
        }
    }
}
