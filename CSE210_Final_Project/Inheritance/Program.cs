using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create events
        var lecture = new Lecture("Tech Talk", "A talk on latest tech trends", "2024-07-21", "10:00 AM", new Address("123 Tech St", "Techville", "CA", "USA"), "Dr. Smith", 100);
        var reception = new Reception("Company Meetup", "An informal meetup", "2024-07-22", "6:00 PM", new Address("456 Business Rd", "Biztown", "NY", "USA"), "rsvp@company.com");
        var outdoorGathering = new OutdoorGathering("Community Picnic", "A picnic for the community", "2024-07-23", "12:00 PM", new Address("789 Park Ave", "Parkcity", "TX", "USA"), "Sunny");

        // List of events
        var events = new List<Event> { lecture, reception, outdoorGathering };

        // Display event information
        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine(ev.GetShortDescription());
            Console.WriteLine();
        }
    }
}

abstract class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Date { get; private set; }
    public string Time { get; private set; }
    public Address Address { get; private set; }

    public Event(string title, string description, string date, string time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"Event: {Title}\nDescription: {Description}\nDate: {Date}\nTime: {Time}\nLocation: {Address}";
    }

    public abstract string GetFullDetails();

    public abstract string GetShortDescription();
}

class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }

    public override string GetShortDescription()
    {
        return $"Lecture: {Title} on {Date}";
    }
}

class Reception : Event
{
    public string RSVPEmail { get; private set; }

    public Reception(string title, string description, string date, string time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RSVPEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nRSVP: {RSVPEmail}";
    }

    public override string GetShortDescription()
    {
        return $"Reception: {Title} on {Date}";
    }
}

class OutdoorGathering : Event
{
    public string Weather { get; private set; }

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        Weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nWeather: {Weather}";
    }

    public override string GetShortDescription()
    {
        return $"Outdoor Gathering: {Title} on {Date}";
    }
}

class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string StateOrProvince { get; private set; }
    public string Country { get; private set; }

    public Address(string street, string city, string stateOrProvince, string country)
    {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {StateOrProvince}, {Country}";
    }
}
