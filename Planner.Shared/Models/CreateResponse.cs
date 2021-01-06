using Planner.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class CreateResponse<TResponse>
    {
        public TResponse Response { get; set; }
        public ResponseResultEnum Result { get; set; }
    }
}
