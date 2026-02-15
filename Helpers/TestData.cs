namespace TestAssignment;

public static class TestData
{
    private static readonly Random _rnd = new Random();

    public static string Email()
    {
        string prefix = PickOne(new[] { "test", "auto", "qa", "reg", "play", "demo", "hr" });
        string unique = (_rnd.Next(1000000, 9999999) + DateTime.Now.Ticks % 100000).ToString();
        return $"{prefix}{unique}@testmail.hr";
    }

    public static string Password()
    {
        string basePass = "Test" + _rnd.Next(1000, 9999);
        string extra = PickOne(new[] { "!", "@", "#", "$", "%", "^", "&", "*" });
        return basePass + extra + PickOne(new[] { "Hr", "2025", "Zag", "Split" });
    }

    public static string FirstName()
    {
        string[] patterns = { "Iv", "Mar", "Luk", "Nik", "Jos", "Ant", "Tom", "Pet", "Jur", "Stj", "Fil", "Dav", "Le", "No", "An", "Kat", "Luc", "Sar", "Nik", "Ema" };
        return patterns[_rnd.Next(patterns.Length)] + PickOne(new[] { "an", "ko", "a", "o", "ica", "eta", "in", "na", "ela", "ija" });
    }

    public static string LastName()
    {
        string[] roots = { "Hor", "Kov", "Nov", "Juri", "Mark", "Petrov", "Radi", "Babi", "Pavl", "Sim", "Lovr", "Perk", "Boz", "Knez", "Bar", "Gal", "Vid", "Tom", "Fran", "Dragi" };
        return roots[_rnd.Next(roots.Length)] + PickOne(new[] { "ić", "ović", "ević", "ić", "ak", "ec", "in", "ović", "ić" });
    }

    public static string City()
    {
        string[] parts = { "Gornja", "Donja", "Nova", "Stara", "Srednja", "Mala", "Velika", "Sveti", "Sveta", "" };
        string[] roots = { "Nedelja", "Petar", "Marko", "Luka", "Ivan", "Juraj", "Ante", "Martin", "Klara", "Jela", "Rok", "Križ", "Katarina" };
        string[] ends = { "ac", "evo", "ica", "polje", "grad", "selo", "brdo", "dol", "luka", "voda", "gora" };

        var p = PickOne(parts);
        var r = PickOne(roots);
        var e = PickOne(ends);

        return string.IsNullOrEmpty(p) ? r + e : $"{p} {r}{e}";
    }

    public static string Street()
    {
        int broj = _rnd.Next(1, 180);
        string[] ulice = { "Ulica", "Cesta", "Trg", "Avenija", "Put", "Ulica kralja", "Ulica kneza", "Obala" };
        string[] imena = { "Tomislava", "Zvonimira", "Krešimira", "Trpimira", "Branimira", "Petra", "Ante", "Jelačića", "Radića", "Starčevića", "Gupca", "Hebranga" };

        return $"{PickOne(ulice)} {PickOne(imena)} {broj}";
    }

    public static string Phone()
    {
        int operater = _rnd.Next(0, 10) < 7 ? _rnd.Next(91, 99) : _rnd.Next(95, 98); // većina 91-99
        int dio1 = _rnd.Next(100, 999);
        int dio2 = _rnd.Next(100, 999);
        return $"+385 {operater} {dio1} {dio2}";
    }

    public static string Zip()
    {
        return _rnd.Next(10000, 53297).ToString("00000");
    }

    private static string PickOne(string[] arr) => arr[_rnd.Next(arr.Length)];

    public static RegistrationData Generate()
    {
        return new RegistrationData
        {
            FirstName = FirstName(),
            LastName = LastName(),
            Email = Email(),
            Password = Password(),
            Phone = Phone(),
            StreetAddress = Street(),
            City = City(),
            ZipCode = Zip()
        };
    }
}

public record RegistrationData
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string Phone { get; init; }
    public string StreetAddress { get; init; }
    public string City { get; init; }
    public string ZipCode { get; init; }
}