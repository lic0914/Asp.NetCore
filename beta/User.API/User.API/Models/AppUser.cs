using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }
        public string Phone { get; set; }
        public int ProvinceId { get; set; }
        public string Province { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string NameCard{ get; set; }
        public List<UserProperty> Properties { get; set; }
    }
}
