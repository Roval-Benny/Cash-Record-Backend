using Cash_Record_Backend.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cash_Record_Backend.Data.DAL
{
    public class EntryRepository : IEntryRepository
    {
        private readonly CashRecordDbContext _dbContext;

        public EntryRepository(CashRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Entry> GetAllEntry(string username)
        {
            return _dbContext.Entries.Where<Entry>(i=>i.User.UserName == username).ToList();
        }

        public Entry AddEntry(Entry entry)
        {
            _dbContext.Entries.Add(entry);
            _dbContext.SaveChanges();
            return entry;
        }

        public List<Entry> GetAllEntriesByYear(string username,int year)
        {
            return _dbContext.Entries.Where<Entry>(x => x.Date.Year == year && x.User.UserName == username).ToList();
        }

        public List<Entry> GetAllEntriesByMonth(string username,int year, int month)
        {
            return _dbContext.Entries.Where<Entry>(x => x.Date.Month == month && x.Date.Year == year && x.User.UserName == username).ToList();
        }

    }
}
