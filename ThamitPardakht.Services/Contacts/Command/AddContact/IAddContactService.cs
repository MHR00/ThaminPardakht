using ThamitPardakht.Common.Dto;

namespace ThamitPardakht.Services.Contacts.Command.AddContact
{
    public interface IAddContactService
    {
        ResultDto<ResultAddContactDto> Execute(RequestAddContactDto request);
    }
}