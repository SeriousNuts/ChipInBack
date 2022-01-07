using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChipIn.models
{
    internal class MembersOfEvent
    {
        int EventId;
        int MemberId;

        public void SetEventId(Event @event)
        {
            EventId = @event.Id;
        }
        public void SetMemberId(Member member)
        {
            MemberId = member.Id;
        }
    }
}
