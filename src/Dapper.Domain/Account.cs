using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Domain;


public class Account
{
    public long Id { get; set; }

    public string Owner { get; set; }

    public decimal Balance { get; set; }

    public string Currency { get; set; }
}

