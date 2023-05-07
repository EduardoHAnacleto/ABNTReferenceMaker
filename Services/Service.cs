using ABNTReferenceMaker.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace ABNTReferenceMaker.Services
{
    public class Service
    {


        public string MakePaperReference(Paper paper)
        {
            string reference = "";
            string authors = MakeNamesReference(paper);
            string day = paper.ReleaseDate.Day.ToString() + " ";
            string month = paper.ReleaseDate.Month.ToString("MMMM", new CultureInfo("pt-BR")) + ". ";
            string year = paper.ReleaseDate.Year.ToString() + ".";

            reference = authors + paper.Title + ". " + paper.Location + ", " + day + month + year;
            if (paper.Site != string.Empty || paper.Site != null)
            {
                reference = reference + MakeWebSiteReference(paper.Site);
            }

            return reference;
        }

        public string MakeWebSiteReference (string site)
        {
            string date = DateTime.Now.ToShortDateString();
            string reference = "Disponível em: " + site + ". Acesso em: " + date + "." ;
            return "";
        }

        public string GetLastName(Author person)
        {
            var author = person.Name;
            int lastSpaceIndex = author.LastIndexOf(' ');
            var mainAuthor = author.Substring(lastSpaceIndex + 1);
            return mainAuthor;
        }

        public string GetFirstName(Author person)
        {
            var author = person.Name;
            var lastName = GetLastName(person);
            var firstName = author.Substring(0, author.Length - lastName.Length);
            return firstName;
        }

        public string MakeNamesReference (Paper paper)
        {
            int i = 0;
            int k = paper.Authors.Count();
            string ArefNames = ""; 
            if (paper.Authors.Count > 3)
            {
                var last = GetLastName(paper.Authors.First());
                var first = GetFirstName(paper.Authors.First());
                string refNames = last.ToUpper() + ", " + first + " et al.";
                return refNames;
            }
            else
            {
                foreach (var author in paper.Authors)
                {
                    var last = GetLastName(author);
                    var first = GetFirstName(author);
                    if (i < k-1)
                    {
                        ArefNames = ArefNames + last.ToUpper() + ", " + first + ", ";
                        i++;
                    }
                    else if (i >= k-1) 
                    {
                        ArefNames = ArefNames + last.ToUpper() + ", " + first + ". ";
                    }
                }
            }

            return ArefNames;
        }
    }
}
