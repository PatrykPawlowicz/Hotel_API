namespace Hotel_API.Models
{
        public class ServiceResponse<T>
        {
            public decimal id { get; set; }
            public T data { get; set; }
            public bool success { get; set; } = true;
            public string messsage { get; set; } = null;
        }
}
