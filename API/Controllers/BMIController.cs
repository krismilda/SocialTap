using DataModels;
using Logic;
using System.Web.Http;

namespace API.Controllers
{
    public class BMIController : ApiController
    {
        // PUT: api/BMI
        [AllowAnonymous]
        public IHttpActionResult Put([FromUri]BMICalculationData data)
        {
            var bmiCalc = new CountBMI();
            var bmi = bmiCalc.GetBMI(data.Weight, data.Height);
            return Ok(bmi);
        }
    }
}
