using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABLeasing.Web.Models.Accounts.ViewModels
{
    public class ClientLoginViewModel
    {
        public Client Client { get; set; }
        public RegisterModel RegisterModel { get; set; }
    }
}