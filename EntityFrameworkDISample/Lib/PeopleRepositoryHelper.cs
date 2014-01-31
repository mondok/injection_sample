using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using EntityFrameworkDISample.Models;
using StructureMap;

namespace EntityFrameworkDISample.Lib
{
    public class PeopleRepositoryHelper
    {
        public async Task<Person> FindByIdAsync(int id)
        {
            EfSampleContext context = ObjectFactory.GetInstance<EfSampleContext>();
            return await context.People.FindAsync(id);
        }
        public async Task<Person> SaveOrUpdate(Person person)
        {
            EfSampleContext context = ObjectFactory.GetInstance<EfSampleContext>();
            if (person.Id == 0)
            {
                context.People.Add(person);
            }
            else
            {
                context.People.Attach(person);
            }
            await context.SaveChangesAsync();
            return person;
        }
    }
}