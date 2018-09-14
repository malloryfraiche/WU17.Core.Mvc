using HeaderInspector.Models;
using HeaderInspector.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HeaderInspector.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult NewHeaderInspector()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewHeaderInspector(Inspector inspector)
        {
            // Here we have the logics for when the user clicks the "Inspect" button to get the results.
            if (ModelState.IsValid)
            {
                // Send the users input into our Repository
                HeaderRepository.AddInspector(inspector);

                List<string> headerKeys = new List<string>();
                List<string> headerValues = new List<string>();

                // Users entered url.
                var url = inspector.Url;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string enteredExcludedHeaders = inspector.ExcludedHeaders;
                string[] excludedHeadersArray = enteredExcludedHeaders.Split(",");

                
                //Dictionary<object, string> theDictionary = new Dictionary<object, string>();
                //foreach (var item in response.Headers)
                //{
                //    if (!excludedHeadersArray.Contains(item))
                //    {
                //        for (int i = 0; i < response.Headers.Count; ++i)
                //        {
                //            theDictionary.Add(item, response.Headers[i]);
                //        }
                //    }
                //    else { continue; }
                //}
                //ViewBag.DictionaryTest = theDictionary;

                List<KeyValuePair<string, string>> testList = new List<KeyValuePair<string, string>>();
                foreach (string item in response.Headers)
                {
                    if (!excludedHeadersArray.Contains(item))
                    {
                        testList.Add(new KeyValuePair<string, string>(item, response.Headers[item]));
                    }
                    else
                    {
                        continue;
                    }
                }
                ViewBag.TestList = testList;
                for (int i = 0; i < testList.Count; ++i)
                {
                    var toPrint = testList[i];
                    ViewBag.ToPrint = toPrint;
                }
                







                foreach (string key in response.Headers)
                {
                    if (!excludedHeadersArray.Contains(key))
                    {
                        // To add the Key to the list.
                        headerKeys.Add(key);
                        // To add the Value to the list.
                        headerValues.Add(response.Headers[key]);
                    }
                    else
                    {
                        continue;
                    }
                }
                ViewBag.headKeys = headerKeys;
                ViewBag.headValues = headerValues;

                // Sends us to the "HeaderInspectorResults.cshtml" view
                // Along with the new info (users input saved in the "inspector" variable) as the model to the view.
                return View("HeaderInspectorResults", inspector);
            }
            else
            {
                // Something is wrong with the model - will return the original NewHeaderInspector.cshtml view.
                return View();
            }
        }
    }
}
