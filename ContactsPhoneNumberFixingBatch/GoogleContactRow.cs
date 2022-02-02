using CsvHelper.Configuration.Attributes;

namespace ContactsPhoneNumberFixingBatch
{
    public class GoogleContactRow
    {
        [Index(0)] public string Name { get; set; }
        [Index(1)] public string GivenName { get; set; }
        [Index(2)] public string AdditionalName { get; set; }
        [Index(3)] public string FamilyName { get; set; }
        [Index(4)] public string YomiName { get; set; }
        [Index(5)] public string GivenNameYomi { get; set; }
        [Index(6)] public string AdditionalNameYomi { get; set; }
        [Index(7)] public string FamilyNameYomi { get; set; }
        [Index(8)] public string NamePrefix { get; set; }
        [Index(9)] public string NameSuffix { get; set; }
        [Index(10)] public string Initials { get; set; }
        [Index(11)] public string Nickname { get; set; }
        [Index(12)] public string ShortName { get; set; }
        [Index(13)] public string MaidenName { get; set; }
        [Index(14)] public string Birthday { get; set; }
        [Index(15)] public string Gender { get; set; }
        [Index(16)] public string Location { get; set; }
        [Index(17)] public string BillingInformation { get; set; }
        [Index(18)] public string DirectoryServer { get; set; }
        [Index(19)] public string Mileage { get; set; }
        [Index(20)] public string Occupation { get; set; }
        [Index(21)] public string Hobby { get; set; }
        [Index(22)] public string Sensitivity { get; set; }
        [Index(23)] public string Priority { get; set; }
        [Index(24)] public string Subject { get; set; }
        [Index(25)] public string Notes { get; set; }
        [Index(26)] public string Language { get; set; }
        [Index(27)] public string Photo { get; set; }
        [Index(28)] public string GroupMembership { get; set; }
        [Index(29)] public string E_mail1_Type { get; set; }
        [Index(30)] public string E_mail1_Value { get; set; }
        [Index(31)] public string E_mail2_Type { get; set; }
        [Index(32)] public string E_mail2_Value { get; set; }
        [Index(33)] public string Phone1_Type { get; set; }
        [Index(34)] public string Phone1_Value { get; set; }
        [Index(35)] public string Organization1_Type { get; set; }
        [Index(36)] public string Organization1_Name { get; set; }
        [Index(37)] public string Organization1_YomiName { get; set; }
        [Index(38)] public string Organization1_Title { get; set; }
        [Index(39)] public string Organization1_Department { get; set; }
        [Index(40)] public string Organization1_Symbol { get; set; }
        [Index(41)] public string Organization1_Location { get; set; }
        [Index(42)] public string Organization1_JobDescription { get; set; }


    }
}
