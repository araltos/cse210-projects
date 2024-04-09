public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private string time;
    private Address address;

    public Event(string title, string description, DateTime date, string time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GetStandardDetails()
    {
        return $"{title}\n{description}\n{date.ToShortDateString()}\n{time}\n{address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Event: {title} on {date.ToShortDateString()}";
    }
}


public class Address
{
    private string street;
    private string city;
    private string state;
    private string zipCode;

    public Address(string street, string city, string state, string zipCode)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.zipCode = zipCode;
    }

    public string GetFullAddress()
    {
        return $"{street}, {city}, {state}, {zipCode}";
    }
}


public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

public class Reception : Event
{
    private string emailForRSVP;

    public Reception(string title, string description, DateTime date, string time, Address address, string emailForRSVP)
        : base(title, description, date, time, address)
    {
        this.emailForRSVP = emailForRSVP;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nRSVP at: {emailForRSVP}";
    }
}

public class OutdoorGathering : Event
{
    private string weather;

    public OutdoorGathering(string title, string description, DateTime date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        this.weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetFullDetails()}\nWeather forecast: {weather}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        var lectureAddress = new Address("123 Lecture Lane", "Knowledge City", "Learn", "12345");
        var lectureEvent = new Lecture("Science Talk", "A talk on the importance of science.", new DateTime(2024, 5, 24), "14:00", lectureAddress, "Dr. Jane Doe", 100);

        var receptionAddress = new Address("456 Party Road", "Festive Town", "Celebrate", "67890");
        var receptionEvent = new Reception("Wedding Reception", "Celebrating the union of two hearts.", new DateTime(2024, 6, 12), "18:00", receptionAddress, "rsvp@example.com");

        var outdoorAddress = new Address("789 Park Ave", "Nature City", "Outdoors", "10112");
        var outdoorEvent = new OutdoorGathering("Summer Festival", "A festival to celebrate summer.", new DateTime(2024, 7, 4), "10:00", outdoorAddress, "Sunny with a chance of rain");

        
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine(lectureEvent.GetFullDetails());
        Console.WriteLine(lectureEvent.GetShortDescription());

        Console.WriteLine(receptionEvent.GetStandardDetails());
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine(receptionEvent.GetShortDescription());

        Console.WriteLine(outdoorEvent.GetStandardDetails());
        Console.WriteLine(outdoorEvent.GetFullDetails());
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}
