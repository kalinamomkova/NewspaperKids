namespace NewspaperKids.Services
{
    using System.Linq;

    using NewspaperKids.Models.Entities;

    public class AccountService : Service
    {
        public void AddAuthor(string firstName, string lastName, int age, string userId)
        {
            var author = new Author
                             {
                                 Age = age,
                                 FirstName = firstName,
                                 LastName = lastName,
                                 ShouldChangePassword = true,
                                 UserId = userId
                             };
            this.Context.Authors.Add(author);
            this.Context.SaveChanges();
        }

        public bool ShoudPasswordBeChanged(string userId)
        {
           var user = this.Context.Authors.FirstOrDefault(u => u.UserId == userId);
            if (user.ShouldChangePassword)
            {
                return true;
            }
            return false;
        }

        public string GetUserId(string username)
        {
            return this.Context.Users.FirstOrDefault(u => u.UserName == username).Id;
        }

        public void SetSuccessfullFirstLogin(string userId)
        {
            var user = this.Context.Authors.FirstOrDefault(u => u.UserId == userId);
            user.ShouldChangePassword = false;
            this.Context.SaveChanges();
        }
    }
}