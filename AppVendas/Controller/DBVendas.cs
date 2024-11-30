using AppVendas.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVendas.Controller
{
    internal class DBVendas : DbContext
    {
        public DBVendas() : base(@"Server=JUN0675608W10-1\BDSENAC; Database=Loja09; 
                                user id=senaclivre; password = senaclivre")

        { 

        }

        public DbSet<Vendas> Vendas { get; set; }   
    }
}
