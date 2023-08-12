using Bootcamp.Models;
using Bootcamp.Repository.Interfaces;

namespace Bootcamp.Services
{
    public class GetTest : IGetTest
    {
        private readonly IJsonHelper _jsonHelper;

        public GetTest(IJsonHelper jsonHelper)
        {
            this._jsonHelper = jsonHelper;
        }


        public List<Questions> GetHtmlQuestions()
        {
            var result = _jsonHelper.ReadFromJson<List<Questions>>("HtmlTest.json");
            return result;
        }
    }
}
