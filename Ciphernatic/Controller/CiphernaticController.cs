using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Ciphernatic.Models;
using Microsoft.Owin.Hosting.Tracing;

namespace Ciphernatic.Controller
{
    /// <summary>
    /// The purpose of this class is to serve as the main controller for the API components accessible 
    /// via web interface.  
    /// </summary>
    public class CiphernaticController : ApiController
    {
        /// <summary>
        /// Returns a collection of hash value types base on the requested parameter values.
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet]
        public IList<HashCollection> GetHashList(string value)
        {
            // transform enum list to collection
            var hashOptions = Helpers.GetEnumCollection<HashOptions>().ToList();
            // define an empty collection
            var list = new List<HashCollection>();
            // loop through each enum options an add to collection
            foreach (var option in hashOptions)
            {
                var output = HashAlgorithm.HashValue(option, value);
                list.Add(new HashCollection
                {
                    Description = output.Description,
                    Value = output.OutputValue,
                    Type = Helpers.EnumDisplayName(option)
                });
            }

            // remove the exit option from list
            list.RemoveAt(0);
            // remove the web services option from list
            list.RemoveAt(11);
            return list;
        }
    }
}
