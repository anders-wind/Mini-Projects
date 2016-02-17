﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioSite.ViewModels
{
    public class HomeViewModel
    {
        public string HeaderTitle { get; set; }

        public string MainTitle { get; set; }
        public string MainText { get; set; }
        public string ProfilePicLink { get; set; }

        public string AboutTitle { get; set; }
        public string AboutText { get; set; }

        public string ServicesTitle { get; set; }
        public IEnumerable<Tuple<string,Uri>> ServicesCollection { get; set; } // text, imageUri

        public IEnumerable<ProjectViewModel> ProjectCollection { get; set; }

        public string ContactTitle { get; set; }
        public string ContactText { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string CellPhoneNumber { get; set; }
    }
}
