using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Web;

namespace Event_Infinity.Models
{
    public class EventType
    {
        public virtual int EventTypeId { get; set; }
        public virtual string Description { get; set; }

    }
}