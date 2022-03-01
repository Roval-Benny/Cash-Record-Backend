using Cash_Record_Backend.Data.Entities;
using System.Collections.Generic;

namespace Cash_Record_Backend.Data.DAL
{
    public interface IEntryRepository
    {
        Entry AddEntry(Entry entry);
        List<Entry> GetAllEntriesByMonth(string username,int year, int month);
        List<Entry> GetAllEntriesByYear(string username,int year);
        List<Entry> GetAllEntry(string username);
    }
}