﻿using SingleServiceApp.Bll.Statistics;
using SingleServiceApp.Providers.Auth;
using SingleServiceApp.Providers.Statistics.Entity;

namespace SingleServiceApp.Providers.Statistics
{
    public static class StatisticInitializer
    {
        public static void Initialize(StatisticDbContext context, AuthContext auth)
        {
            if (context.Colors.Count() == 0)
                context.Colors.AddRange(new[]
                {
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0xFF6600)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0xFF9400)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0xFEC600)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0xFFFF00)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0x8DC700)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0x0FAD00)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0x00A2C8)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0x0064B4)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0x0010A5)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0x6100A5)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0xC4017C)
                },
                new ColorSql
                {
                    Color = System.Drawing.Color.FromArgb(0xFE0000)
                },
            });

            context.SaveChanges();

            context.Tags.AddRange(new[]
            {
                new Tag
                {
                    Name = "Expenses",
                    MaxValue = null,
                    User = auth.GetCurrentUser()
                },
                new Tag
                {
                    Name = "WorkTime",
                    MaxValue = null,
                    User = auth.GetCurrentUser()
                },
                new Tag
                {
                    Name = "KCal",
                    MaxValue = null,
                    User = auth.GetCurrentUser()
                }
            });

            context.SaveChanges();

            context.Title.AddRange(new[]
            {
                new Title
                {
                    Name = "Bus",
                    ColorSql = context.Colors.ToList().ElementAt(0),
                    Tag = context.Tags.ToList().ElementAt(0)
                },
                new Title
                {
                    Name = "Food",
                    ColorSql = context.Colors.ToList().ElementAt(5),
                    Tag = context.Tags.ToList().ElementAt(0)
                },
                new Title
                {
                    Name = "Other",
                    ColorSql = context.Colors.ToList().ElementAt(7),
                    Tag = context.Tags.ToList().ElementAt(0)
                },
                new Title
                {
                    Name = "Work",
                    ColorSql = context.Colors.ToList().ElementAt(4),
                    Tag = context.Tags.ToList().ElementAt(1)
                },
                new Title
                {
                    Name = "University",
                    ColorSql = context.Colors.ToList().ElementAt(8),
                    Tag = context.Tags.ToList().ElementAt(1)
                },
                new Title
                {
                    Name = "KCal",
                    ColorSql = context.Colors.ToList().ElementAt(10),
                    Tag = context.Tags.ToList().ElementAt(2)
                },
            });

            context.SaveChanges();
            Random rnd = new Random();

            for (int i = 0; i < 7; i++)
            {
                context.Statistics.AddRange(new[]
                {
                    new Statistic
                    {
                        User = auth.GetCurrentUser(),
                        Date = new DateTime(2021,12,20+i),
                        Tag = context.Tags.ToList().ElementAt(0),
                        Title = context.Title.ToList().ElementAt(0),
                        Value = rnd.Next(0,101),
                    },
                    new Statistic
                    {
                        User = auth.GetCurrentUser(),
                        Date = new DateTime(2021,12,20+i),
                        Tag = context.Tags.ToList().ElementAt(0),
                        Title = context.Title.ToList().ElementAt(1),
                        Value = rnd.Next(0,101),
                    },
                    new Statistic
                    {
                        User = auth.GetCurrentUser(),
                        Date = new DateTime(2021,12,20+i),
                        Tag = context.Tags.ToList().ElementAt(0),
                        Title = context.Title.ToList().ElementAt(2),
                        Value = rnd.Next(0,101),
                    },
                    new Statistic
                    {
                        User = auth.GetCurrentUser(),
                        Date = new DateTime(2021,12,20+i),
                        Tag = context.Tags.ToList().ElementAt(1),
                        Title = context.Title.ToList().ElementAt(0),
                        Value = rnd.Next(0,101),
                    },
                    new Statistic
                    {
                        User = auth.GetCurrentUser(),
                        Date = new DateTime(2021,12,20+i),
                        Tag = context.Tags.ToList().ElementAt(1),
                        Title = context.Title.ToList().ElementAt(1),
                        Value = rnd.Next(0,101),
                    },
                    new Statistic
                    {
                        User = auth.GetCurrentUser(),
                        Date = new DateTime(2021,12,20+i),
                        Tag = context.Tags.ToList().ElementAt(2),
                        Title = context.Title.ToList().ElementAt(0),
                        Value = rnd.Next(0,101),
                    },
                });

                context.SaveChanges();
            }
        }
    }
}
