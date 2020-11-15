using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectPortfolio2_Group11.Model
{
    public class SearchHistoryDto
    {
        public int UserId { get; set; }
        public string SearchInput { get; set; }
        public DateTime DateTime { get; set; }
    }
}