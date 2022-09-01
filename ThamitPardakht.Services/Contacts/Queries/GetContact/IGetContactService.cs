namespace ThamitPardakht.Services.Contacts.Queries.GetContact
{
    public interface IGetContactService
    {
        ResultGetContactDto Execute(ReqhestGetContactDto contact);
    }
}