namespace PS6.Pages.Forms
{
    public class YearResponse
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public bool IsLeapYear()
        {
            return DateTime.IsLeapYear(Year);
        }

        public bool IsFemale()
        {
            return Name.EndsWith('a');
        }

        public YearResponse(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Name} urodził{(IsFemale() ? "a" : "")} się w {Year} roku. To {(IsLeapYear() ? "" : "nie")} był rok przestępny.";
        }
    }
}
