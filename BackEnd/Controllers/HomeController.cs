using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using System.Text;

namespace BackEnd.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {

            SqlConnection conn = new SqlConnection("Server=tcp:wimp.database.windows.net,1433;Initial Catalog=WhereIsMyPooDB;Persist Security Info=False;User ID=lolicon;Password=Admin1100;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            conn.Close();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kanom", conn);

            var v = "Taro_spicy";
            SqlCommand cmdX = new SqlCommand("SELECT * FROM Kanom WHERE NAME ='"+ v + "' OR NAME = 'Taro_barbq'", conn);

            SqlDataReader reader = cmdX.ExecuteReader();
            List<Kanom> kanoms = new List<Kanom>();
            while (reader.Read())
            {
                Kanom kanom = new Kanom();
                kanom.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                kanom.Name = reader.GetString(reader.GetOrdinal("Name"));
                kanom.Unit = reader.GetInt32(reader.GetOrdinal("Unit"));
                kanom.Calories = reader.GetInt32(reader.GetOrdinal("Calories"));
                kanom.Sugar = reader.GetInt32(reader.GetOrdinal("Sugar"));
                kanom.Oil = reader.GetInt32(reader.GetOrdinal("Oil"));
                kanom.Sodium = reader.GetInt32(reader.GetOrdinal("Sodium"));
                kanoms.Add(kanom);
            }
            ViewBag.kanoms = kanoms;
            ViewBag.cmdX = cmdX;
            return View();
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
