using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;

namespace Event_Infinity.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }
        public virtual int EventTypeId { get; set; }
        public virtual string EventTitle { get; set; }
        public virtual DateTime EventStartDate { get; set; }
        public virtual DateTime EventEndDate { get; set; }
        public virtual DateTime EventStartTime { get; set; }
        public virtual DateTime EventEndTime { get; set; }
        public virtual string EventLocation { get; set; }
        public virtual EventType EventType { get; set; }
        public virtual string OrganizerName { get; set; }
        public virtual string OrganizerContactInfo { get; set; }
        public virtual int MaxTickets { get; set; }
        public virtual int AvailableTickets { get; set; }

    }
}