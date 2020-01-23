using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models.Extended
{
    [MetadataType(typeof(CheckOutMetData))]
    public partial class Checkouts
    {
        public int CheckOut_ID { get; set; }
        public int UserID { get; set; }
        public int Inventory_ID { get; set; }
        public System.DateTime CheckOut_Date { get; set; }
        public System.DateTime Return_Date { get; set; }
        public Nullable<System.DateTime> Actual_Return_Date { get; set; }

        public virtual BookInventory BookInventory { get; set; }
        public virtual LibraryUsers LibraryUsers { get; set; }
    }

    public class CheckOutMetData
    {
        public int CheckOut_ID { get; set; }
        public int UserID { get; set; }
        public int Inventory_ID { get; set; }

        [Required(ErrorMessage = "Please Enter CheckOut date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy hh:mm tt}")]
        public System.DateTime CheckOut_Date { get; set; }

        
        public System.DateTime Return_Date { get; set; }
        public Nullable<System.DateTime> Actual_Return_Date { get; set; }

        public virtual BookInventory BookInventory { get; set; }
        public virtual LibraryUsers LibraryUsers { get; set; }

    }
}