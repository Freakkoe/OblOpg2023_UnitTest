namespace ObligatoriskOpgave2023
{
    public class Book
    {
        public int Id { get; set; } //Must be Number
        public string Title { get; set; } //Minimum 3 Length & must not be null
        public int Price { get; set; } // Price must be and be between 0 & 1200 (0< && <=1200)

        public Book()
        {

        }

        public void ValidateTitle()
        {

            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title), "Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 character", nameof(Title));
            }
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
            {
                throw new ArgumentOutOfRangeException(nameof(Price), "Price must be or be between 0 & 1200");
            }
            
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }
    }
}