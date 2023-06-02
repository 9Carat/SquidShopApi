﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SquidShopApi.Models.DTO
{
    public class UserDTO
    {
        [StringLength(50)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(70)]
        public string Address { get; set; }
        [StringLength(20)]
        public string PostalCode { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        public string FK_UsersId { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
