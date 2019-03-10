using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ConcurrencyConflictInEFCore
{
    class Person
    {
        public int PersonId { get; set; }
        //[ConcurrencyCheck]
        [StringLength(16)]
        public string FirstName { get; set; }
        [StringLength(16)]
        public string LastName { get; set; }
        public string FullName
        {
            get=>LastName+","+FirstName;
        }
        [StringLength(6,MinimumLength =1)]
        public string Gender { get; set; }
        [StringLength(12)]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$",ErrorMessage ="电话号码的格式不正确")]
        public string PhoneNumber { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
