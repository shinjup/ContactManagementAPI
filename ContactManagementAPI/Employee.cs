using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ContactManagementAPI
{
    public class Employee : IEmployee
    {
        public List<Contact> Get()
        {
            return LoadJson();
        }

        public Contact GetById(int id)
        {
            var data = LoadJson().Where(f => f.Id == id).FirstOrDefault();
            return data;
        }

        public bool Create(Contact contact)
        {
            var data = LoadJson();
            var nextId = 0;
            if (data.Any())
            {
                nextId = data.Max(d => d.Id) + 1;
            }
            contact.Id = nextId;
            data.Add(contact);
            string output = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("MockData.json", output);
            return true;
        }

        public bool Update(Contact contact)
        {
            var existingData = LoadJson();
            var data = existingData.Where(f => f.Id == contact.Id).FirstOrDefault();
            data.Email = contact.Email;
            data.FirstName = contact.FirstName;
            data.LastName = contact.LastName;
            string output = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText("MockData.json", output);
            return true;
        }

        public bool Delete(int id)
        {
            var existingData = LoadJson();
            var contact = existingData.Where(f => f.Id == id).FirstOrDefault();
            var data = existingData.Remove(contact);
            string output = JsonConvert.SerializeObject(existingData, Formatting.Indented);
            File.WriteAllText("MockData.json", output);
            return true;
        }

        private List<Contact> LoadJson()
        {
            var data = new List<Contact>();
            using (StreamReader r = new StreamReader("MockData.json"))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<Contact>>(json);
            }
            return data.OrderBy(d => d.Id).ToList();
        }
    }
}
