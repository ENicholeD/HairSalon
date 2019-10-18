using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;

namespace HairSalon
{
  public class Startup
  {
    public static class DBConfiguration
    {
        public static string ConnectionString = "server=localhost;  user id=root;password=epicodus;port=3306;database=salon;";
    }
  }
}