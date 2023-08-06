using System;
using System.Collections.Generic;
using System.Text;

namespace bruno.CatalogFilms.Model.View
{
    public class ErrorViewModel
    {
        public int ErrorCode { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }

    public class ResponseErrorMessages
    {
        public List<string> Messages { get; set; }
    }
}
