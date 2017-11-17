using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcApp.Models;
namespace firstMvcApp.Infrastructure
{
    public class SampleModleRepository : IRepository<SampleModel, int>
    {
        List<SampleModel> list;
        public SampleModleRepository()
        {
            list = new List<SampleModel>
            {
                new SampleModel { Id=1501, Name ="Example 1501"},
                new SampleModel { Id=1502, Name ="Example 1502"},
                new SampleModel { Id=1503, Name ="Example 1503"},
                new SampleModel { Id=1504, Name ="Example 1504"}
            };
        }
        public List<SampleModel> GetAll()
        {
            return list;
        }

        public SampleModel GetDetails(int id)
        {
            return list.FirstOrDefault(c => c.Id == id);
        }
        public void Create(SampleModel item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SampleModel item)
        {
            throw new NotImplementedException();
        }
    }
}