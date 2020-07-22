using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxiAppsWebAPICore.TaxiModels;

namespace TaxiAppsWebAPICore 
{
    public class DAAdmin
    {
        public List<CountryList> GetCountryList(TaxiAppzDBContext context)
        {
            List<CountryList> countryList = new List<CountryList>();
            var countryData = context.TabCountry.Distinct().ToList();
            foreach (var country in countryData)
            {
                countryList.Add(new CountryList()
                {
                    CountryId = country.CountryId,
                    CountryCode = country.Code,
                    CountryName = country.Name,
                    MobileCode = country.DCode,
                    TimeZoneaccess = country.TimeZone
                });
            }
            return countryList == null ? null : countryList;
        }
        public List<CountryList> GetTimeZoneList(TaxiAppzDBContext context,long countryid)
        {
            List<CountryList> timezonelist = new List<CountryList>();
            var Timezonelist = context.TabCountry.Where(c => c.CountryId == countryid).ToList();
            foreach (var timezone in Timezonelist)
            {
                timezonelist.Add(new CountryList()
                {
                     TimeZoneaccess = timezone.TimeZone,
                     CountryId=timezone.CountryId,
                     CountryName=timezone.Name,
                     CountryCode=timezone.Code
                    
                });
            }
            return timezonelist == null ? null : timezonelist;
        }
        public List<Language> GetLanguageList(TaxiAppzDBContext context)
        {
            List<Language> languagelist = new List<Language>();
            var LanguageList = context.TabCommonLanguages.ToList();
            foreach (var langlist in LanguageList)
            {
                languagelist.Add(new Language()
                {
                   LanguageID = langlist.Languageid,
                    ShortName = langlist.ShortLang,
                    LongName = langlist.Name
                });
            }
            return languagelist == null ? null : languagelist;
        }
    }
}
