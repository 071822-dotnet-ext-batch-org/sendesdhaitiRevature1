using Microsoft.EntityFrameworkCore;
using MS.MODELS;

namespace MS.REPO
{
    public interface IMSDBCONTEXT
    {
        DbSet<MintSoupToken> mintsouptoken { get; set; }
        DbSet<Person> people { get; set; }
        DbSet<Email> emails { get; set; }
        DbSet<Address> addresses { get; set; }
    }
}