using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalDataSystem.Services
{
    public class EventService
    {
        // Stores events organized by their date.
        private SortedDictionary<DateTime, List<Event>> savedEvents = new SortedDictionary<DateTime, List<Event>>();
        private Dictionary<string, List<Event>> eventsByCategory = new Dictionary<string, List<Event>>();
        private HashSet<string> eventCategories = new HashSet<string>();
        private Queue<Event> eventQueue = new Queue<Event>();

        // Stores the user's most recent searches.
        // A Stack uses LIFO (Last In, First Out).
        private Stack<string> searchHistory = new Stack<string>();
        // Stores events according to their priority.
        // Lower priority numbers represent more important events.
        private PriorityQueue<Event, int> priorityEvents = new PriorityQueue<Event, int>();

        // Counts how often each category is searched.
        // Higher counts indicate stronger user interest.
        private Dictionary<string, int> searchPreferences = new Dictionary<string, int>();

        public void AddEvent(Event newEvent)
        {
            // Add event to the date-based dictionary
            if (savedEvents.ContainsKey(newEvent.Date))
            {
                savedEvents[newEvent.Date].Add(newEvent);
            }
            else
            {
                savedEvents.Add(newEvent.Date, new List<Event> { newEvent } );
            }

            // Add event to the category-based dictionary
            if (eventsByCategory.ContainsKey(newEvent.Category))
            {
                eventsByCategory[newEvent.Category].Add(newEvent);
            }
            else
            {
                eventsByCategory.Add(newEvent.Category, new List<Event> { newEvent } );
            }

            eventCategories.Add(newEvent.Category);
            eventQueue.Enqueue(newEvent);
        }

        public List<Event> GetEventsByDate(DateTime date)
        {
            if (savedEvents.ContainsKey(date))
            {
                return savedEvents[date];
            }

            return new List<Event>();
        }

        public List<Event> GetEventsByCategory(string category)
        {
            // Return an empty list if no category was provided.
            if (string.IsNullOrWhiteSpace(category))
            {
                return new List<Event>();
            }

            // Match categories without considering letter case.
            if (eventsByCategory.TryGetValue(category, out List<Event> events))
            {
                return events;
            }

            string matchingCategory = eventsByCategory.Keys
                .FirstOrDefault(c =>
                    string.Equals(
                        c,
                        category,
                        StringComparison.OrdinalIgnoreCase));

            if (matchingCategory != null)
            {
                return eventsByCategory[matchingCategory];
            }

            return new List<Event>();
        }

        public HashSet<string> GetCategories()//checking existing categories
        {
            return eventCategories;
        }

        public Event PeekNextEvent()
        {
            if (eventQueue.Count > 0)
            {
                return eventQueue.Peek();
            }

            return null;
        }

        public Event ProcessNextEvent()
        {
            if (eventQueue.Count > 0)
            {
                return eventQueue.Dequeue();
            }

            return null;
        }

        public void AddSearch(string category)
        {
            // Add the latest category search to the top of the stack.
            searchHistory.Push(category);
        }

        public string GetMostRecentSearch()
        {
            if (searchHistory.Count > 0)
            {
                // Peek returns the most recent search without removing it.
                return searchHistory.Peek();
            }

            return null;
        }

        public void AddPriorityEvent(Event newEvent, int priority)
        {
            // Add the event together with its priority.
            priorityEvents.Enqueue(newEvent, priority);
        }

        public Event ProcessPriorityEvent()
        {
            if (priorityEvents.Count > 0)
            {
                // Remove and return the event with the highest priority.
                return priorityEvents.Dequeue();
            }

            return null;
        }

        public void RecordCategorySearch(string category)
        {
            // Record the search in the stack for recent-search history.
            searchHistory.Push(category);

            // Increase the preference score for this category.
            if (searchPreferences.ContainsKey(category))
            {
                searchPreferences[category]++;
            }
            else
            {
                searchPreferences.Add(category, 1);
            }
        }

        public List<Event> GetRecommendedEvents()
        {
            List<Event> recommendations = new List<Event>();

            // Return no recommendations if the user has no search history.
            if (searchPreferences.Count == 0)
            {
                return recommendations;
            }

            // Find the category the user has searched for most often.
            string preferredCategory = searchPreferences
                .OrderByDescending(preference => preference.Value)
                .First().Key;

            // Retrieve events in the preferred category.
            if (eventsByCategory.ContainsKey(preferredCategory))
            {
                foreach (Event currentEvent in eventsByCategory[preferredCategory])
                {
                    // Only recommend events that have not already passed.
                    if (currentEvent.Date.Date >= DateTime.Today)
                    {
                        recommendations.Add(currentEvent);
                    }
                }
            }

            // Display the nearest upcoming events first.
            return recommendations
                .OrderBy(currentEvent => currentEvent.Date)
                .ToList();
        }
        public List<Event> GetAllEvents()
        {
            List<Event> allEvents = new List<Event>();

            // The SortedDictionary lets us traverse dates in chronological order.
            foreach (KeyValuePair<DateTime, List<Event>> entry in savedEvents)
            {
                allEvents.AddRange(entry.Value);
            }

            return allEvents;
        }

        public void LoadPriorityEvents()
        {
            // Clear existing priority entries before rebuilding the queue.
            priorityEvents.Clear();

            foreach (Event currentEvent in GetAllEvents())
            {
                // Announcements receive higher priority than ordinary events.
                int priority = currentEvent.IsAnnouncement ? 1 : 2;

                AddPriorityEvent(currentEvent, priority);
            }
        }


        public Event GetNextPriorityEvent()
        {
            return priorityEvents.Count > 0
                ? priorityEvents.Peek()
                : null;
        }
    }
}
