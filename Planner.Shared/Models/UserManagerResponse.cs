using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class UserManagerResponse
    {
        public UserManagerResponse()
        {

        }

        public UserManagerResponse(string message, bool success = false)
        {
            this.Message = message;
            this.Success = success;
        }

        public UserManagerResponse(string token, bool success, DateTime? expiredDate)
        {
            this.Token = token;
            this.Success = success;
            this.ExpiredDate = expiredDate;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
