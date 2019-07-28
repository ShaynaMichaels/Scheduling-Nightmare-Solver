﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CapstoneProject.Controllers;
using CapstoneProject.Models;
using System.Data;

namespace CapstoneProject.Models
{


    public class Client
    {
        public int Id { get; set; }

        public string[] DatesAvailable { get; set; }
        public (bool AvailableHour, int Hour)[] HoursAvailable { get; set; }
        public DataSet Availibility = new DataSet();


        public Client()
        {
            this.Availibility = CreateYearDataSet(DateTime.Now.Year.ToString());
        }

        DataSet CreateYearDataSet(string year)
        {
            DataSet dbset = new DataSet();
            string[] months = { "Jan", "Feb", "March", "April", "May", "June", "Jul", "Aug", "Sept", "Oct", "Nov", "Dec" };

            for (int i = 0; i < 11; i++)
            {
                dbset.Tables.Add(CreateMonthTable(months[i]));
            }

            return dbset;
        }

        DataTable CreateMonthTable(string month)
        {
            DataTable dataTable = new DataTable(month);

            dataTable.Columns.Add("Monday", typeof((int, int)));
            dataTable.Columns.Add("Tuesday", typeof((int, int)));
            dataTable.Columns.Add("Wednesday", typeof((int, int)));
            dataTable.Columns.Add("Thursday", typeof((int, int)));
            dataTable.Columns.Add("Friday", typeof((int, int)));
            dataTable.Columns.Add("Saturday", typeof((int, int)));
            dataTable.Columns.Add("Sunday", typeof((int, int)));

            DataRow Week1 = dataTable.NewRow();
            DataRow Week2 = dataTable.NewRow();
            DataRow Week3 = dataTable.NewRow();
            DataRow Week4 = dataTable.NewRow();
            DataRow Week5 = dataTable.NewRow();

            Week1["Monday"] = (0, 0);
            Week1["Tuesday"] = (0, 0);
            Week1["Wednesday"] = (0, 0);
            Week1["Thursday"] = (0, 0);
            Week1["Friday"] = (0, 0);
            Week1["Saturday"] = (0, 0);
            Week1["Sunday"] = (0, 0);

            Week2["Monday"] = (0, 0);
            Week2["Tuesday"] = (0, 0);
            Week2["Wednesday"] = (0, 0);
            Week2["Thursday"] = (0, 0);
            Week2["Friday"] = (0, 0);
            Week2["Saturday"] = (0, 0);
            Week2["Sunday"] = (0, 0);

            Week3["Monday"] = (0, 0);
            Week3["Tuesday"] = (0, 0);
            Week3["Wednesday"] = (0, 0);
            Week3["Thursday"] = (0, 0);
            Week3["Friday"] = (0, 0);
            Week3["Saturday"] = (0, 0);
            Week3["Sunday"] = (0, 0);

            Week4["Monday"] = (0, 0);
            Week4["Tuesday"] = (0, 0);
            Week4["Wednesday"] = (0, 0);
            Week4["Thursday"] = (0, 0);
            Week4["Friday"] = (0, 0);
            Week4["Saturday"] = (0, 0);
            Week4["Sunday"] = (0, 0);

            Week5["Monday"] = (0, 0);
            Week5["Tuesday"] = (0, 0);
            Week5["Wednesday"] = (0, 0);
            Week5["Thursday"] = (0, 0);
            Week5["Friday"] = (0, 0);
            Week5["Saturday"] = (0, 0);
            Week5["Sunday"] = (0, 0);

            return dataTable;
        }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }



        [Required]
        [Display(Name = "Client Group")]
        public int GroupNameId { get; set; }

        [ForeignKey("GroupNameId")]
        public IEnumerable<GroupName> ClientGroup { get; set; }
        
    }
}
