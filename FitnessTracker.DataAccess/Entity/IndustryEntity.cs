using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.DataAccess.Entity
{
    public class IndustryEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserEntity> Users { get; set; }
    }
}