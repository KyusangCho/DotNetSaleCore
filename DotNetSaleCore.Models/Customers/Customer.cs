using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetSaleCore.Models
{
    /// <summary>
    /// 고객 모델 클래스: Customers 테이블과 일대일 매핑 
    /// </summary>
    [Table("Customers")]
    public class Customer
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string AddressDetail { get; set; }
        public string Phone1 { get; set; }
        public string Phone2  { get; set; }
        public string Phone3 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Mobile3 { get; set; }
        public string Zip { get; set; }
        public string Ssn1 { get; set; }
        public string Ssn2 { get; set; }
        public int? MemberDivision { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }

        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
    }
}
