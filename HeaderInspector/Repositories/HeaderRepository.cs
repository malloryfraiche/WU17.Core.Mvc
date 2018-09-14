using HeaderInspector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeaderInspector.Repositories
{
    // Repo class to save the information entered by the user in the Header Inspector form.
    public static class HeaderRepository
    {
        private static List<Inspector> _inspectors = new List<Inspector>();
        public static IEnumerable<Inspector> InspectorInfo
        {
            get { return _inspectors; }
        }

        // Here we add the users input to the list we created above.
        public static void AddInspector(Inspector inspector)
        {
            _inspectors.Add(inspector);
        }
    }
}
