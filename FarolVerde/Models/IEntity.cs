using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarolVerde.Models
{
    public interface IEntity
    {
        int Id { get; set; }
        bool Active { get; set; }
    }
}
