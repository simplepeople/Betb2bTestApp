using System;
using System.Collections.Generic;
using System.Linq;

namespace Betb2bTestAppModels.Models
{
    public class Status
    {
        public static readonly Status NotDefined = new Status("NotDefined", 0);
        public static readonly Status New = new Status("New", 1);
        public static readonly Status Active = new Status("Active", 2);
        public static readonly Status Blocked = new Status("Blocked", 3);
        public static readonly Status Deleted = new Status("Deleted", 4);

        private static readonly IList<Status> Statuses = new List<Status>
        {
            NotDefined, New, Active, Blocked, Deleted
        };

        public string Title { get; }
        public int Id { get; }
        private Status(string title, int id)
        {
            Title = title;
            Id = id;
        }

        public Status()
        {
        }

        public static implicit operator Status(int statusId) => Find(statusId);
        public static implicit operator Status(string statusTitle) => Find(statusTitle);
        public static implicit operator string(Status status) => status.Title;
        public static implicit operator int(Status status) => status.Id;



        public static Status Find(string statusTitle)
        {
            return Statuses.FirstOrDefault(x => x.Title == statusTitle) ??
                   throw new FormatException($"Could not find status with name: {statusTitle}");
        }

        public static Status Find(int statusId)
        {
            return Statuses.FirstOrDefault(x => x.Id == statusId) ??
                   throw new FormatException($"Could not find status with id: {statusId}");
        }

        public override string ToString()
        {
            return this;
        }
    }
}