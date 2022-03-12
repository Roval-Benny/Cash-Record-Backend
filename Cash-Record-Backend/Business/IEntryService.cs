using Cash_Record_Backend.Data.Entities;
using System.Collections.Generic;

namespace Cash_Record_Backend.Business
{
    public interface IEntryService
    {
        Entry AddEntry(Entry entry);
        List<Entry> GetAllEntrieByMonth(string username, int year, int month);
        List<Entry> GetAllEntriesByYear(string username, int year);
        List<Entry> GetAllEntry(string username);
    }
}