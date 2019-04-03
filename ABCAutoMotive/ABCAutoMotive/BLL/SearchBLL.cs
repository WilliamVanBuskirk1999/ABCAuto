using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Entities;
using Model.Lists;
using SQLLayer;
using Types;

namespace BLL
{
    public class SearchBLL
    {
        public List<ResourceLookup> resourcesToBeCheckedOut = new List<ResourceLookup>();
        public List<StudentLookup> GetStudentList(string parameter)
        {
            SearchDB search = new SearchDB();
            return search.SearchForStudent(parameter);
        }

        public List<ResourceLookup> GetResourceList(string parameter)
        {
            SearchDB search = new SearchDB();
            return search.SearchForResource(parameter);
        }

      
    }
}
