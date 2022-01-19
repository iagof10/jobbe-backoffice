﻿using API.Data.Mapping;
using API.Data.Mappings;
using API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<SubCategoria> SubCategoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }


        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(new UserMap().Configure);
            modelBuilder.Entity<Categoria>(new CategoriaMap().Configure);
            modelBuilder.Entity<SubCategoria>(new SubCategoriaMap().Configure);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }
    }
}
