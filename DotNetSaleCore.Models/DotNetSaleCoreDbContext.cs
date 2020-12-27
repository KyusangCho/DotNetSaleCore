using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DotNetSaleCore.Models
{
    /// <summary>
    /// DbContext Class
    /// </summary>
    public class DotNetSaleCoreDbContext : DbContext
    {
        public DotNetSaleCoreDbContext()
        {

        }

        public DotNetSaleCoreDbContext(DbContextOptions<DotNetSaleCoreDbContext> options)
            :base(options)
        {
            // 공식과 같은 코드 

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 영역: 기존 레거시 용도
            // App.config도는 Web.config 연결문자열 사용 
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customers 테이블의 Created 열은 자동으로 GetDate() 제약조건 부여 
            modelBuilder
                .Entity<Customer>()
                .Property(m => m.Created)
                .HasDefaultValueSql("GetDate()"); 
        }

        // [!] DotNetSaleCore 솔루션 관련 모든 테이블에 대한 참조 
        public DbSet<Customer> Customers { get; set; }

    }
}
