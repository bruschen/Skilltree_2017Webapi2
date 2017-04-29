using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using D1_Lab05_ParameterBinding.Models;

namespace D1_Lab05_ParameterBinding.Controllers
{
    public class ModelBindingController : ApiController
    {

        /// <summary>
        /// Samples the binding.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// GET /api/ModelBinding/SampleBinding/10
        /// GET /api/ModelBinding/SampleBinding?id=10
        [HttpGet]
        public string SampleBinding(int id)
        {
            return id.ToString();
        }

        /// <summary>
        /// Options the parameters.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// GET /api/ModelBinding/OptionParams/10
        [HttpGet]
        public string OptionParams(int? id = null)
        {
            if (id == null)
            {
                return "id 不得為空！";
            }
            return id.ToString();
        }

        [HttpPost]
        public string idFromBody([FromBody]int id)
        {
            return id.ToString();
        }

        [HttpGet, HttpPost]
        public string idUriNameBody(int id, [FromBody]string name)
        {
            return $"Id:{id}, name:{name}";
        }

        [HttpPost]
        public string Customer(Customer customer)
        {
            return customer.ToString();
        }

        /// <summary>
        /// post two complex object
        /// </summary>
        /// <param name="customer1">The customer1.</param>
        /// <param name="customer2">The customer2.</param>
        /// <returns></returns>
        [HttpPost]
        public string MultiCustomer(Customer customer1, Customer customer2)
        {
            return $"{customer1.ToString()}, {customer2.ToString()}";
        }

    }
}
