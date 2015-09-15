using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventPlanner.Entities
{
    /// <summary>
    /// Enumeration for states of event items. Represents progress of event item
    /// </summary>
    [Serializable]
    public enum EventItemState
    {
        /// <summary>
        /// When item is just created
        /// </summary>
        Created = 1,

        /// <summary>
        /// Item is reviewed and approved to perform
        /// </summary>
        Approved = 2,

        /// <summary>
        /// Waits for start
        /// </summary>
        Open = 3,

        /// <summary>
        /// Item blocked by others
        /// </summary>
        Blocked = 4,

        /// <summary>
        /// In progress
        /// </summary>
        InProgress = 5,

        /// <summary>
        /// Finished, needs confirmation
        /// </summary>
        Finished = 6,

        /// <summary>
        /// All item related activities are verified
        /// </summary>
        Closed = 7,
    }
}
