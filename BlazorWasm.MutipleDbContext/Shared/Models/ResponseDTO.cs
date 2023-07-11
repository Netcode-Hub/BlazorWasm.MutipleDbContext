using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasm.MutipleDbContext.Shared.Models
{
    public record struct ResponseDTO(int Id, string Name, string Location, List<Product> Products);
}
