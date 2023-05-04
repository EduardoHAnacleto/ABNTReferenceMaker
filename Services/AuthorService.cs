using ABNTReferenceMaker.Data;
using ABNTReferenceMaker.Models;
using System.Drawing.Text;

namespace ABNTReferenceMaker.Entities
{
    public class AuthorService
    {
        private readonly ABNTReferenceMakerContext _context;

        public AuthorService(ABNTReferenceMakerContext context)
        {
            _context = context;
        }



        public List<Author> FindAll()
        {
            return _context.Author.ToList();
        }
    }
}
