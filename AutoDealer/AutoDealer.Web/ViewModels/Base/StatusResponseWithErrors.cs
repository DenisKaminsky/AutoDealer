using System.Collections.Generic;

namespace AutoDealer.Web.ViewModels.Base
{
    public class StatusResponseWithErrors : BaseStatusResponse
    {
        public IEnumerable<Error> Errors { get; set; }
    }
}
