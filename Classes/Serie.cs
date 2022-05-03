namespace _21seriesCRUD
{
    public class Serie : BaseEntity
    {
        // Attributes
        private Gender Gender { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }

        // Methods

        public Serie(int id, Gender gender, string title, string description, int year)
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string returnMethod = "";
            returnMethod += $"Gender: {this.Gender},\nTitle: {this.Title},\nDescription: {this.Description},\nYear of start: {this.Year},\nDeleted: {this.Deleted}";
            return returnMethod;
        }

        public string getTitle()
        {
            return this.Title;
        }

        public int getId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Deleted = true;
        }

        public bool isDeleted()
        {
            return this.Deleted;
        }
    }
}