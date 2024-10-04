using System.Collections.Generic;

namespace ContactManagementAPI
{
    public interface IEmployee
    {
        List<Contact> Get();
        Contact GetById(int id);
        bool Create(Contact contact);
        bool Update(Contact contact);
        bool Delete(int id);
    }
}
