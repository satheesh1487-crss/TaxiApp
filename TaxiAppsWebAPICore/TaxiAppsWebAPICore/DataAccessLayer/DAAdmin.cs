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
            var countryData = context.TabCountry.ToList();
            foreach (var country in countryData)
            {
                countryList.Add(new CountryList()
                {
                    CountryId = country.CountryId,
                    CountryCode = country.Code,
                    CountryName = country.Name,
                    MobileCode = country.DCode
                });
            }
            return countryList == null ? null : countryList;
        }
        public List<Timezone> GetTimeZoneList(TaxiAppzDBContext context,long countryid)
        {
            List<Timezone> timezonelist = new List<Timezone>();
            var Timezonelist = context.TabTimezone.Where(c => c.Countryid == countryid).ToList();
            foreach (var timezone in Timezonelist)
            {
                timezonelist.Add(new Timezone()
                {
                    TimeZoneDescription = timezone.Zonedescription,
                    TimeZoneid = timezone.Timezoneid

                }) ;
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
