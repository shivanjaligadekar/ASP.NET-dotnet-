namespace BusinessLogicLibrary
{
    public class CustomerBAL

    {
        private int _custid;
        private string _custname;

        public int CustomerId
        {
            get { return _custid; }
            set { _custid = value; }
        }
        public string CustomerName
        {
            get { return _custname; }
            set { _custname = value; }
        }
    }
}
