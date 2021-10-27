using Microsoft.EntityFrameworkCore;
using PhoneAppBackend.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.DB
{
    public class ApplicationDbContext : DbContext
    {

        private readonly string _connectionString;
        public ApplicationDbContext(string connectionString) : base()
        {
            _connectionString = connectionString;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageInformation> MessagesInformation { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
    }
}
