﻿using Bootcamp.Models;

namespace Bootcamp.Repository.Interfaces
{
    public interface IGetTest
    {
        List<Questions> GetHtmlQuestions();
        List<Questions> GetCssQuestions();
        List<Questions> GetJsQuestions();
    }
}
