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
            var result = _jsonHelper.ReadFromJson("HtmlTest.json");
            return result;
        }

        public List<Questions> GetCssQuestions()
        {
            var result = _jsonHelper.ReadFromJson("Css.json");
            return result;
        }
        public List<Questions> GetJsQuestions()
        {
            var result = _jsonHelper.ReadFromJson("Js.json");
            return result;
        }
    }
}
