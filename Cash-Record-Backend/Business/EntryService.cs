using Cash_Record_Backend.Data.DAL;
using Cash_Record_Backend.Data.Entities;
using Cash_Record_Backend.Data.Exceptions;
using System;
using System.Collections.Generic;

namespace Cash_Record_Backend.Business
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _repo;

        public EntryService(IEntryRepository repo)
        {
            _repo = repo;
        }

        public List<Entry> GetAllEntry(string username)
        {
            if (_repo.GetAllEntry(username) != null)
            {
                return _repo.GetAllEntry(username);
            }
            else
            {
                throw new EntryNotFoundException("Entry Not Found");
            }
        }

        public List<Entry> GetAllEntrieByMonth(string username,int month, int year)
        {
            if (month < 0 || month > 13)
            {
                throw new InvalidMonthException("Month should range between 1 to 12");
            }
            else if (year < 1990 || year > DateTime.Now.Year)
            {
                throw new InvalidYearException($"Year ranges between 1990 to {DateTime.Now.Year}");
            }
            else if (_repo.GetAllEntriesByMonth(username,year, month) != null)
            {
                return _repo.GetAllEntriesByMonth(username,year, month);
            }
            else
            {
                throw new EntryNotFoundException("Entry Not Found");
            }
        }

        public List<Entry> GetAllEntriesByYear(string username, int year)
        {
            if (year < 1990 || year > DateTime.Now.Year)
            {
                throw new InvalidYearException($"Year ranges between 1990 to {DateTime.Now.Year}");
            }
            else if (_repo.GetAllEntriesByYear(username,year) != null)
            {
                return _repo.GetAllEntriesByYear(username,year);
            }
            else
            {
                throw new EntryNotFoundException("Entry Not Found");
            }
        }

        public Entry AddEntry(Entry entry)
        {
            return _repo.AddEntry(entry);
        }

    }
}
