﻿using JokJaBre.Core.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KAkica.Domain.Models
{
    public class Activity : IJokJaBreModel
    {
        public long Id { get; set; }
        public bool Poop { get; set; }
        public bool Whizz { get; set; }

        public DateTime Timestamp { get; set; }

        public long PooperId { get; set; }
        public virtual Pooper Pooper { get; set; }
    }

    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Timestamp).IsRequired();

            builder.HasOne(e => e.Pooper)
                .WithMany(e => e.Activities)
                .HasForeignKey(e => e.PooperId);
        }
    }
}