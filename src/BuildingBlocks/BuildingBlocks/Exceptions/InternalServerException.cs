namespace BuildingBlocks.Exceptions
{
    public class InternalServerException:Exception
    {
        public string Detailes { get; set; }
        public InternalServerException(string message):base(message)
        {
            
        }
        public InternalServerException(string message,string details):base(message)
        {
            Detailes = details;
        }

    }
}
