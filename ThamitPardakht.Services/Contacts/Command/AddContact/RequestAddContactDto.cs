namespace ThamitPardakht.Services.Contacts.Command.AddContact
{
 
        public class RequestAddContactDto
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MobileNumber { get; set; }
            public List<UserContactDto> users { get; set; }
        }
   
}
