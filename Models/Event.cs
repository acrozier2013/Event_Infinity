using Event_Infinity.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Event_Infinity.Models
{
    public class Event
    {
        public virtual int EventId { get; set; }
        //[Required]
        [Display(Name = "Event Type")]
        public virtual int EventTypeId { get; set; }
        [Required]
        [Display(Name = "Event Title")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public virtual string EventTitle { get; set; }

        [Display(Name = "Event Description")]
        [StringLength(150, ErrorMessage = "Event description cannot be longer than 150 characters.")]
        public virtual string EventDescription { get; set; }

        [Required]
        [Display(Name = "Event Start Date")]
        [DateValidator("EventStartDate")]
        public virtual DateTime EventStartDate { get; set; }

        [Required]
        [Display(Name = "Event End Date")]
        //  [DateValidator(DateTime.Now.ToString())]
        [DateValidator("EventEndDate")]
        public virtual DateTime EventEndDate { get; set; }
        [Required]
        public virtual string EventLocation { get; set; }
        public virtual EventType EventType { get; set; }
        [Required]
        [Display(Name = "Organizer Name")]
        public virtual string OrganizerName { get; set; }
        public virtual string OrganizerContactInfo { get; set; }
        [Required]
        [Display(Name = "Max Tickets")]
        [Range(1, 300, ErrorMessage ="Please enter a number between 0 and 300")]
        public virtual int MaxTickets { get; set; }
        [Required]
        [Display(Name = "Available Tickets")]
        [Range(1, 300, ErrorMessage = "Please enter a number between 0 and 300")]
        public virtual int AvailableTickets { get; set; }


    }
}