using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DatPhongKhachSanWeb.Models
{
    public class DateSearch
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yy-mm-dd:0}")]
        public DateTime daNgayden { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yy-mm-dd:0}")]
        public DateTime daNgaydi { get; set; }        
    }
}