using System;
using System.ComponentModel.DataAnnotations;

namespace Event_Infinity.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }
        [Required]
        [Display(Name = "Event Type")]
        public virtual int EventTypeId { get; set; }
        [Required]
        [Display(Name = "Event Title")] 
        public virtual string EventTitle { get; set; }

        [Required]
        [Display(Name = "Event Description")]
        public virtual string EventDescription { get; set; }

        [Required]
        [Display(Name = "Event Start Date")]

        public virtual DateTime EventStartDate { get; set; }
        [Required]
        [Display(Name = "Event End Date")]
        public virtual DateTime EventEndDate { get; set; }
        //public virtual DateTime EventStartTime { get; set; }
        //public virtual DateTime EventEndTime { get; set; }
        public virtual string EventLocation { get; set; }
        public virtual EventType EventType { get; set; }
        [Required]
        [Display(Name = "Organizer Name")]
        public virtual string OrganizerName { get; set; }
        public virtual string OrganizerContactInfo { get; set; }
        [Required]
        [Display(Name = "Max Tickets")]
        public virtual int MaxTickets { get; set; }
        [Required]
        [Display(Name = "Available Tickets")]
        public virtual int AvailableTickets { get; set; }

    }
}