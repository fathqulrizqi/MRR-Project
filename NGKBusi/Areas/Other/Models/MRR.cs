using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace NGKBusi.Areas.Other.Models
{
    public class MRR
    {
    }

    public class OTH_MRR_Master_Rooms_Category
    {

        [Key]
        public int ID { get; set; }
        public string Category { get; set; }
    }
    
    public class OTH_MRR_Master_Rooms
    {

        [Key]
        public int ID { get; set; }
        public string RoomTitle { get; set; }
        public string Image { get; set; }
        public int IDRoomCat { get; set; }
        public int? ExtensionNumber { get; set; }
    }

    public class OTH_MRR_Rooms_Properties
    {
        [Key]
        public int ID { get; set; }
        public int RoomID { get; set; }
        public string PropsName { get; set; }
        public int Quantity { get; set; }
    }

    public class OTH_MRR_Bookings
    {
        [Key]
        public int ID { get; set; }
        public int UserNIK { get; set; }
        public int RoomsPropsID { get; set; }
        public string Subject { get; set; }
        public string Remarks { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Boolean Status { get; set; }
        public DateTime Timestamps { get; set; }
    }

    public class OTH_MRR_Booking_Tools
    {
        [Key]
        public int ID { get; set; }
        public int BookingID { get; set; }
        public int ToolID { get; set; }
    }

    public class OTH_MRR_Master_Additional_Tools
    {
        [Key]
        public int ID { get; set; }
        public string ToolName { get; set; }
        public int Quantity { get; set; }
    }
    public class JS_OTH_MRR_Master_Rooms
    {

        public int ID { get; set; }
        public string RoomTitle { get; set; }
        public string Image { get; set; }
        public int IDRoomCat { get; set; }
        public int? ExtensionNumber { get; set; }
    }
    public class Tbl_Rooms_Detail
    {
        public int ID { get; set; }
        public string Location { get; set; }
        public int ExtensionNumber { get; set; }
        public int RoomID { get; set; }
        public int RoomTitle { get; set; }
        public string PropsName { get; set; }
        public int Quantity { get; set; }
    }


    public class MRRConnection : DbContext
    {
        public DbSet<OTH_MRR_Master_Rooms> OTH_MRR_Master_Rooms { get; set; }
        public DbSet<OTH_MRR_Master_Rooms_Category> OTH_MRR_Master_Rooms_Category { get; set; }
        public DbSet<OTH_MRR_Rooms_Properties> OTH_MRR_Rooms_Properties { get; set; }
        public DbSet<OTH_MRR_Bookings> OTH_MRR_Bookings { get; set; }
        public DbSet<OTH_MRR_Booking_Tools> OTH_MRR_Booking_Tools { get; set; }
        public DbSet<OTH_MRR_Master_Additional_Tools> OTH_MRR_Master_Additional_Tools { get; set; }
        public MRRConnection()
        {
            this.Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}