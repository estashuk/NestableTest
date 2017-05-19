using System;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace Nestable_test.Domain.Entities
{
    public class MenuData
    {
        [Key]
        public int Id { get; set; }
        public string MenuConfig { get; set; }
    }
}